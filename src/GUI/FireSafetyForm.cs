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
                    OpenAlgorithmForm(algorithmForm);
                }));

                // Устанавливаем значения танка в индикаторах
                InitIndicators(i, algorithmForm);
            }

            algorithmController = new ParallelAlgorithmController(algorithmForms);

            planForm = new PlanForm();
            for (int i = 0; i < Utilities.GetInstance().TANKS_COUNT; i++)
            {
                planForm.dgvPlan.Columns.Add(worldController.world.tanks[i].ToString(),
                    worldController.world.tanks[i].ToString());
            }
            planForm.MdiParent = this;
            planForm.Show();

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

        public void InitIndicators(int i, AlgorithmForm algorithmForm)
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

        #region Методы класса
        private void SaveAlgorithm()
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

        private void SaveAlgorithmAs()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = $"Fire tank algorithms files (*.fta{algorithmForms.Count})|*.fta{algorithmForms.Count};";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                savedFilename = sfd.FileName;
                algorithmController.SaveAlgorithm(new FileOpenSave(sfd.FileName));
            }
        }

        private void OpenAlgorithm()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = $"Fire tank algorithms files (*.fta{algorithmForms.Count})|*.fta{algorithmForms.Count};";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                savedFilename = ofd.FileName;
                algorithmController.LoadAlgorithm(new FileOpenSave(ofd.FileName));
            }
        }

        private void OpenMap()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Fire tank maps files (*.tmx)|*.tmx;";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // Очищаем алгоритм и окна перед открытием новой карты
                ClearInterface();

                // Перестраиваем мир по новой карте
                RebuildWorld(new FileOpenSave(ofd.FileName));

                // Создаем новые окна
                Init();

                // Применяем компоновку окон
                SmartLayoutMapUp();

                // Для новых созданных окон снова привязываем события индикаторов
                AttachIndicators();
            }
        }

        private void OpenMapFromDatabase()
        {
            OpenMapForm omf = new OpenMapForm();
            if (omf.ShowDialog() == DialogResult.OK)
            {
                // Очищаем алгоритм и окна перед открытием новой карты
                ClearInterface();

                // Перестраиваем мир по новой карте
                RebuildWorld(new DatabaseOpenSave(omf.Guid));

                // Создаем новые окна
                Init();

                // Применяем компоновку окон
                SmartLayoutMapUp();

                // Для новых созданных окон снова привязываем события индикаторов
                AttachIndicators();
            }
        }

        private void DeleteAction()
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

        private void ClearTankAlgorithm()
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

        private void ClearWholeAlgorithm()
        {
            if (MessageBox.Show("Вы уверены, что хотите очистить все алгоритмы? Все несохраненные данные будут утеряны.",
                    "Очистка алгоритма", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                worldController.BuildWorld();
                algorithmController.ClearAlgorithm();
            }
        }

        private void RunAlgorithm()
        {
            // Восстанавливаем мир
            worldController.BuildWorld();
            // Запускаем алгоритм
            algorithmController.RunAlgorithm();

            // Восстанавливаем индикаторы параметров танков
            AttachIndicators();
        }

        private void ReloadAlgorithm()
        {
            // Очищаем ошибки алгоритма
            algorithmController.ClearErrors();
            // Перезапускаем алгоритм
            algorithmController.ReloadAlgorithm();
            // Перестраиваем мир
            worldController.BuildWorld();

            // Устанавливаем исходные параметров танков в индикаторах
            for (int i = 0; i < algorithmForms.Count; i++)
            {
                InitIndicators(i, algorithmForms[i]);
            }
        }

        private void StepAlgorithm()
        {
            algorithmController.StepAlgorithm();
        }

        private void SmartLayout()
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

            planForm.Location = new Point(sfmlForm.Size.Width, 0);

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

        private void OpenAlgorithmForm(AlgorithmForm algorithmForm)
        {
            algorithmForm.Visible = true;
            algorithmForm.Select();
        }

        private void OpenPlanForm()
        {
            planForm.Visible = true;
            planForm.Select();
        }

        private void OpenSettingsForm()
        {
            settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
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

        private void Shortcut(int performerNumber, object sender)
        {
            if (algorithmForms.Any(form => form.ContainsFocus))
            {
                switch (performerNumber)
                {
                    // Исполнитель "Водитель"
                    case 0:
                        Shortcut(algorithmForms.First(form => form.ContainsFocus).cbMove, ((ToolStripMenuItem)sender).Text);
                        break;
                    // Исполнитель "Заряжающий"
                    case 1:
                        Shortcut(algorithmForms.First(form => form.ContainsFocus).cbCharge, ((ToolStripMenuItem)sender).Text);
                        break;
                    // Исполнитель "Наводчик"
                    case 2:
                        Shortcut(algorithmForms.First(form => form.ContainsFocus).cbTurret, ((ToolStripMenuItem)sender).Text);
                        break;
                    default:
                        throw new Exception("Неверный номер исполнителя танка.");
                }
            }
            else
            {
                ChooseAlgorithmFormMessage();
            }
        }

        private void ChooseAlgorithmFormMessage()
        {
            if (algorithmForms.All(form => !form.ContainsFocus))
            {
                MessageBox.Show("Необходимо выбрать окно алгоритма, чтобы выполнить данное действие.",
                    "Выбор окна алгоритма", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RebuildWorld(IOpenSave openSave)
        {
            worldController.LoadMap(openSave);
            worldController.BuildWorld();
        }

        private void ClearInterface()
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

        private double ComputeResult()
        {
            int mapWidth = (int)Utilities.GetInstance().WIDTH_TILE_COUNT;
            int mapHeight = (int)Utilities.GetInstance().HEIGHT_TILE_COUNT;
            int initBurningTrees = Utilities.GetInstance().INIT_BURNING_TREES;
            int totalTrees = worldController.world.terrain.trees.Count();
            int burnedTrees = worldController.world.terrain.trees.Where(tree => tree.state.IsBurned()).Count();

            return algorithmController.ComputeEfficiency(mapWidth, mapHeight, initBurningTrees, totalTrees, burnedTrees);
        }

        private void ShowResultMessage(double result, bool success)
        {
            // Выводим предупреждение, если пользователь не авторизировался
            string warning = Settings.GetInstance().currentMap != null ? "" :
                "\n\nТекущая карта была открыта не из базы данных. Результат работы алгоритма не будет сохранен.";

            if (success)
            {
                MessageBox.Show($"Количество деревьев на карте: {worldController.world.terrain.trees.Count()}.\n" +
                  $"Спасено деревьев: {worldController.world.terrain.trees.Where(tree => tree.state.IsNormal()).Count()}.\n" +
                  $"Сгорело деревьев: {worldController.world.terrain.trees.Where(tree => tree.state.IsBurned()).Count()}.\n\n" +
                  $"Количество домов на карте: {worldController.world.terrain.houses.Count()}.\n" +
                  $"Спасено домов: {worldController.world.terrain.houses.Where(house => house.state.IsNormal()).Count()}.\n" +
                  $"Сгорело домов: {worldController.world.terrain.houses.Where(house => house.state.IsBurned()).Count()}.\n\n" +
                  $"Эффективность разработанного алгоритма = {Math.Round(result, 2)}." + warning,
                  "Результат работы алгоритма", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(algorithmController.GetErrors().ToString() + warning,
                    "Ошибка выполнения алгоритма", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void TrySaveResultInDatabase(double result, bool success)
        {
            if (Settings.GetInstance().currentUser != null && Settings.GetInstance().currentMap != null)
            {
                algorithmController.SaveAlgorithm(new DatabaseOpenSave(Guid.NewGuid(), result, success));
            }
        }

        private void CheckGameState()
        {
            // TODO: Приходится ждать пока карта перерисуется и только потом обрабатывать ошибку
            // TODO: Можно ли вызывать метод по срабатывания сразу двух событий? Есть подобный паттерн? (т.е. после столкновения И перерисовки)

            // Сначала проверяем алгоритм на ошибки
            CheckGameStateForErrors();

            // Затем проверяем мир на окончание пожара
            CheckGameStateForEnd();
        }

        private void CheckGameStateForErrors()
        {
            // Если произошла ошибка во время выполнения алгоритма, выводим сообщение и перезапускаем карту
            if (algorithmController.CheckErrors())
            {
                // Вычисляем результат работы алгоритма
                double result = ComputeResult();

                // Демонстрируем результат работы алгоритма
                ShowResultMessage(result, false);

                // Сохраняем результат, если пользователь авторизовался
                TrySaveResultInDatabase(result, false);

                // Перезапускаем алгоритм
                ReloadAlgorithm();
            }
        }

        private void CheckGameStateForEnd()
        {
            // Если горящих деревьев (и домов) больше нет, выводим результат работы алгоритма
            if (worldController.world.terrain.trees.Where(tree => tree.state.IsBurning()).Count() == 0 &&
                worldController.world.terrain.houses.Where(house => house.state.IsBurning()).Count() == 0 &&
                algorithmController.IsExecuted())
            {
                // Вычисляем результат работы алгоритма
                double result = ComputeResult();

                // Демонстрируем результат работы алгоритма
                ShowResultMessage(result, true);

                // Сохраняем результат, если пользователь авторизовался
                TrySaveResultInDatabase(result, true);

                // Перезапускаем алгоритм
                ReloadAlgorithm();
            }
        }
        #endregion

        #region Обработчики событий
        private void FireSafetyForm_Load(object sender, EventArgs e)
        {
            SmartLayoutMapUp();
        }

        private void FireSafetyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClearInterface();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // При раскрытии вкладки "Файл" блокируем открытие карты из БД, если пользователь не авторизировался
            if (Settings.GetInstance().currentUser != null)
            {
                openMapFromDatabaseToolStripMenuItem.Enabled = true;
            }
            else
            {
                openMapFromDatabaseToolStripMenuItem.Enabled = false;
            }
        }

        // Проверка состояния алгоритма на ошибки или на выполнение
        public void Game_Rendered(object sender, Game.RenderEventArgs e)
        {
            CheckGameState();
        }

        // Вкладка "Файл"
        private void saveAlgorithmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAlgorithm();
        }

        private void saveAlgorithmAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAlgorithmAs();
        }

        private void openAlgorithmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenAlgorithm();
        }

        private void openMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenMap();
        }

        private void openMapFromDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenMapFromDatabase();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearInterface();
        }

        // Вкладка "Правка"
        private void deleteActionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteAction();
        }

        private void clearTankAlgorithmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearTankAlgorithm();
        }

        private void clearWholeAlgorithmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearWholeAlgorithm();
        }

        // Вкладка "Алгоритм"
        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunAlgorithm();
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReloadAlgorithm();
        }

        private void stepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StepAlgorithm();
        }

        // Вкладка "Окно"
        private void smartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SmartLayout();
        }

        private void smartLayoutMapUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SmartLayoutMapUp();
        }

        private void smartLayoutMapDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SmartLayoutMapDown();
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void planToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenPlanForm();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSettingsForm();
        }

        // Горячие клавиши исполнителя "Водитель" (0)
        private void forwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shortcut(0, sender);
        }

        private void backwardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shortcut(0, sender);
        }

        private void rotate45CWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shortcut(0, sender);
        }

        private void rotate45CCWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shortcut(0, sender);
        }

        private void rotate90CWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shortcut(0, sender);
        }

        private void rotate90CCWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shortcut(0, sender);
        }

        private void forward45CWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shortcut(0, sender);
        }

        private void forward45CCWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shortcut(0, sender);
        }

        private void backward45CWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shortcut(0, sender);
        }

        private void backward45CCWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shortcut(0, sender);
        }

        private void noneMoveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shortcut(0, sender);
        }

        // Горячие клавиши исполнителя "Заряжающий" (1)
        private void pressureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shortcut(1, sender);
        }

        private void pressureX2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shortcut(1, sender);
        }

        private void chargeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shortcut(1, sender);
        }

        private void refuelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shortcut(1, sender);
        }

        private void noneShootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shortcut(1, sender);
        }

        // Горячие клавиши исполнителя "Наводчик" (2)
        private void rotateTurret45CWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shortcut(2, sender);
        }

        private void rotateTurret45CCWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shortcut(2, sender);
        }

        private void rotateTurret90CWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shortcut(2, sender);
        }

        private void rotateTurret90CCWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shortcut(2, sender);
        }

        private void upToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shortcut(2, sender);
        }

        private void downToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shortcut(2, sender);
        }

        private void shootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shortcut(2, sender);
        }

        private void noneTurretToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Shortcut(2, sender);
        }

        // "Быстрые" кнопки в правой части меню
        private void запуститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunAlgorithm();
        }

        private void перезапуститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReloadAlgorithm();
        }

        private void шагToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StepAlgorithm();
        }
        #endregion

    }
}
