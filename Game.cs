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

        private ParallelAlgorithm parallelAlgorithm;
        internal static World world;
        public static Gui gui;
        public static bool executing = false;

        // Переменные для обработки ошибок
        public static bool error = false;
        public static Tank errorTank;
        public static CollideEventArgs errorCollideEventArgs;

        public Game()
        {
            parallelAlgorithm = new ParallelAlgorithm();
            world = new World(parallelAlgorithm);
            gui = new Gui(parallelAlgorithm);

            AssignEvents();
        }

        private void AssignEvents()
        {
            gui.form.renderWindow.Closed += Window_Closed;
            foreach (Tank tank in world.tanks)
            {
                tank.Collide += Tank_Collide;
            }
        }

        public void Run()
        {
            Clock clock = new Clock();
            Time timeSinceLastUpdate = Time.Zero;

            while (gui.form.renderWindow.IsOpen)
            {
                Time dt = clock.Restart();
                timeSinceLastUpdate += dt;
                while (timeSinceLastUpdate > timePerFrame)
                {
                    timeSinceLastUpdate -= timePerFrame;

                    ProcessInput();
                    if (executing)
                    {
                        Update(timePerFrame);
                        //Utilities.CURRENT_ACTION_NUMBER++;
                    }
                    //else
                    //{
                    //    Utilities.CURRENT_ACTION_NUMBER = 0;
                    //}
                }

                //foreach (AlgorithmForm form in gui.form.algorithmForms)
                //{
                //    form.ColorActionRow(Utilities.CURRENT_ACTION_NUMBER);
                //}
                Render();

                // Если произошла ошибка во время выполнения алгоритма, выводим сообщение и перезапускаем карту
                if (error)
                {
                    error = false;
                    executing = false;
                    MessageBox.Show($"Во время выполнения алгоритма произошла ошибка.\n{errorTank.color.ToString()} танк столкнулся с объектом\n{errorCollideEventArgs.entity.GetType().ToString()}",
                        "Ошибка алгоритма", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    world.BuildWorld();
                }

                if (world.terrain.trees.Where(tree => tree.state.IsBurning()).Count() == 0)
                {
                    MessageBox.Show($"Количество деревьев: {world.terrain.trees.Count()}\n" +
                        $"Спасено деревьев: {world.terrain.trees.Where(tree=>tree.state.IsNormal()).Count()}\n" +
                        $"Сгорело деревьев: {world.terrain.trees.Where(tree => tree.state.IsBurned()).Count()}");
                    gui.form.Reload();
                }
            }
        }

        private void ProcessInput()
        {
            // TODO: Тут падало, если игра долго работает, из-за сборщика мусора
            // Handle form events
            Application.DoEvents();
            gui.form.renderWindow.DispatchEvents();
        }

        public static void Update(Time deltaTime)
        {
            world.Update(deltaTime);
        }

        private void Render()
        {
            gui.form.renderWindow.Clear();
            gui.form.renderWindow.Draw(world);
            gui.form.renderWindow.Display();
        }

        private static void Window_Closed(object sender, EventArgs e)
        {
            ((RenderWindow)sender).Close();
        }

        public static void Tank_Collide(object sender, CollideEventArgs e)
        {
            error = true;
            errorTank = (Tank)sender;
            errorCollideEventArgs = e;
        }
    }
}
