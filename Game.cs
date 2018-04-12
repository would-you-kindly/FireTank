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
    class Game
    {
        private Time TimePerFrame = Time.FromSeconds(1.0f / 2.0f);

        private FireSafetyForm form;
        private ParallelAlgorithm parallelAlgorithm;
        private World world;
        private RenderWindow renderWindow;
        public static bool executing;

        public Game()
        {
            renderWindow = new RenderWindow(new VideoMode(32 * 16, 32 * 16), "Fire Tank");
            parallelAlgorithm = new ParallelAlgorithm();

            executing = false;

            world = new World(parallelAlgorithm);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form = new FireSafetyForm(parallelAlgorithm);
            form.Show();

            AssignEvents();
        }

        private void AssignEvents()
        {
            renderWindow.Closed += Window_Closed;
        }

        public void Run()
        {
            Clock clock = new Clock();
            Time timeSinceLastUpdate = Time.Zero;

            while (renderWindow.IsOpen)
            {
                Time dt = clock.Restart();
                timeSinceLastUpdate += dt;
                while (timeSinceLastUpdate > TimePerFrame)
                {
                    timeSinceLastUpdate -= TimePerFrame;

                    ProcessInput();
                    if (executing)
                    {
                        Update(TimePerFrame);
                    }
                }

                Render();
            }
        }

        private void ProcessInput()
        {
            // TODO: Тут падало, если игра долго работает, из-за сборщика мусора
            renderWindow.DispatchEvents();
        }

        private void Update(Time deltaTime)
        {
            world.Update(deltaTime);
        }

        private void Render()
        {
            renderWindow.Clear();
            renderWindow.Draw(world);
            renderWindow.Display();
        }

        private static void Window_Closed(object sender, EventArgs e)
        {
            ((RenderWindow)sender).Close();
        }
    }
}
