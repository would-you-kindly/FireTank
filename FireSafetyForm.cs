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
    // TODO: Есть атрибут, который запрещает использовать в данном классе определенный класс, типа [Forbidden(typeof(ParallelAlgorithm))]
    public partial class FireSafetyForm : Form
    {
        private ParallelAlgorithmController algorithmController;
        private WorldController worldController;

        public List<AlgorithmForm> algorithmForms;
        public InfoForm infoForm;
        public SettingsForm settingsForm;
        public Form sfmlForm;
        public RenderWindow renderWindow;

        public FireSafetyForm(World world)
        {
            InitializeComponent();

            Init();

            worldController = new WorldController(world);
        }

        private void Init()
        {
            // Создаем окна алгоритмов
            algorithmForms = new List<AlgorithmForm>();
            for (int i = 0; i < Utilities.TANKS_COUNT; i++)
            {
                AlgorithmForm algorithmForm = new AlgorithmForm();
                algorithmForm.dgvAlgorithm.Tag = i;
                algorithmForm.MdiParent = this;
                algorithmForm.Text = $"{(i + 1)}. {Enum.Parse(typeof(Tank.TankColor), i.ToString()).ToString()}";
                algorithmForm.Show();
                algorithmForms.Add(algorithmForm);
            }

            algorithmController = new ParallelAlgorithmController(algorithmForms);

            infoForm = new InfoForm();
            infoForm.MdiParent = this;
            infoForm.Show();

            // Задаем параметры формы
            sfmlForm = new Form();
            sfmlForm.MdiParent = this;
            sfmlForm.Text = World.wind.direction.ToString();
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
            Clear();
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            worldController.BuildWorld();
            algorithmController.RunAlgorithm();
        }

        private void saveAlgorithmAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                algorithmController.SaveAlgorithm(sfd.FileName);
            }
        }

        private void openAlgorithmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                algorithmController.LoadAlgorithm(ofd.FileName);
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
            Reload();
        }

        public void Reload()
        {
            algorithmController.SetAlgorithmRunningState(false);
            worldController.BuildWorld();
        }

        private void openMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Очищаем алгоритм и окна перед открытием новой карты
                Clear();

                // Перестраиваем мир по новой карте
                RebuildWorld(ofd.FileName);

                // Создаем новые окна
                Init();

                // Применяем компоновку окон
                SmartLayout();

                // Загружаем тренировочный алгоритм (если он есть)
                LoadTrainingAlgorithm(ofd.FileName);
            }
        }

        private void LoadTrainingAlgorithm(string filename)
        {
            // Если указан обучающий алгоритм, загружаем его
            //if (Game.world.map.properties["algorithm"] != string.Empty)
            //{
            //    ParallelAlgorithm.GetInstance().Load(Path.Combine(Path.GetFullPath(filename), Game.world.map.properties["algorithm"]));
            //}
        }

        private void RebuildWorld(string filename)
        {
            worldController.LoadMap(filename);
            worldController.BuildWorld();
        }

        private void Clear()
        {
            // Очищаем алгоритм
            algorithmController.ClearAlgorithm();

            // Закрываем окна
            algorithmForms.ForEach(form => form?.Close());
            infoForm?.Close();
            renderWindow?.Close();
            sfmlForm?.Close();
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
            //for (int i = 0; i < Utilities.MAX_TANKS_COUNT; i++)
            //{
            if (algorithmForms.Count >= 1 && algorithmForms.ElementAt(0) != null)
            {
                algorithmForms[0].Size = new Size(algorithmForms[0].MinimumSize.Width, heightForAlgorithmForms);
                algorithmForms[0].Location = new Point(sfmlForm.Size.Width, 0);
            }
            if (algorithmForms.Count >= 2 && algorithmForms.ElementAt(1) != null)
            {
                algorithmForms[1].Size = new Size(algorithmForms[1].MinimumSize.Width, heightForAlgorithmForms);
                algorithmForms[1].Location = new Point(sfmlForm.Size.Width + algorithmForms[0].Width, 0);
            }
            if (algorithmForms.Count >= 3 && algorithmForms.ElementAt(2) != null)
            {
                algorithmForms[2].Size = new Size(algorithmForms[2].MinimumSize.Width, heightForAlgorithmForms);
                algorithmForms[2].Location = new Point(sfmlForm.Size.Width, algorithmForms[0].Height);
            }
            if (algorithmForms.Count == 4 && algorithmForms.ElementAt(3) != null)
            {
                algorithmForms[3].Size = new Size(algorithmForms[3].MinimumSize.Width, heightForAlgorithmForms);
                algorithmForms[3].Location = new Point(sfmlForm.Size.Width + algorithmForms[0].Width, algorithmForms[0].Height);
            }
            //}
        }

        private void FireSafetyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Clear();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите очистить алгоритм? Все несохраненные данные будут утеряны.",
                "Очистка алгоритма", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                worldController.BuildWorld();
                algorithmController.ClearAlgorithm();
            }
        }

        private void stepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            algorithmController.SetAlgorithmStep(true);
        }

        private void AddActionMessage()
        {
            if (algorithmForms.All(form => !form.ContainsFocus))
            {
                MessageBox.Show("Необходимо выбрать окно алгоритма, чтобы добавить в него команду.",
                    "Добавление команды", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Shortcut(ComboBox cb, string text)
        {
            foreach (AlgorithmForm algorithmForm in algorithmForms)
            {
                if (algorithmForm.ContainsFocus)
                {
                    cb.SelectedIndex = -1;
                    cb.SelectedItem = text;
                    break;
                }
            }
        }

        private void forwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbMove, ((ToolStripMenuItem)sender).Text);
            else
                AddActionMessage();
        }

        private void backwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbMove, ((ToolStripMenuItem)sender).Text);
            else
                AddActionMessage();
        }

        private void rotate45CWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbMove, ((ToolStripMenuItem)sender).Text);
            else
                AddActionMessage();
        }

        private void rotate45CCWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbMove, ((ToolStripMenuItem)sender).Text);
            else
                AddActionMessage();
        }

        private void rotate90CWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbMove, ((ToolStripMenuItem)sender).Text);
            else
                AddActionMessage();
        }

        private void rotate90CCWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbMove, ((ToolStripMenuItem)sender).Text);
            else
                AddActionMessage();
        }

        private void noneMoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbMove, ((ToolStripMenuItem)sender).Text);
            else
                AddActionMessage();
        }

        private void pressureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbShoot, ((ToolStripMenuItem)sender).Text);
            else
                AddActionMessage();
        }

        private void noneShootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbShoot, ((ToolStripMenuItem)sender).Text);
            else
                AddActionMessage();
        }

        private void rotate45CWToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbTurret, ((ToolStripMenuItem)sender).Text);
            else
                AddActionMessage();
        }

        private void rotate45CCWToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbTurret, ((ToolStripMenuItem)sender).Text);
            else
                AddActionMessage();
        }

        private void rotate90CWToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbTurret, ((ToolStripMenuItem)sender).Text);
            else
                AddActionMessage();
        }

        private void rotate90CCWToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbTurret, ((ToolStripMenuItem)sender).Text);
            else
                AddActionMessage();
        }

        private void upToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbTurret, ((ToolStripMenuItem)sender).Text);
            else
                AddActionMessage();
        }

        private void downToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbTurret, ((ToolStripMenuItem)sender).Text);
            else
                AddActionMessage();
        }

        private void shootToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbTurret, ((ToolStripMenuItem)sender).Text);
            else
                AddActionMessage();
        }

        private void noneTurretToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbTurret, ((ToolStripMenuItem)sender).Text);
            else
                AddActionMessage();
        }

        private void forward45CWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbMove, ((ToolStripMenuItem)sender).Text);
            else
                AddActionMessage();
        }

        private void forward45CCWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbMove, ((ToolStripMenuItem)sender).Text);
            else
                AddActionMessage();
        }

        private void backward45CWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbMove, ((ToolStripMenuItem)sender).Text);
            else
                AddActionMessage();
        }

        private void backward45CCWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbMove, ((ToolStripMenuItem)sender).Text);
            else
                AddActionMessage();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Открываем максимум одно окно настроек
            settingsForm = new SettingsForm();
            //settingsForm.MdiParent = this;
            settingsForm.ShowDialog();
        }

        private void FireSafetyForm_Load(object sender, EventArgs e)
        {
            SmartLayout();
        }
    }
}
