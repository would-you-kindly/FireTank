using SFML.Graphics;
using SFML.Window;
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
                AlgorithmForm algorithmForm = new AlgorithmForm(_parallelAlgorithm[i]);
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
            sfmlForm.ControlBox = false;

            // Creates our SFML RenderWindow on our surface control
            renderWindow = new RenderWindow(surface.Handle);

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.gui.form.renderWindow.Close();
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Game.world.BuildWorld();

            for (int i = 0; i < algorithmForms.Count; i++)
            {
                algorithmForms[i].BuildAlgorithm();
            }
            //_parallelAlgorithm.Execute();
            Game.executing = true;
        }

        private void saveAlgorithmAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < algorithmForms.Count; i++)
            {
                algorithmForms[i].BuildAlgorithm();
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
            BinaryFormatter formatter = new BinaryFormatter();
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                {
                    _parallelAlgorithm = (ParallelAlgorithm)formatter.Deserialize(fs);
                }

                // Записываем шаги алгоритма в элементы управления формы
                for (int i = 0; i < algorithmForms.Count; i++)
                {
                    algorithmForms[i].dgvAlgorithm.Rows.Clear();
                    int actionCount = _parallelAlgorithm.Algorithms[i].Actions.Count;
                    for (int j = 0; j < actionCount; j++)
                    {
                        Action action = _parallelAlgorithm.Algorithms[i].Actions.Dequeue();
                        algorithmForms[i].dgvAlgorithm.Rows.Add(action.commands[0].ToString(), action.commands[1].ToString(), action.commands[2].ToString());
                    }
                    algorithmForms[i].dgvAlgorithm.ClearSelection();
                }
            }
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

        private void smartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SmartLayout();
        }

        private void SmartLayout()
        {
            // Подбираем размеры для окна карты
            sfmlForm.ClientSize = new Size((int)Utilities.WINDOW_WIDTH, (int)Utilities.WINDOW_HEIGHT);
            sfmlForm.Location = new Point(0, 0);

            // Подбираем размеры для окон алгоритмов
            int widthForAlgorithmForms = (ClientSize - sfmlForm.Size).Width;
            if (Utilities.TANKS_COUNT >= 2)
            {
                widthForAlgorithmForms = (ClientSize - sfmlForm.Size).Width / 2;
            }
            int heightForAlgorithmForms = ClientSize.Height - menuStrip.Size.Height - 3;
            if (Utilities.TANKS_COUNT >= 3)
            {
                heightForAlgorithmForms = (ClientSize.Height - menuStrip.Size.Height - 3) / 2;
            }

            // Расставляем окна алгоритмов
            for (int i = 0; i < Utilities.MAX_TANKS_COUNT; i++)
            {
                if (algorithmForms[0] != null)
                {
                    algorithmForms[0].Size = new Size(algorithmForms[0].MinimumSize.Width, heightForAlgorithmForms);
                    algorithmForms[0].Location = new Point(sfmlForm.Size.Width, 0);
                }
                if (algorithmForms[1] != null)
                {
                    algorithmForms[1].Size = new Size(algorithmForms[1].MinimumSize.Width, heightForAlgorithmForms);
                    algorithmForms[1].Location = new Point(sfmlForm.Size.Width + algorithmForms[0].Width, 0);
                }
                if (algorithmForms[2] != null)
                {
                    algorithmForms[2].Size = new Size(algorithmForms[2].MinimumSize.Width, heightForAlgorithmForms);
                    algorithmForms[2].Location = new Point(sfmlForm.Size.Width, algorithmForms[0].Height);
                }
                if (algorithmForms[3] != null)
                {
                    algorithmForms[3].Size = new Size(algorithmForms[3].MinimumSize.Width, heightForAlgorithmForms);
                    algorithmForms[3].Location = new Point(sfmlForm.Size.Width + algorithmForms[0].Width, algorithmForms[0].Height);
                }
            }
        }

        private void FireSafetyForm_Load(object sender, EventArgs e)
        {
            SmartLayout();
        }

        private void FireSafetyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Game.gui.form.renderWindow.Close();
        }
    }
}
