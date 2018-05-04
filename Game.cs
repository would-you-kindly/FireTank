using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace FireSafety
{
    public class Game
    {
        private Time timePerFrame = Time.FromSeconds(1.0f / 2.0f);

        // Классы для передачи параметров событий
        public class RenderEventArgs : EventArgs
        {
        }
        public class EndEventArgs : EventArgs
        {
        }

        // События игры
        public delegate void RenderEventHandler(object sender, RenderEventArgs e);
        public delegate void EndEventHandler(object sender, EndEventArgs e);
        public event RenderEventHandler Rendered;
        public event EndEventHandler Ended;

        // Переменные игры
        public World world;
        public Gui gui;

        public Game()
        {
            world = new World();
            gui = new Gui(world);

            AssignEvents();
        }

        private void AssignEvents()
        {
            gui.form.renderWindow.Closed += Window_Closed;
            Rendered += Game_Rendered;
        }

        public void Run()
        {
            Clock clock = new Clock();
            Time timeSinceLastUpdate = Time.Zero;

            while (gui.form.renderWindow.IsOpen)
            {
                Time dt = clock.Restart();
                timeSinceLastUpdate += dt;

                Application.DoEvents();

                // Чтобы быстрее реагировало на пошаговое выполнение, искусственно добавляем время
                if (ParallelAlgorithm.GetInstance().step)
                {
                    timeSinceLastUpdate += timePerFrame;
                }

                while (timeSinceLastUpdate > timePerFrame)
                {
                    timeSinceLastUpdate -= timePerFrame;

                    ProcessInput();
                    if (ParallelAlgorithm.GetInstance().running || ParallelAlgorithm.GetInstance().step)
                    {
                        ParallelAlgorithm.GetInstance().step = false;
                        Update(timePerFrame);
                    }
                }

                Render();
            }
        }

        private void ProcessInput()
        {
            // TODO: Тут падало, если игра долго работает, из-за сборщика мусора
            // Handle form events
            gui.form.renderWindow.DispatchEvents();
        }

        public void Update(Time deltaTime)
        {
            world.Update(deltaTime);
        }

        private void Render()
        {
            gui.form.renderWindow.Clear();
            gui.form.renderWindow.Draw(world);
            gui.form.renderWindow.Display();

            Rendered?.Invoke(this, new RenderEventArgs());
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            ((RenderWindow)sender)?.Close();
        }

        private void Game_Rendered(object sender, RenderEventArgs e)
        {
            CheckGameState();
        }

        private void CheckGameState()
        {
            // TODO: Приходится ждать пока карта перерисуется и только потом обрабатывать ошибку
            // TODO: Можно ли вызывать метод по срабатывания сразу двух событий? Есть подобный паттерн? (т.е. после столкновения И перерисовки)

            // Если произошла ошибка во время выполнения алгоритма, выводим сообщение и перезапускаем карту
            if (ParallelAlgorithm.GetInstance().errors.Count() != 0)
            {
                MessageBox.Show(ParallelAlgorithm.GetInstance().errors.ToString(),
                    "Ошибка выполнения алгоритма", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                ParallelAlgorithm.GetInstance().errors.Clear();
                ParallelAlgorithm.GetInstance().Reload();
                world.BuildWorld();
            }

            // Если горящих деревьев больше нет, выводим результат работы алгоритма
            if (world.terrain.trees.Where(tree => tree.state.IsBurning()).Count() == 0)
            {
                Ended?.Invoke(this, new EndEventArgs());

                MessageBox.Show($"Количество деревьев: {world.terrain.trees.Count()}\n" +
                    $"Спасено деревьев: {world.terrain.trees.Where(tree => tree.state.IsNormal()).Count()}\n" +
                    $"Сгорело деревьев: {world.terrain.trees.Where(tree => tree.state.IsBurned()).Count()}",
                    "Результат работы алгоритма", MessageBoxButtons.OK, MessageBoxIcon.Hand);

                ParallelAlgorithm.GetInstance().Reload();
                world.BuildWorld();


                // TODO: Не 7 !!!!
                MessageBox.Show(ParallelAlgorithm.GetInstance().ComputeEfficiency((int)Utilities.WIDTH_TILE_COUNT, (int)Utilities.HEIGHT_TILE_COUNT,
                    7, world.terrain.trees.Count(), world.terrain.trees.Where(tree => tree.state.IsBurned()).Count()).ToString());
            }
        }
    }
}
