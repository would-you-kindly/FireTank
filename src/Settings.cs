using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace FireSafety
{
    [Serializable]
    public class Settings
    {
        [XmlIgnore]
        [NonSerialized]
        private static Settings instance;

        // Классы для передачи параметров событий
        public class UpdateShortcutEventArgs : EventArgs
        {
            private object command;
            private Keys key;

            public UpdateShortcutEventArgs(object command, Keys key)
            {
                this.command = command;
                this.key = key;
            }
        }
        public class DefaultShortcutEventArgs : EventArgs
        {
        }

        // События настроек
        public delegate void UpdateShortcutEventHandler(object sender, UpdateShortcutEventArgs e);
        public delegate void DefaultShortcutEventHandler(object sender, DefaultShortcutEventArgs e);
        public event UpdateShortcutEventHandler ShortcutUpdated;
        public event DefaultShortcutEventHandler Defaulted;

        [XmlIgnore]
        [NonSerialized]
        private const string filename = "Settings.xml";
        [XmlIgnore]
        [NonSerialized]
        //private string connectionStringDefault = @"data source =.\sqlexpress; initial catalog = FireTankAdmin; integrated security = True;";
        //private string connectionStringDefault = ConfigurationManager.ConnectionStrings["LocalServer"].ConnectionString;
        private string connectionStringDefault = @"Data Source=STUD-DBA\MSSQLSERVER16;Initial Catalog=FireTankAdmin;User ID=localuser;Password=654321";
        //private string connectionStringDefault = ConfigurationManager.ConnectionStrings["HSEServer"].ConnectionString;
        [XmlIgnore]
        [NonSerialized]
        public UserModel currentUser;
        [XmlIgnore]
        [NonSerialized]
        public MapModel currentMap;

        [NonSerialized]
        private const Keys clearSelectionDefault = Keys.Escape;
        [NonSerialized]
        private const Keys deleteActionDefault = Keys.Delete;
        [NonSerialized]
        private const Keys clearTankAlgorithmDefault = Keys.Back;

        [NonSerialized]
        private const Keys noneDefault = Keys.N;

        // Команды движения
        [NonSerialized]
        private const Keys moveForwardDefault = Keys.F;
        [NonSerialized]
        private const Keys moveBackwardDefault = Keys.B;
        [NonSerialized]
        private const Keys moveForward45CWDefault = Keys.NumPad9;
        [NonSerialized]
        private const Keys moveForward45CCWDefault = Keys.NumPad7;
        [NonSerialized]
        private const Keys moveBackward45CWDefault = Keys.NumPad1;
        [NonSerialized]
        private const Keys moveBackward45CCWDefault = Keys.NumPad3;
        // Короткие/долгие команды движения (короткое нажатие - 45, долгое нажатие - 90)
        [NonSerialized]
        private const Keys moveRotateCWDefault = Keys.NumPad8;
        [NonSerialized]
        private const Keys moveRotateCCWDefault = Keys.NumPad2;

        // Команды перезарядки
        [NonSerialized]
        private const Keys chargeRefuelDefault = Keys.R;
        // Короткие/долгие команды перезарядки (короткое нажатие - увеличение давления на 1, долгое нажатие - увеличение давления на 2)
        [NonSerialized]
        private const Keys chargePressureDefault = Keys.P;
        // Короткие/долгие команды перезарядки (короткое нажатие - заряд пушки 1, долгое нажатие - заряд пушки 2)
        [NonSerialized]
        private const Keys chargeChargeDefault = Keys.C;

        // Команды башни
        [NonSerialized]
        private const Keys turretUpDefault = Keys.U;
        [NonSerialized]
        private const Keys turretDownDefault = Keys.D;
        // Короткие/долгие команды башни (короткое нажатие - выстрел из пушки 1, долгое нажатие - выстрел из пушки 2)
        [NonSerialized]
        private const Keys turretShootDefault = Keys.S;
        // Короткие/долгие команды башни (короткое нажатие - 45 градусов, долгое нажатие - 90 градусов)
        [NonSerialized]
        private const Keys turretRotateCWDefault = Keys.NumPad6;
        [NonSerialized]
        private const Keys turretRotateCCWDefault = Keys.NumPad4;

        // Команды меню
        [NonSerialized]
        private const Keys runDefault = Keys.F5;
        [NonSerialized]
        private const Keys reloadDefault = Keys.F6;
        [NonSerialized]
        private const Keys stepDefault = Keys.F7;
        [NonSerialized]
        private const Keys clearDefault = Keys.F8;

        // Shortcuts
        public Keys clearSelection;
        public Keys deleteAction;
        public Keys clearTankAlgorithm;

        public Keys none;

        public Keys moveForward;
        public Keys moveBackward;
        public Keys moveForward45CW;
        public Keys moveForward45CCW;
        public Keys moveBackward45CW;
        public Keys moveBackward45CCW;
        public Keys moveRotateCW;
        public Keys moveRotateCCW;

        public Keys chargeRefuel;
        public Keys chargePressure;
        public Keys chargeCharge;

        public Keys turretUp;
        public Keys turretDown;
        public Keys turretShoot;
        public Keys turretRotateCW;
        public Keys turretRotateCCW;

        public Keys run;
        public Keys reload;
        public Keys step;
        public Keys clearParallelAlgorithm;

        public int timeToHold = 200;
        public string connectionString;

        [XmlIgnore]
        [NonSerialized]
        public ModelContext context;

        public Settings()
        {

            //Default();
        }

        public static Settings GetInstance()
        {
            if (instance == null)
            {
                instance = new Settings();

                // Грузим настройки из файла
                instance.Load();

                instance.context = new ModelContext(instance.connectionString);

                instance.ShortcutUpdated += Settings_ShortcutUpdated;
            }

            return instance;
        }

        private static void Settings_ShortcutUpdated(object sender, UpdateShortcutEventArgs e)
        {
            instance.Save();
        }

        public void SetCurrentUser(Guid user)
        {
            UserRepository userRepository = new UserRepository(context);

            currentUser = userRepository.Read(user);
        }

        public void SetCurrentMap(Guid map)
        {
            MapRepository mapRepository = new MapRepository(context);

            currentMap = mapRepository.Read(map);
        }

        public void UnsetCurrentUser()
        {
            currentUser = null;
        }

        public void UnsetCurrentMap()
        {
            currentMap = null;
        }

        public string GetUserString()
        {
            if (currentUser != null)
            {
                return $"{currentUser.Name} {currentUser.Lastname}";
            }
            else
            {
                return string.Empty;
            }
        }

        public void SetShortcut(string performer, string command, Keys key)
        {
            switch (command)
            {
                case "Бездействие":
                    none = key;
                    break;
                case "Вперед":
                    moveForward = key;
                    break;
                case "Назад":
                    moveBackward = key;
                    break;
                case "Вперед 45° по ч.с.":
                    moveForward45CW = key;
                    break;
                case "Вперед 45° пр. ч.с.":
                    moveForward45CCW = key;
                    break;
                case "Назад 45° по ч.с.":
                    moveBackward45CW = key;
                    break;
                case "Назад 45° пр. ч.с.":
                    moveBackward45CCW = key;
                    break;
                case "45° по ч.с.":
                    if (performer == Properties.Resources.MovePerformer)
                    {
                        moveRotateCW = key;
                    }
                    if (performer == "Наводчик")
                    {
                        turretRotateCW = key;
                    }
                    break;
                case "45° пр. ч.с.":
                    if (performer == "Водитель")
                    {
                        moveRotateCCW = key;
                    }
                    if (performer == "Наводчик")
                    {
                        turretRotateCCW = key;
                    }
                    break;
                case "Пополнить запас":
                    chargeRefuel = key;
                    break;
                case "Давление +1":
                    chargePressure = key;
                    break;
                case "Зарядить":
                    chargeCharge = key;
                    break;
                case "Поднять":
                    turretUp = key;
                    break;
                case "Опустить":
                    turretDown = key;
                    break;
                case "Выстрелить":
                    turretShoot = key;
                    break;
                case "Отменить выделение":
                    clearSelection = key;
                    break;
                case "Удалить действие":
                    deleteAction = key;
                    break;
                case "Очистить алгоритм танка":
                    clearTankAlgorithm = key;
                    break;
                case "Запустить":
                    run = key;
                    break;
                case "Перезагрузить":
                    reload = key;
                    break;
                case "Шаг":
                    step = key;
                    break;
                case "Очистить все алгоритмы":
                    clearParallelAlgorithm = key;
                    break;
                default:
                    break;
            }

            ShortcutUpdated?.Invoke(this, new UpdateShortcutEventArgs(command, key));
        }

        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            using (FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(fs, this);
            }
        }

        public void Load()
        {
            // Если файл с настройками не найден, то восстанавливаем его с настройками по умолчанию
            if (!File.Exists(filename))
            {
                Default();
            }

            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                instance = (Settings)serializer.Deserialize(fs);
            }
        }

        public void Default()
        {
            clearSelection = clearSelectionDefault;
            deleteAction = deleteActionDefault;
            clearTankAlgorithm = clearTankAlgorithmDefault;

            none = noneDefault;

            moveForward = moveForwardDefault;
            moveBackward = moveBackwardDefault;
            moveForward45CW = moveForward45CWDefault;
            moveForward45CCW = moveForward45CCWDefault;
            moveBackward45CW = moveBackward45CWDefault;
            moveBackward45CCW = moveBackward45CCWDefault;
            moveRotateCW = moveRotateCWDefault;
            moveRotateCCW = moveRotateCCWDefault;

            chargeRefuel = chargeRefuelDefault;
            chargePressure = chargePressureDefault;
            chargeCharge = chargeChargeDefault;

            turretUp = turretUpDefault;
            turretDown = turretDownDefault;
            turretShoot = turretShootDefault;
            turretRotateCW = turretRotateCWDefault;
            turretRotateCCW = turretRotateCCWDefault;

            run = runDefault;
            reload = reloadDefault;
            step = stepDefault;
            clearParallelAlgorithm = clearDefault;

            connectionString = connectionStringDefault;

            Save();

            Defaulted?.Invoke(this, new DefaultShortcutEventArgs());
        }

        public List<Tuple<string, string, Keys>> GenerateShortcutList()
        {
            // Исполнитель, команда, shortcut
            List<Tuple<string, string, Keys>> shortcuts = new List<Tuple<string, string, Keys>>();

            shortcuts.Add(new Tuple<string, string, Keys>(Properties.Resources.AllPerformers, Utilities.ToMoveStringRus(MoveCommand.Commands.None), none));

            shortcuts.Add(new Tuple<string, string, Keys>(Properties.Resources.MovePerformer, Utilities.ToMoveStringRus(MoveCommand.Commands.Forward), moveForward));
            shortcuts.Add(new Tuple<string, string, Keys>(Properties.Resources.MovePerformer, Utilities.ToMoveStringRus(MoveCommand.Commands.Backward), moveBackward));
            shortcuts.Add(new Tuple<string, string, Keys>(Properties.Resources.MovePerformer, Utilities.ToMoveStringRus(MoveCommand.Commands.Forward45CW), moveForward45CW));
            shortcuts.Add(new Tuple<string, string, Keys>(Properties.Resources.MovePerformer, Utilities.ToMoveStringRus(MoveCommand.Commands.Forward45CCW), moveForward45CCW));
            shortcuts.Add(new Tuple<string, string, Keys>(Properties.Resources.MovePerformer, Utilities.ToMoveStringRus(MoveCommand.Commands.Backward45CW), moveBackward45CW));
            shortcuts.Add(new Tuple<string, string, Keys>(Properties.Resources.MovePerformer, Utilities.ToMoveStringRus(MoveCommand.Commands.Backward45CCW), moveBackward45CCW));
            shortcuts.Add(new Tuple<string, string, Keys>(Properties.Resources.MovePerformer, Utilities.ToMoveStringRus(MoveCommand.Commands.Rotate45CW), moveRotateCW)); //
            shortcuts.Add(new Tuple<string, string, Keys>(Properties.Resources.MovePerformer, Utilities.ToMoveStringRus(MoveCommand.Commands.Rotate45CCW), moveRotateCCW)); //

            shortcuts.Add(new Tuple<string, string, Keys>(Properties.Resources.ChargePerformer, Utilities.ToChargeStringRus(ChargeCommand.Commands.Refuel), chargeRefuel));
            shortcuts.Add(new Tuple<string, string, Keys>(Properties.Resources.ChargePerformer, Utilities.ToChargeStringRus(ChargeCommand.Commands.PressureX1), chargePressure)); //
            shortcuts.Add(new Tuple<string, string, Keys>(Properties.Resources.ChargePerformer, Utilities.ToChargeStringRus(ChargeCommand.Commands.Charge), chargeCharge));

            shortcuts.Add(new Tuple<string, string, Keys>(Properties.Resources.TurretPerformer, Utilities.ToTurretStringRus(TurretCommand.Commands.Up), turretUp));
            shortcuts.Add(new Tuple<string, string, Keys>(Properties.Resources.TurretPerformer, Utilities.ToTurretStringRus(TurretCommand.Commands.Down), turretDown));
            shortcuts.Add(new Tuple<string, string, Keys>(Properties.Resources.TurretPerformer, Utilities.ToTurretStringRus(TurretCommand.Commands.Shoot), turretShoot));
            shortcuts.Add(new Tuple<string, string, Keys>(Properties.Resources.TurretPerformer, Utilities.ToTurretStringRus(TurretCommand.Commands.Rotate45CW), turretRotateCW)); //
            shortcuts.Add(new Tuple<string, string, Keys>(Properties.Resources.TurretPerformer, Utilities.ToTurretStringRus(TurretCommand.Commands.Rotate45CCW), turretRotateCCW)); //

            shortcuts.Add(new Tuple<string, string, Keys>(string.Empty, Properties.Resources.RunAlgorithm, run));
            shortcuts.Add(new Tuple<string, string, Keys>(string.Empty, Properties.Resources.ReloadAlgorithm, reload));
            shortcuts.Add(new Tuple<string, string, Keys>(string.Empty, Properties.Resources.StepAlgorithm, step));
            shortcuts.Add(new Tuple<string, string, Keys>(string.Empty, Properties.Resources.ClearWholeAlgorithm, clearParallelAlgorithm));

            shortcuts.Add(new Tuple<string, string, Keys>(string.Empty, Properties.Resources.CancelSelection, clearSelection));
            shortcuts.Add(new Tuple<string, string, Keys>(string.Empty, Properties.Resources.DeleteAction, deleteAction));
            shortcuts.Add(new Tuple<string, string, Keys>(string.Empty, Properties.Resources.ClearTankAlgorithm, clearTankAlgorithm));

            return shortcuts;
        }
    }
}
