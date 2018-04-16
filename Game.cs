﻿using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using OpenTK;
using OpenTK.Graphics;

namespace FireSafety
{
    public class Game
    {
        private Time timePerFrame = Time.FromSeconds(1.0f / 60.0f);

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

            Toolkit.Init();
            GraphicsContext context = new GraphicsContext(new ContextHandle(IntPtr.Zero), null);

            //// Enable Z-buffer read and write
            //GL.Enable(EnableCap.DepthTest);
            //GL.DepthMask(true);
            //GL.ClearDepth(1);

            //// Disable lighting
            //GL.Disable(EnableCap.Lighting);

            //// Configure the viewport (the same size as the window)
            //GL.Viewport(0, 0, (int)gui.form.renderWindow.Size.X, (int)gui.form.renderWindow.Size.Y);

            //// Setup a perspective projection
            //GL.MatrixMode(MatrixMode.Projection);
            //GL.LoadIdentity();
            //float ratio = (float)(gui.form.renderWindow.Size.X) / gui.form.renderWindow.Size.Y;
            //GL.Frustum(-ratio, ratio, -1, 1, 1, 500);

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
                    }
                }

                Render();

                // Если произошла ошибка во время выполнения алгоритма, выводим сообщение и перезапускаем карту
                if (error)
                {
                    error = false;
                    executing = false;
                    MessageBox.Show($"Во время выполнения алгоритма произошла ошибка.\n{errorTank.tankColor.ToString()} танк столкнулся с объектом\n{errorCollideEventArgs.entity.GetType().ToString()}",
                        "Ошибка алгоритма", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    world.BuildWorld();
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
