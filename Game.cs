using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interface;
using System.Threading;

namespace FireSafety
{
    class Game
    {
        private Time TimePerFrame = Time.FromSeconds(1.0f / 60.0f);

        private FireSafetyForm form;
        private ParallelAlgorithm parallelAlgorithm;
        private World world;
        public static bool executing;

        public Game()
        {
            AssignEvents();

            parallelAlgorithm = new ParallelAlgorithm();

            executing = false;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form = new FireSafetyForm(parallelAlgorithm);
            form.Show();

            world = new World(parallelAlgorithm);
        }

        private void AssignEvents()
        {
            GuiT.getInstance().renderWindow.Closed += Window_Closed;
        }

        public void Run()
        {
            Clock clock = new Clock();
            Time timeSinceLastUpdate = Time.Zero;

            while (GuiT.getInstance().renderWindow.IsOpen)
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
            GuiT.getInstance().renderWindow.DispatchEvents();
        }

        private void Update(Time deltaTime)
        {
            world.Update(deltaTime);
        }

        private void Render()
        {
            // Clear our FireSafety RenderWindow
            GuiT.getInstance().renderWindow.Clear();
            // Drawing sprites
            GuiT.getInstance().renderWindow.Draw(world);
            GuiT.getInstance().Draw();
            // Display what FireSafety has drawn to the screen
            GuiT.getInstance().renderWindow.Display();
        }

        private static void Window_Closed(object sender, EventArgs e)
        {
            ((RenderWindow)sender).Close();
        }
    }
}
