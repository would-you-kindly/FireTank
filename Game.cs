using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FireSafety
{
    class Game
    {
        private Time TimePerFrame = Time.FromSeconds(1.0f / 2.0f);

        private RenderWindow window;
        private FireSafetyForm form;
        private Algorithm algorithm;
        private World world;
        public static bool executing;

        public Game()
        {
            window = new RenderWindow(new VideoMode(640, 480), "FireSafety");

            AssignEvents();

            algorithm = new Algorithm();

            executing = false;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form = new FireSafetyForm(algorithm);
            form.Show();

            world = new World(algorithm);
        }

        private void AssignEvents()
        {
            window.Closed += Window_Closed;
        }

        public void Run()
        {
            Clock clock = new Clock();
            Time timeSinceLastUpdate = Time.Zero;

            while (window.IsOpen)
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
            // Handle FireSafety events (NOTE this is still required when FireSafety is hosted in another window)
            window.DispatchEvents();
        }

        private void Update(Time deltaTime)
        {
            world.Update(deltaTime);
        }

        private void Render()
        {
            // Clear our FireSafety RenderWindow
            window.Clear();
            // Drawing sprites
            window.Draw(world);
            // Display what FireSafety has drawn to the screen
            window.Display();
        }

        private static void Window_Closed(object sender, EventArgs e)
        {
            ((RenderWindow)sender).Close();
        }
    }
}
