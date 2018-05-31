using SFML.Graphics;
using SFML.System;
using System;
using System.Linq;
using System.Windows.Forms;

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
            Rendered += gui.form.Game_Rendered;
        }

        public void Run()
        {
            Clock clock = new Clock();
            Time timeSinceLastUpdate = Time.Zero;

            while (gui.form.renderWindow.IsOpen)
            {
                Time dt = clock.Restart();
                timeSinceLastUpdate += dt;

                // Handle form events
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
                    // TODO: Есть ли синтаксис, который позволяет обратиться к переменной типа bool и после этого ее переключить step = !step
                    if (ParallelAlgorithm.GetInstance().running || ParallelAlgorithm.GetInstance().step)
                    {
                        // TODO: Костыль
                        ParallelAlgorithm.GetInstance().SetNextAction();

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
    }
}
