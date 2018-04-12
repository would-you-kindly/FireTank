using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace FireSafety
{
    public partial class FireSafetyForm : Form
    {
        ParallelAlgorithm _parallelAlgorithm;
        List<AlgorithmForm> algorithmForms;
        public RenderWindow renderWindow;
        Form sfmlForm;

        public FireSafetyForm(ParallelAlgorithm parallelAlgorithm)
        {
            InitializeComponent();

            _parallelAlgorithm = parallelAlgorithm;

            algorithmForms = new List<AlgorithmForm>();
            for (int i = 0; i < Utilities.TANKS_COUNT; i++)
            {
                AlgorithmForm algorithmForm = new AlgorithmForm();
                algorithmForm.MdiParent = this;
                algorithmForm.Text = Enum.Parse(typeof(Tank.TankColor), i.ToString()).ToString();
                algorithmForm.Show();
                algorithmForms.Add(algorithmForm);
            }

            // Задаем параметры формы
            sfmlForm = new Form();
            sfmlForm.MdiParent = this;
            sfmlForm.Text = "Map";
            sfmlForm.Show();
            sfmlForm.ClientSize = new Size((int)Utilities.WINDOW_WIDTH, (int)Utilities.WINDOW_HEIGHT);

            // Создаем surface на форме для рисования через контекст SFML
            DrawingSurface surface = new DrawingSurface();
            surface.Size = new Size((int)Utilities.WINDOW_WIDTH, (int)Utilities.WINDOW_HEIGHT);
            sfmlForm.Controls.Add(surface);

            // Creates our SFML RenderWindow on our surface control
            renderWindow = new RenderWindow(surface.Handle);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < algorithmForms.Count; i++)
            {
                _parallelAlgorithm[i] = algorithmForms[i].BuildAlgorithm();
            }
            //_parallelAlgorithm.Execute();
            Game.executing = true;
        }

        private void saveAlgorithmAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < algorithmForms.Count; i++)
            {
                // Не фактическое выполнение, а перенос слов с элементов управления в экземпляры класса Flgorithm
                _parallelAlgorithm[i] = algorithmForms[i].BuildAlgorithm();
            }

            BinaryFormatter formatter = new BinaryFormatter();
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write))
                {
                    formatter.Serialize(fs, _parallelAlgorithm);
                }
            }
        }

        private void openAlgorithmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ParallelAlgorithm loadedParallelAlgorithm;
            BinaryFormatter formatter = new BinaryFormatter();
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                {
                    loadedParallelAlgorithm = (ParallelAlgorithm)formatter.Deserialize(fs);
                }

                // Пишем шаги алгоритма в элементы управления формы
                for (int i = 0; i < algorithmForms.Count; i++)
                {
                    int actionCount = loadedParallelAlgorithm.Algorithms[i].Actions.Count;
                    for (int j = 0; j < actionCount; j++)
                    {
                        Action action = loadedParallelAlgorithm.Algorithms[i].Actions[actionCount - 1];
                        loadedParallelAlgorithm.Algorithms[i].Actions.RemoveAt(actionCount - 1);
                        algorithmForms[i].lbMoveCommands.Items.Add(action.commands[0].ToString());
                        algorithmForms[i].lbShootCommands.Items.Add(action.commands[1].ToString());
                        algorithmForms[i].lbTurretCommands.Items.Add(action.commands[2].ToString());
                    }
                }
            }
        }

        private void arrandeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void saveAlgorithmToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.executing = false;
            Game.world.BuildWorld();
        }

        private void openMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Game.world.LoadMap(ofd.FileName);
                Game.world.BuildWorld();
            }
        }
    }
}
