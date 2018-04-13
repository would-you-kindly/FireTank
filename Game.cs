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
        private Time timePerFrame = Time.FromSeconds(1.0f / 60.0f);

        private ParallelAlgorithm parallelAlgorithm;
        internal static World world;
        public static Gui gui;
        public static bool executing = false;

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
                    }
                }

                Render();
            }
        }

        private void ProcessInput()
        {
            // TODO: Тут падало, если игра долго работает, из-за сборщика мусора
            Application.DoEvents(); // handle form events
            gui.form.renderWindow.DispatchEvents();
        }

        private void Update(Time deltaTime)
        {
            //// Каждый танк выполняет свой алгоритм
            //for (int i = 0; i < world.tanks.Count(); i++)
            //{
            //    world.tanks[i].Execute(parallelAlgorithm[i]);
            //}

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
    }
}
