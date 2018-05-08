using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FireSafety
{
    // TODO: Есть атрибут, который запрещает использовать в данном классе определенный класс, типа [Forbidden(typeof(ParallelAlgorithm))]?
    public partial class FireSafetyForm : Form
    {
        private ParallelAlgorithmController algorithmController;
        private WorldController worldController;

        public List<AlgorithmForm> algorithmForms;
        public MapOpenerForm mapOpenerForm;
        public InfoForm infoForm;
        public SettingsForm settingsForm;
        public Form sfmlForm;
        public RenderWindow renderWindow;

        public FireSafetyForm(World world)
        {
            InitializeComponent();

            worldController = new WorldController(world);

            mapOpenerForm = new MapOpenerForm(this);

            Init();
        }

        public void Init()
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

            // Задаем параметры формы, в которой будет выводится графика SFML
            sfmlForm = new Form();
            sfmlForm.MdiParent = this;
            sfmlForm.Text = worldController.GetWindDirection().ToString(); 
            sfmlForm.ClientSize = new Size((int)Utilities.WINDOW_WIDTH, (int)Utilities.WINDOW_HEIGHT);
            sfmlForm.Show();

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
            sfd.Filter = "Fire tank algorithms files (*.fta)|*.fta;";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                algorithmController.SaveAlgorithm(sfd.FileName);
            }
        }

        private void openAlgorithmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Fire tank algorithms files (*.fta)|*.fta;";
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
            algorithmController.ReloadAlgorithm();
            worldController.BuildWorld();
        }

        private void openMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Fire tank maps files (*.tmx)|*.tmx;";
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

        public void LoadTrainingAlgorithm(string filename)
        {
            // Если указан обучающий алгоритм, загружаем его
            string algorithmFilename = worldController.GetMapProperty("algorithm");
            if (algorithmFilename != string.Empty)
            {
                filename = Path.Combine(Path.GetDirectoryName(filename), algorithmFilename);
                ParallelAlgorithm.GetInstance().LoadFromFile(filename);
            }
        }

        public void RebuildWorld(Guid id)
        {
            worldController.LoadMapFromDatabase(id);
            worldController.BuildWorld();
        }

        public void RebuildWorld(string filename)
        {
            worldController.LoadMapFromFile(filename);
            worldController.BuildWorld();
        }

        public void Clear()
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

        public void SmartLayout()
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

            // Устанавливаем положение окон
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
            algorithmController.StepAlgorithm();
        }

        private void ChooseAlgorithmFormMessage()
        {
            if (algorithmForms.All(form => !form.ContainsFocus))
            {
                MessageBox.Show("Необходимо выбрать окно алгоритма, чтобы выполнить данное действие.",
                    "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                ChooseAlgorithmFormMessage();
        }

        private void backwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbMove, ((ToolStripMenuItem)sender).Text);
            else
                ChooseAlgorithmFormMessage();
        }

        private void rotate45CWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbMove, ((ToolStripMenuItem)sender).Text);
            else
                ChooseAlgorithmFormMessage();
        }

        private void rotate45CCWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbMove, ((ToolStripMenuItem)sender).Text);
            else
                ChooseAlgorithmFormMessage();
        }

        private void rotate90CWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbMove, ((ToolStripMenuItem)sender).Text);
            else
                ChooseAlgorithmFormMessage();
        }

        private void rotate90CCWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbMove, ((ToolStripMenuItem)sender).Text);
            else
                ChooseAlgorithmFormMessage();
        }

        private void noneMoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbMove, ((ToolStripMenuItem)sender).Text);
            else
                ChooseAlgorithmFormMessage();
        }

        private void pressureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbCharge, ((ToolStripMenuItem)sender).Text);
            else
                ChooseAlgorithmFormMessage();
        }

        private void noneShootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbCharge, ((ToolStripMenuItem)sender).Text);
            else
                ChooseAlgorithmFormMessage();
        }

        private void rotate45CWToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbTurret, ((ToolStripMenuItem)sender).Text);
            else
                ChooseAlgorithmFormMessage();
        }

        private void rotate45CCWToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbTurret, ((ToolStripMenuItem)sender).Text);
            else
                ChooseAlgorithmFormMessage();
        }

        private void rotate90CWToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbTurret, ((ToolStripMenuItem)sender).Text);
            else
                ChooseAlgorithmFormMessage();
        }

        private void rotate90CCWToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbTurret, ((ToolStripMenuItem)sender).Text);
            else
                ChooseAlgorithmFormMessage();
        }

        private void upToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbTurret, ((ToolStripMenuItem)sender).Text);
            else
                ChooseAlgorithmFormMessage();
        }

        private void downToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbTurret, ((ToolStripMenuItem)sender).Text);
            else
                ChooseAlgorithmFormMessage();
        }

        private void shootToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbTurret, ((ToolStripMenuItem)sender).Text);
            else
                ChooseAlgorithmFormMessage();
        }

        private void noneTurretToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbTurret, ((ToolStripMenuItem)sender).Text);
            else
                ChooseAlgorithmFormMessage();
        }

        private void forward45CWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbMove, ((ToolStripMenuItem)sender).Text);
            else
                ChooseAlgorithmFormMessage();
        }

        private void forward45CCWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbMove, ((ToolStripMenuItem)sender).Text);
            else
                ChooseAlgorithmFormMessage();
        }

        private void backward45CWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbMove, ((ToolStripMenuItem)sender).Text);
            else
                ChooseAlgorithmFormMessage();
        }

        private void backward45CCWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbMove, ((ToolStripMenuItem)sender).Text);
            else
                ChooseAlgorithmFormMessage();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Открываем максимум одно окно настроек
            settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
        }

        private void FireSafetyForm_Load(object sender, EventArgs e)
        {
            SmartLayout();
        }

        private void openMapFromDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mapOpenerForm.ShowDialog();
        }

        private void deleteActionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChooseAlgorithmFormMessage();

            foreach (AlgorithmForm algorithmForm in algorithmForms)
            {
                if (algorithmForm.ContainsFocus)
                {
                    algorithmForm.DeleteAction();
                    break;
                }
            }
        }

        private void clearAlgorithmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChooseAlgorithmFormMessage();

            foreach (AlgorithmForm algorithmForm in algorithmForms)
            {
                if (algorithmForm.ContainsFocus)
                {
                    algorithmForm.ClearAlgorithm();
                    break;
                }
            }
        }

        private void pressureX2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbCharge, ((ToolStripMenuItem)sender).Text);
            else
                ChooseAlgorithmFormMessage();
        }

        private void refuelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbCharge, ((ToolStripMenuItem)sender).Text);
            else
                ChooseAlgorithmFormMessage();
        }

        private void chargeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
                Shortcut(algorithmForms.First(form => form.ContainsFocus).cbCharge, ((ToolStripMenuItem)sender).Text);
            else
                ChooseAlgorithmFormMessage();
        }
    }
}
