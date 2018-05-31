using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        public PlanForm planForm;
        public SettingsForm settingsForm;
        public Form sfmlForm;
        public RenderWindow renderWindow;

        private string savedFilename;

        public FireSafetyForm(World world)
        {
            InitializeComponent();

            worldController = new WorldController(world);
            savedFilename = string.Empty;

            Init();
        }

        public void Init()
        {
            // Создаем окна алгоритмов
            algorithmForms = new List<AlgorithmForm>();
            for (int i = 0; i < Utilities.GetInstance().TANKS_COUNT; i++)
            {
                AlgorithmForm algorithmForm = new AlgorithmForm();
                algorithmForm.dgvAlgorithm.Tag = i;
                algorithmForm.MdiParent = this;
                algorithmForm.Text = worldController.world.tanks[i].ToString();
                algorithmForm.Show();
                algorithmForms.Add(algorithmForm);
                algorithmsToolStripMenuItem.DropDownItems.Add(worldController.world.tanks[i].ToString(), null, new EventHandler((sender, e) =>
                {
                    algorithmForm.Visible = true;
                    algorithmForm.Select();
                }));

                // Устанавливаем значения танка в индикаторах
                InitIndicators(i, algorithmForm);
            }

            algorithmController = new ParallelAlgorithmController(algorithmForms);

            //planForm = new PlanForm();
            //for (int i = 0; i < Utilities.GetInstance().TANKS_COUNT; i++)
            //{
            //    planForm.dgvPlan.Columns.Add(worldController.world.tanks[i].ToString(),
            //        worldController.world.tanks[i].ToString());
            //}
            //planForm.MdiParent = this;
            //planForm.Show();

            // Задаем параметры формы, в которой будет выводится графика SFML
            sfmlForm = new Form();
            sfmlForm.MdiParent = this;
            sfmlForm.Text = $"Направление ветра - {worldController.GetWind().ToString()}";
            sfmlForm.MaximizeBox = false;
            sfmlForm.ClientSize = new Size((int)(Utilities.GetInstance().TILE_SIZE * Utilities.GetInstance().WIDTH_TILE_COUNT),
                (int)(Utilities.GetInstance().TILE_SIZE * Utilities.GetInstance().HEIGHT_TILE_COUNT));
            sfmlForm.MinimumSize = sfmlForm.Size;
            sfmlForm.Show();

            // Создаем surface на форме для рисования через контекст SFML
            DrawingSurface surface = new DrawingSurface();
            surface.Size = new Size((int)(Utilities.GetInstance().TILE_SIZE * Utilities.GetInstance().WIDTH_TILE_COUNT),
                    (int)(Utilities.GetInstance().TILE_SIZE * Utilities.GetInstance().HEIGHT_TILE_COUNT));
            sfmlForm.Controls.Add(surface);
            sfmlForm.ControlBox = false;
            sfmlForm.SizeChanged += (sender, e) =>
            {
                surface.Size = sfmlForm.ClientSize;
            };

            // Creates our SFML RenderWindow on our surface control
            renderWindow = new RenderWindow(surface.Handle);


        }

        private void InitIndicators(int i, AlgorithmForm algorithmForm)
        {
            algorithmForm.lblCapacity.Text = worldController.world.tanks[i].turret.waterCapacity.ToString();
            algorithmForm.lblPressure.Text = worldController.world.tanks[i].turret.waterPressure.ToString();
            algorithmForm.pbReady.Visible = worldController.world.tanks[i].turret.weaponReady;
            algorithmForm.pbUnready.Visible = !worldController.world.tanks[i].turret.weaponReady;
            algorithmForm.pbUp.Visible = worldController.world.tanks[i].turret.up;
            algorithmForm.pbDown.Visible = !worldController.world.tanks[i].turret.up;

            algorithmForm.lblMaxCapacity.Text = worldController.world.tanks[i].turret.maxWaterCapacity.ToString();
            algorithmForm.lblMaxPressure.Text = worldController.world.tanks[i].turret.maxWaterPressure.ToString();
        }

        public void AttachIndicators()
        {
            int i = 0;
            foreach (AlgorithmForm form in algorithmForms)
            {
                InitIndicators(i, form);

                // При выстреле меняем показатель запасов воды, давления и готовности
                worldController.world.tanks[i].turret.TurretShoot += (sender, e) =>
                {
                    form.lblCapacity.Text = (((Turret)sender).waterCapacity - 1).ToString();
                    form.lblPressure.Text = ((Turret)sender).minWaterPressure.ToString();

                    form.pbReady.Visible = false;
                    form.pbUnready.Visible = true;
                };

                // При увеличении давления меняем показатель давления
                worldController.world.tanks[i].turret.TurretPressure += (sender, e) =>
                {
                    form.lblPressure.Text = ((Turret)sender).waterPressure.ToString();
                };

                // При поднятии/опускании пушки меняем картинку
                worldController.world.tanks[i].turret.TurretUp += (sender, e) =>
                {
                    form.pbUp.Visible = true;
                    form.pbDown.Visible = false;
                };
                worldController.world.tanks[i].turret.TurretDown += (sender, e) =>
                {
                    form.pbUp.Visible = false;
                    form.pbDown.Visible = true;
                };

                // При заряде пушки меняем картинку
                worldController.world.tanks[i].turret.WeaponCharged += (sender, e) =>
                {
                    form.pbReady.Visible = true;
                    form.pbUnready.Visible = false;
                };

                // При пополнении запасов меняем значение запасов
                worldController.world.tanks[i].Refueled += (sender, e) =>
                {
                    form.lblCapacity.Text = ((Tank)sender).turret.waterCapacity.ToString();
                };

                i++;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            worldController.BuildWorld();
            AttachIndicators();
            algorithmController.RunAlgorithm();
        }

        private void saveAlgorithmAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = $"Fire tank algorithms files (*.fta{algorithmForms.Count})|*.fta{algorithmForms.Count};";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                savedFilename = sfd.FileName;
                algorithmController.SaveAlgorithm(new FileOpenSave(sfd.FileName));
            }
        }

        private void openAlgorithmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = $"Fire tank algorithms files (*.fta{algorithmForms.Count})|*.fta{algorithmForms.Count};";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                savedFilename = ofd.FileName;
                algorithmController.LoadAlgorithm(new FileOpenSave(ofd.FileName));
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
            if (savedFilename == string.Empty)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = $"Fire tank algorithms files (*.fta{algorithmForms.Count})|*.fta{algorithmForms.Count};";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    algorithmController.SaveAlgorithm(new FileOpenSave(sfd.FileName));
                }
            }
            else
            {
                algorithmController.SaveAlgorithm(new FileOpenSave(savedFilename));
            }
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reload();
        }

        public void Reload()
        {
            algorithmController.ReloadAlgorithm();
            worldController.BuildWorld();

            for (int i = 0; i < algorithmForms.Count; i++)
            {
                // Устанавливаем значения танка в индикаторах
                InitIndicators(i, algorithmForms[i]);
            }
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
                RebuildWorld(new FileOpenSave(ofd.FileName));

                // Создаем новые окна
                Init();

                // Применяем компоновку окон
                SmartLayoutMapUp();

                AttachIndicators();
            }
        }

        private void openMapFromDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenMapForm omf = new OpenMapForm();
            if (omf.ShowDialog() == DialogResult.OK)
            {
                // Очищаем алгоритм и окна перед открытием новой карты
                Clear();

                // Перестраиваем мир по новой карте
                RebuildWorld(new DatabaseOpenSave(omf.Guid));

                // Создаем новые окна
                Init();

                // Применяем компоновку окон
                SmartLayout();

                AttachIndicators();
            }
        }

        public void RebuildWorld(IOpenSave openSave)
        {
            worldController.LoadMap(openSave);
            worldController.BuildWorld();

            
        }

        public void Clear()
        {
            // Очищаем алгоритм
            algorithmController.ClearAlgorithm();

            // Закрываем окна
            algorithmForms.ForEach(form => form?.Close());
            renderWindow?.Close();
            sfmlForm?.Close();
            planForm?.Close();

            // Очищаем пункты меню алгоритмов
            algorithmsToolStripMenuItem.DropDownItems.Clear();
        }

        private void smartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SmartLayout();
        }

        public void SmartLayout()
        {
            // Подбираем размеры и положение для окна карты
            sfmlForm.ClientSize = new Size((int)(Utilities.GetInstance().TILE_SIZE * Utilities.GetInstance().WIDTH_TILE_COUNT),
                (int)(Utilities.GetInstance().TILE_SIZE * Utilities.GetInstance().HEIGHT_TILE_COUNT));
            sfmlForm.Location = new Point(0, 0);

            // Подбираем размеры для окон алгоритмов
            int algorithmFormsCountInColumn = (int)Math.Ceiling((decimal)(Utilities.GetInstance().TANKS_COUNT / 2.0));
            int algorithmFormHeight = (ClientSize.Height - menuStrip.Size.Height /*- statusStrip.Size.Height*/ - 4) / algorithmFormsCountInColumn;

            // Устанавливаем положение окон
            if (algorithmForms.Count >= 1 && algorithmForms.ElementAt(0) != null)
            {
                algorithmForms[0].Size = new Size(algorithmForms[0].MinimumSize.Width, algorithmFormHeight);
                algorithmForms[0].Location = new Point(sfmlForm.Size.Width, 0);
            }
            if (algorithmForms.Count >= 2 && algorithmForms.ElementAt(1) != null)
            {
                algorithmForms[1].Size = new Size(algorithmForms[1].MinimumSize.Width, algorithmFormHeight);
                algorithmForms[1].Location = new Point(sfmlForm.Size.Width + algorithmForms[0].Width, 0);
            }
            if (algorithmForms.Count >= 3 && algorithmForms.ElementAt(2) != null)
            {
                algorithmForms[2].Size = new Size(algorithmForms[2].MinimumSize.Width, algorithmFormHeight);
                algorithmForms[2].Location = new Point(sfmlForm.Size.Width, algorithmForms[0].Height);
            }
            if (algorithmForms.Count >= 4 && algorithmForms.ElementAt(3) != null)
            {
                algorithmForms[3].Size = new Size(algorithmForms[3].MinimumSize.Width, algorithmFormHeight);
                algorithmForms[3].Location = new Point(sfmlForm.Size.Width + algorithmForms[0].Width, algorithmForms[0].Height);
            }
            if (algorithmForms.Count >= 5 && algorithmForms.ElementAt(4) != null)
            {
                algorithmForms[4].Size = new Size(algorithmForms[4].MinimumSize.Width, algorithmFormHeight);
                algorithmForms[4].Location = new Point(sfmlForm.Size.Width, algorithmForms[0].Height + algorithmForms[2].Height);
            }
            if (algorithmForms.Count == 6 && algorithmForms.ElementAt(5) != null)
            {
                algorithmForms[5].Size = new Size(algorithmForms[5].MinimumSize.Width, algorithmFormHeight);
                algorithmForms[5].Location = new Point(sfmlForm.Size.Width + algorithmForms[0].Width, algorithmForms[0].Height + algorithmForms[2].Height);
            }
        }

        private void SmartLayoutMapUp()
        {
            // Подбираем размеры и положение для окна карты
            sfmlForm.ClientSize = new Size((int)(Utilities.GetInstance().TILE_SIZE * Utilities.GetInstance().WIDTH_TILE_COUNT),
                (int)(Utilities.GetInstance().TILE_SIZE * Utilities.GetInstance().HEIGHT_TILE_COUNT));
            sfmlForm.Location = new Point(0, 0);

            // Подбираем размеры для окон алгоритмов
            int algorithmFormHeight = (ClientSize.Height - menuStrip.Size.Height /*- statusStrip.Size.Height*/ - sfmlForm.Size.Height - 4);

            // Устанавливаем положение окон
            if (algorithmForms.Count >= 1 && algorithmForms.ElementAt(0) != null)
            {
                algorithmForms[0].Size = new Size(algorithmForms[0].MinimumSize.Width, algorithmFormHeight);
                algorithmForms[0].Location = new Point(algorithmForms[0].Width * 0, sfmlForm.Size.Height);
            }
            if (algorithmForms.Count >= 2 && algorithmForms.ElementAt(1) != null)
            {
                algorithmForms[1].Size = new Size(algorithmForms[1].MinimumSize.Width, algorithmFormHeight);
                algorithmForms[1].Location = new Point(algorithmForms[0].Width * 1, sfmlForm.Size.Height);
            }
            if (algorithmForms.Count >= 3 && algorithmForms.ElementAt(2) != null)
            {
                algorithmForms[2].Size = new Size(algorithmForms[2].MinimumSize.Width, algorithmFormHeight);
                algorithmForms[2].Location = new Point(algorithmForms[0].Width * 2, sfmlForm.Size.Height);
            }
            if (algorithmForms.Count == 4 && algorithmForms.ElementAt(3) != null)
            {
                algorithmForms[3].Size = new Size(algorithmForms[3].MinimumSize.Width, algorithmFormHeight);
                algorithmForms[3].Location = new Point(algorithmForms[0].Width * 3, sfmlForm.Size.Height);
            }
        }

        private void SmartLayoutMapDown()
        {
            // Подбираем размеры и положение для окна карты
            sfmlForm.ClientSize = new Size((int)(Utilities.GetInstance().TILE_SIZE * Utilities.GetInstance().WIDTH_TILE_COUNT),
                (int)(Utilities.GetInstance().TILE_SIZE * Utilities.GetInstance().HEIGHT_TILE_COUNT));

            // Подбираем размеры для окон алгоритмов
            int algorithmFormHeight = (ClientSize.Height - menuStrip.Size.Height /*- statusStrip.Size.Height*/ - sfmlForm.Size.Height - 4);

            // Устанавливаем положение окон
            if (algorithmForms.Count >= 1 && algorithmForms.ElementAt(0) != null)
            {
                algorithmForms[0].Size = new Size(algorithmForms[0].MinimumSize.Width, algorithmFormHeight);
                algorithmForms[0].Location = new Point(algorithmForms[0].Width * 0, 0);
            }
            if (algorithmForms.Count >= 2 && algorithmForms.ElementAt(1) != null)
            {
                algorithmForms[1].Size = new Size(algorithmForms[1].MinimumSize.Width, algorithmFormHeight);
                algorithmForms[1].Location = new Point(algorithmForms[0].Width * 1, 0);
            }
            if (algorithmForms.Count >= 3 && algorithmForms.ElementAt(2) != null)
            {
                algorithmForms[2].Size = new Size(algorithmForms[2].MinimumSize.Width, algorithmFormHeight);
                algorithmForms[2].Location = new Point(algorithmForms[0].Width * 2, 0);
            }
            if (algorithmForms.Count == 4 && algorithmForms.ElementAt(3) != null)
            {
                algorithmForms[3].Size = new Size(algorithmForms[3].MinimumSize.Width, algorithmFormHeight);
                algorithmForms[3].Location = new Point(algorithmForms[0].Width * 3, 0);
            }

            sfmlForm.Location = new Point(0, algorithmForms[0].Size.Height);
        }

        private void FireSafetyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Clear();
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
            SmartLayoutMapUp();
            //SmartLayout();
        }


        private void smartToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SmartLayoutMapUp();
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

        private void smartmapDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SmartLayoutMapDown();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Settings.GetInstance().currentUser != null)
            {
                openMapFromDatabaseToolStripMenuItem.Enabled = true;
            }
            else
            {
                openMapFromDatabaseToolStripMenuItem.Enabled = false;
            }
        }

        private void запуститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            worldController.BuildWorld();
            algorithmController.RunAlgorithm();
        }

        private void перезапуститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void шагToolStripMenuItem_Click(object sender, EventArgs e)
        {
            algorithmController.StepAlgorithm();
        }

        private void очиститьВсеЛагоритмыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите очистить все алгоритмы? Все несохраненные данные будут утеряны.",
                "Очистка алгоритма", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                worldController.BuildWorld();
                algorithmController.ClearAlgorithm();
            }
        }
    }
}
