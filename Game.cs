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

        private FireSafetyForm form;
        private ParallelAlgorithm parallelAlgorithm;
        private World world;
        private RenderWindow renderWindow;
        public static bool executing = false;

        public Game()
        {
            parallelAlgorithm = new ParallelAlgorithm();
            world = new World();
            renderWindow = new RenderWindow(new VideoMode(Utilities.WINDOW_WIDTH, Utilities.WINDOW_HEIGHT), "Fire Tank");

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
            renderWindow.DispatchEvents();
        }

        private void Update(Time deltaTime)
        {
            // Каждый танк выполняет свой алгоритм
            for (int i = 0; i < world.tanks.Count(); i++)
            {
                world.tanks[i].Execute(parallelAlgorithm[i]);
            }

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
