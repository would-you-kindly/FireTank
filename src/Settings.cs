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
        private string connectionStringDefault = @"data source =.\sqlexpress; initial catalog = FireTankAdmin; integrated security = True;";
        //private string connectionStringDefault = ConfigurationManager.ConnectionStrings["LocalServer"].ConnectionString;
        //private string connectionStringDefault = @"Data Source=STUD-DBA\MSSQLSERVER16;Initial Catalog=FireTankAdmin;User ID=localuser;Password=654321";
        //private string connectionStringDefault = ConfigurationManager.ConnectionStrings["HSEServer"].ConnectionString;
        [XmlIgnore]
        [NonSerialized]
        public UserModel currentUser;
        [XmlIgnore]
        [NonSerialized]
        public MapModel currentMap;

        [XmlIgnore]
        [NonSerialized]
        private const Keys clearSelectionDefault = Keys.Escape;
        [XmlIgnore]
        [NonSerialized]
        private const Keys deleteActionDefault = Keys.Delete;
        [XmlIgnore]
        [NonSerialized]
        private const Keys clearTankAlgorithmDefault = Keys.Back;

        [XmlIgnore]
        [NonSerialized]
        private const Keys noneDefault = Keys.N;

        // Команды движения
        [XmlIgnore]
        [NonSerialized]
        private const Keys moveForwardDefault = Keys.F;
        [XmlIgnore]
        [NonSerialized]
        private const Keys moveBackwardDefault = Keys.B;
        [XmlIgnore]
        [NonSerialized]
        private const Keys moveForward45CWDefault = Keys.NumPad9;
        [XmlIgnore]
        [NonSerialized]
        private const Keys moveForward45CCWDefault = Keys.NumPad7;
        [XmlIgnore]
        [NonSerialized]
        private const Keys moveBackward45CWDefault = Keys.NumPad1;
        [XmlIgnore]
        [NonSerialized]
        private const Keys moveBackward45CCWDefault = Keys.NumPad3;
        // Короткие/долгие команды движения (короткое нажатие - 45, долгое нажатие - 90)
        [XmlIgnore]
        [NonSerialized]
        private const Keys moveRotateCWDefault = Keys.NumPad8;
        [XmlIgnore]
        [NonSerialized]
        private const Keys moveRotateCCWDefault = Keys.NumPad2;

        // Команды перезарядки
        [XmlIgnore]
        [NonSerialized]
        private const Keys chargeRefuelDefault = Keys.R;
        // Короткие/долгие команды перезарядки (короткое нажатие - увеличение давления на 1, долгое нажатие - увеличение давления на 2)
        [XmlIgnore]
        [NonSerialized]
        private const Keys chargePressureDefault = Keys.P;
        // Короткие/долгие команды перезарядки (короткое нажатие - заряд пушки 1, долгое нажатие - заряд пушки 2)
        [XmlIgnore]
        [NonSerialized]
        private const Keys chargeChargeDefault = Keys.C;

        // Команды башни
        [XmlIgnore]
        [NonSerialized]
        private const Keys turretUpDefault = Keys.U;
        [XmlIgnore]
        [NonSerialized]
        private const Keys turretDownDefault = Keys.D;
        // Короткие/долгие команды башни (короткое нажатие - выстрел из пушки 1, долгое нажатие - выстрел из пушки 2)
        [XmlIgnore]
        [NonSerialized]
        private const Keys turretShootDefault = Keys.S;
        // Короткие/долгие команды башни (короткое нажатие - 45 градусов, долгое нажатие - 90 градусов)
        [XmlIgnore]
        [NonSerialized]
        private const Keys turretRotateCWDefault = Keys.NumPad6;
        [XmlIgnore]
        [NonSerialized]
        private const Keys turretRotateCCWDefault = Keys.NumPad4;

        // Команды меню
        [XmlIgnore]
        [NonSerialized]
        private const Keys runDefault = Keys.F5;
        [XmlIgnore]
        [NonSerialized]
        private const Keys reloadDefault = Keys.F6;
        [XmlIgnore]
        [NonSerialized]
        private const Keys stepDefault = Keys.F7;
        [XmlIgnore]
        [NonSerialized]
        private const Keys clearDefault = Keys.F8;
        [XmlIgnore]
        [NonSerialized]
        public int timeToHold = 200;

        // Shortcuts
        public Keys none;

        public Keys moveForward;
        public Keys moveBackward;
        public Keys moveRotateCW;
        public Keys moveRotateCCW;
        public Keys moveForward45CW;
        public Keys moveForward45CCW;
        public Keys moveBackward45CW;
        public Keys moveBackward45CCW;

        public Keys chargePressure;
        public Keys chargeCharge;
        public Keys chargeRefuel;

        public Keys turretRotateCW;
        public Keys turretRotateCCW;
        public Keys turretUp;
        public Keys turretDown;
        public Keys turretShoot;

        public Keys run;
        public Keys reload;
        public Keys step;
        public Keys clearParallelAlgorithm;
        public Keys clearTankAlgorithm;
        public Keys clearSelection;
        public Keys deleteAction;

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

                // Загружаем настройки из файла
                instance.Load();

                // Создаем контекст базы данных
                instance.context = new ModelContext(instance.connectionString);

                instance.ShortcutUpdated += Settings_ShortcutUpdated;
                instance.Defaulted += Instance_Defaulted;
            }

            return instance;
        }

        private static void Instance_Defaulted(object sender, DefaultShortcutEventArgs e)
        {
            instance.Save();
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
            // Задаем команды водителя
            if (command == Properties.Resources.MoveCommandNone)
                none = key;
            if (command == Properties.Resources.MoveCommandForward)
                moveForward = key;
            if (command == Properties.Resources.MoveCommandBackward)
                moveBackward = key;
            if (command == Properties.Resources.MoveCommandRotate45CW &&
                performer == Properties.Resources.MovePerformer)
                moveRotateCW = key;
            if (command == Properties.Resources.MoveCommandRotate45CCW &&
                performer == Properties.Resources.MovePerformer)
                moveRotateCCW = key;
            if (command == Properties.Resources.MoveCommandForwardRotate45CW)
                moveForward45CW = key;
            if (command == Properties.Resources.MoveCommandForwardRotate45CCW)
                moveForward45CCW = key;
            if (command == Properties.Resources.MoveCommandBackwardRotate45CW)
                moveBackward45CW = key;
            if (command == Properties.Resources.MoveCommandBackwardRotate45CCW)
                moveBackward45CCW = key;

            // Задаем команды заряжающего
            if (command == Properties.Resources.ChargeCommandPressure1)
                chargePressure = key;
            if (command == Properties.Resources.ChargeCommandCharge)
                chargeCharge = key;
            if (command == Properties.Resources.ChargeCommandRefuel)
                chargeRefuel = key;

            // Задаем команды наводчика
            if (command == Properties.Resources.TurretCommandRotate45CW &&
                performer == Properties.Resources.TurretPerformer)
                turretRotateCW = key;
            if (command == Properties.Resources.TurretCommandRotate45CCW &&
                performer == Properties.Resources.TurretPerformer)
                turretRotateCCW = key;
            if (command == Properties.Resources.TurretCommandUp)
                turretUp = key;
            if (command == Properties.Resources.TurretCommandDown)
                turretDown = key;
            if (command == Properties.Resources.TurretCommandShoot)
                turretShoot = key;

            // Задаем команды алгоритма
            if (command == Properties.Resources.RunAlgorithm)
                run = key;
            if (command == Properties.Resources.ReloadAlgorithm)
                reload = key;
            if (command == Properties.Resources.StepAlgorithm)
                step = key;
            if (command == Properties.Resources.ClearWholeAlgorithm)
                clearParallelAlgorithm = key;
            if (command == Properties.Resources.ClearTankAlgorithm)
                clearTankAlgorithm = key;
            if (command == Properties.Resources.CancelSelection)
                clearSelection = key;
            if (command == Properties.Resources.DeleteAction)
                deleteAction = key;

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
            none = noneDefault;

            moveForward = moveForwardDefault;
            moveBackward = moveBackwardDefault;
            moveRotateCW = moveRotateCWDefault;
            moveRotateCCW = moveRotateCCWDefault;
            moveForward45CW = moveForward45CWDefault;
            moveForward45CCW = moveForward45CCWDefault;
            moveBackward45CW = moveBackward45CWDefault;
            moveBackward45CCW = moveBackward45CCWDefault;

            chargePressure = chargePressureDefault;
            chargeCharge = chargeChargeDefault;
            chargeRefuel = chargeRefuelDefault;

            turretRotateCW = turretRotateCWDefault;
            turretRotateCCW = turretRotateCCWDefault;
            turretUp = turretUpDefault;
            turretDown = turretDownDefault;
            turretShoot = turretShootDefault;

            run = runDefault;
            reload = reloadDefault;
            step = stepDefault;
            clearParallelAlgorithm = clearDefault;
            clearTankAlgorithm = clearTankAlgorithmDefault;
            clearSelection = clearSelectionDefault;
            deleteAction = deleteActionDefault;

            connectionString = connectionStringDefault;

            Defaulted?.Invoke(this, new DefaultShortcutEventArgs());
        }

        public List<Tuple<string, string, Keys>> GenerateShortcutList()
        {
            // Исполнитель, команда, shortcut
            List<Tuple<string, string, Keys>> shortcuts = new List<Tuple<string, string, Keys>>();

            shortcuts.Add(new Tuple<string, string, Keys>(Properties.Resources.AllPerformers, Utilities.ToMoveString(MoveCommand.Commands.None), none));

            shortcuts.Add(new Tuple<string, string, Keys>(Properties.Resources.MovePerformer, Utilities.ToMoveString(MoveCommand.Commands.Forward), moveForward));
            shortcuts.Add(new Tuple<string, string, Keys>(Properties.Resources.MovePerformer, Utilities.ToMoveString(MoveCommand.Commands.Backward), moveBackward));
            shortcuts.Add(new Tuple<string, string, Keys>(Properties.Resources.MovePerformer, Utilities.ToMoveString(MoveCommand.Commands.Rotate45CW), moveRotateCW)); //
            shortcuts.Add(new Tuple<string, string, Keys>(Properties.Resources.MovePerformer, Utilities.ToMoveString(MoveCommand.Commands.Rotate45CCW), moveRotateCCW)); //
            shortcuts.Add(new Tuple<string, string, Keys>(Properties.Resources.MovePerformer, Utilities.ToMoveString(MoveCommand.Commands.Forward45CW), moveForward45CW));
            shortcuts.Add(new Tuple<string, string, Keys>(Properties.Resources.MovePerformer, Utilities.ToMoveString(MoveCommand.Commands.Forward45CCW), moveForward45CCW));
            shortcuts.Add(new Tuple<string, string, Keys>(Properties.Resources.MovePerformer, Utilities.ToMoveString(MoveCommand.Commands.Backward45CW), moveBackward45CW));
            shortcuts.Add(new Tuple<string, string, Keys>(Properties.Resources.MovePerformer, Utilities.ToMoveString(MoveCommand.Commands.Backward45CCW), moveBackward45CCW));

            shortcuts.Add(new Tuple<string, string, Keys>(Properties.Resources.ChargePerformer, Utilities.ToChargeString(ChargeCommand.Commands.Charge), chargeCharge));
            shortcuts.Add(new Tuple<string, string, Keys>(Properties.Resources.ChargePerformer, Utilities.ToChargeString(ChargeCommand.Commands.PressureX1), chargePressure)); //
            shortcuts.Add(new Tuple<string, string, Keys>(Properties.Resources.ChargePerformer, Utilities.ToChargeString(ChargeCommand.Commands.Refuel), chargeRefuel));

            shortcuts.Add(new Tuple<string, string, Keys>(Properties.Resources.TurretPerformer, Utilities.ToTurretString(TurretCommand.Commands.Rotate45CW), turretRotateCW)); //
            shortcuts.Add(new Tuple<string, string, Keys>(Properties.Resources.TurretPerformer, Utilities.ToTurretString(TurretCommand.Commands.Rotate45CCW), turretRotateCCW)); //
            shortcuts.Add(new Tuple<string, string, Keys>(Properties.Resources.TurretPerformer, Utilities.ToTurretString(TurretCommand.Commands.Up), turretUp));
            shortcuts.Add(new Tuple<string, string, Keys>(Properties.Resources.TurretPerformer, Utilities.ToTurretString(TurretCommand.Commands.Down), turretDown));
            shortcuts.Add(new Tuple<string, string, Keys>(Properties.Resources.TurretPerformer, Utilities.ToTurretString(TurretCommand.Commands.Shoot), turretShoot));

            shortcuts.Add(new Tuple<string, string, Keys>(string.Empty, Properties.Resources.RunAlgorithm, run));
            shortcuts.Add(new Tuple<string, string, Keys>(string.Empty, Properties.Resources.ReloadAlgorithm, reload));
            shortcuts.Add(new Tuple<string, string, Keys>(string.Empty, Properties.Resources.StepAlgorithm, step));
            shortcuts.Add(new Tuple<string, string, Keys>(string.Empty, Properties.Resources.ClearWholeAlgorithm, clearParallelAlgorithm));
            shortcuts.Add(new Tuple<string, string, Keys>(string.Empty, Properties.Resources.ClearTankAlgorithm, clearTankAlgorithm));
            shortcuts.Add(new Tuple<string, string, Keys>(string.Empty, Properties.Resources.CancelSelection, clearSelection));
            shortcuts.Add(new Tuple<string, string, Keys>(string.Empty, Properties.Resources.DeleteAction, deleteAction));

            return shortcuts;
        }
    }
}
