using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace FireSafety
{
    [Serializable]
    public class Settings
    {
        [NonSerialized]
        private static Settings instance;

        [NonSerialized]
        private const string filename = "Settings.xml";
        [NonSerialized]
        private const string connectionStringDefault = @"data source =.\sqlexpress;initial catalog = FireSafetyAdmin; integrated security = True; MultipleActiveResultSets=True;App=EntityFramework";
        [NonSerialized]
        public static Guid currentUser;
        [NonSerialized]
        public static string currentUserName;
        [NonSerialized]
        public static string currentUserLastName;

        [NonSerialized]
        private const Keys clearSelectionDefault = Keys.Escape;
        [NonSerialized]
        private const Keys deleteActionDefault = Keys.Delete;

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
        private const Keys chargePressureDefault = Keys.P;

        // Команды башни
        [NonSerialized]
        private const Keys turretUpDefault = Keys.U;
        [NonSerialized]
        private const Keys turretDownDefault = Keys.D;
        [NonSerialized]
        private const Keys turretShootDefault = Keys.S;
        // Короткие/долгие команды башни (короткое нажатие - 45, долгое нажатие - 90)
        [NonSerialized]
        private const Keys turretRotateCWDefault = Keys.NumPad6;
        [NonSerialized]
        private const Keys turretRotateCCWDefault = Keys.NumPad4;

        // Время, в течение которого нужно держать клавишу, чтобы сработало долгое нажатие
        [NonSerialized]
        private const int timeToHoldDefault = 200;

        public Keys clearSelection;
        public Keys deleteAction;
        public Keys none;
        public Keys moveForward;
        public Keys moveBackward;
        public Keys moveForward45CW;
        public Keys moveForward45CCW;
        public Keys moveBackward45CW;
        public Keys moveBackward45CCW;
        public Keys moveRotateCW;
        public Keys moveRotateCCW;
        public Keys chargePressure;
        public Keys turretUp;
        public Keys turretDown;
        public Keys turretShoot;
        public Keys turretRotateCW;
        public Keys turretRotateCCW;
        public int timeToHold;
        public string connectionString;

        public Settings()
        {
            //Default();
            //Save();
        }

        public static Settings GetInstance()
        {
            if (instance == null)
            {
                instance = new Settings();

                // Грузим настройки из файла
                instance.Load();
            }

            return instance;
        }

        public void SetUser(Guid user, string name, string lastName)
        {
            currentUser = user;
            currentUserName = name;
            currentUserLastName = lastName;
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
            none = noneDefault;
            moveForward = moveForwardDefault;
            moveBackward = moveBackwardDefault;
            moveForward45CW = moveForward45CWDefault;
            moveForward45CCW = moveForward45CCWDefault;
            moveBackward45CW = moveBackward45CWDefault;
            moveBackward45CCW = moveBackward45CCWDefault;
            moveRotateCW = moveRotateCWDefault;
            moveRotateCCW = moveRotateCCWDefault;
            chargePressure = chargePressureDefault;
            turretUp = turretUpDefault;
            turretDown = turretDownDefault;
            turretShoot = turretShootDefault;
            turretRotateCW = turretRotateCWDefault;
            turretRotateCCW = turretRotateCCWDefault;
            timeToHold = timeToHoldDefault;
            connectionString = connectionStringDefault;
        }
    }
}
