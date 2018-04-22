using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    [Serializable]
    public class ParallelAlgorithm
    {
        [NonSerialized]
        private static ParallelAlgorithm instance;

        // Классы для передачи параметров событий
        public class AddActionEventArgs : EventArgs
        {
        }
        public class ChangeCommandEventArgs : EventArgs
        {
        }
        public class SaveEventArgs : EventArgs
        {
        }
        public class LoadEventArgs : EventArgs
        {
        }

        // События параллельного алгоритма
        public delegate void AddActionEventHandler(object sender, AddActionEventArgs e);
        public delegate void ChangeCommandEventHandler(object sender, ChangeCommandEventArgs e);
        public delegate void SaveEventHandler(object sender, LoadEventArgs e);
        public delegate void LoadEventHandler(object sender, LoadEventArgs e);
        public event AddActionEventHandler ActionAdded;
        public event ChangeCommandEventHandler CommandChanged;
        public event SaveEventHandler Saved;
        public event LoadEventHandler Loaded;
        
        // Переменные параллельного алгоритма
        public List<Algorithm> algorithms;

        private ParallelAlgorithm()
        {
            algorithms = new List<Algorithm>();

            // Создаем алгоритмы сразу для максимального количества танков
            for (int i = 0; i < Utilities.MAX_TANKS_COUNT; i++)
            {
                algorithms.Add(new Algorithm());
            }
        }

        public static ParallelAlgorithm GetInstance()
        {
            if (instance == null)
            {
                instance = new ParallelAlgorithm();

                // При загрузке алгоритма заполняем таблицу данными алгоритма
                instance.Loaded += ParallelAlgorithmController.ParallelAlgorithmController_Loaded;
            }

            return instance;
        }

        public Algorithm this[int index]
        {
            get
            {
                return algorithms[index];
            }
            set
            {
                algorithms[index] = value;
            }
        }

        public void AddAction(int algorithmNumber, Action action)
        {
            algorithms[algorithmNumber].actions.Add(action);

            ActionAdded?.Invoke(this, new AddActionEventArgs());
        }

        public void ChangeCommand(int algorithmNumber, int actionNumber, int commandNumber, Command command)
        {
            algorithms[algorithmNumber].actions[actionNumber].commands[commandNumber] = command;

            CommandChanged?.Invoke(this, new ChangeCommandEventArgs());
        }

        public void Load(string filename)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                instance = (ParallelAlgorithm)formatter.Deserialize(fs);
            }

            Loaded?.Invoke(this, new LoadEventArgs());
        }
        
        public void Save(string filename)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(fs, this);
            }

            Saved?.Invoke(this, new LoadEventArgs());
        }

        public void Execute()
        {
            // TODO: Контролируем конфликты
            throw new NotImplementedException();
        }

        public void Clear()
        {
            // TODO: Нужно ли чистить?????
            instance = null;
        }
    }
}
