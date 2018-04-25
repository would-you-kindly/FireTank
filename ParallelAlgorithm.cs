using MoreLinq;
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
        public class RemoveActionEventArgs : EventArgs
        {
        }
        public class ClearEventArgs : EventArgs
        {
        }
        public class SaveEventArgs : EventArgs
        {
        }
        public class LoadEventArgs : EventArgs
        {
        }
        public class PerformNextActionEventArgs : EventArgs
        {
        }
        public class ExecuteEventArgs : EventArgs
        {
        }

        // События параллельного алгоритма
        public delegate void AddActionEventHandler(object sender, AddActionEventArgs e);
        public delegate void ChangeCommandEventHandler(object sender, ChangeCommandEventArgs e);
        public delegate void RemoveActionEventHandler(object sender, RemoveActionEventArgs e);
        public delegate void ClearEventHandler(object sender, ClearEventArgs e);
        public delegate void SaveEventHandler(object sender, SaveEventArgs e);
        public delegate void LoadEventHandler(object sender, LoadEventArgs e);
        public delegate void PerformNexActionEventHandler(object sender, PerformNextActionEventArgs e);
        public delegate void ExecuteEventHandler(object sender, ExecuteEventArgs e);
        public event AddActionEventHandler ActionAdded;
        public event ChangeCommandEventHandler CommandChanged;
        public event RemoveActionEventHandler ActionRemoved;
        public event ClearEventHandler Cleared;
        public event SaveEventHandler Saved;
        public event LoadEventHandler Loaded;
        public event PerformNexActionEventHandler NextActionPerforming;
        public event ExecuteEventHandler Executed;

        // Переменные параллельного алгоритма
        public List<Algorithm> algorithms;
        [NonSerialized]
        public bool running;
        [NonSerialized]
        public bool step;
        [NonSerialized]
        public int currentAction;

        private ParallelAlgorithm()
        {
            algorithms = new List<Algorithm>();
            running = false;
            step = false;
            currentAction = 0;

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

                // TODO: Модель начинает знать что-то о контроллере - плохо
                // При загрузке алгоритма заполняем таблицу данными алгоритма
                instance.Loaded += ParallelAlgorithmController.ParallelAlgorithmController_Loaded;
                // При очистке алгоритма очищаем таблицу
                instance.Cleared += ParallelAlgorithmController.ParallelAlgorithmController_Cleared;
                // При переходе алгоритма к следующему шагу подсвечиваем соответствующие строки таблицы
                instance.NextActionPerforming += ParallelAlgorithmController.ParallelAlgorithmController_NextActionPerforming;
                // При окончании работы алгоритма перезапускаем алгоритм и отключаем подсветку строк в таблице
                instance.Executed += ParallelAlgorithmController.ParallelAlgorithmController_Executed;

                foreach (Algorithm algorithm in instance.algorithms)
                {
                    algorithm.NextActionPerforming += Algorithm_NextActionPerforming;
                }
                instance.NextActionPerforming += Instance_NextActionPerforming;
            }

            return instance;
        }

        private static void Instance_NextActionPerforming(object sender, PerformNextActionEventArgs e)
        {
            //if (instance.currentAction == instance.algorithms.Max(algo => algo.actions.Count) - 1)
            //{
            //    instance.Executed?.Invoke(instance, new ExecuteEventArgs());
            //}
        }

        private static void Algorithm_NextActionPerforming(object sender, Algorithm.PerformNextActionEventArgs e)
        {
            // Если currentAction всех алгоритмов, которые еще выполняются равны, то берем currentAction самого длинного алгоритма
            if (instance.algorithms.Where(algo => algo.HasActions()).Select(algo => algo.currentAction).Distinct().Count() == 1)
            {
                instance.currentAction = instance.algorithms.MaxBy(algo => algo.actions.Count).currentAction;
            }

            instance.NextActionPerforming?.Invoke(instance, new PerformNextActionEventArgs());
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

        public void DeleteAction(int algorithmNumber, int actionNumber)
        {
            algorithms[algorithmNumber].actions.RemoveAt(actionNumber);

            ActionRemoved?.Invoke(this, new RemoveActionEventArgs());
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

            Saved?.Invoke(this, new SaveEventArgs());
        }

        public void Run()
        {
            foreach (Algorithm algorithm in algorithms)
            {
                algorithm.currentAction = 0;
            }

            currentAction = 0;
            running = true;
        }

        public void Stop()
        {
            running = false;
        }

        public void Reload()
        {
            foreach (Algorithm algorithm in algorithms)
            {
                algorithm.currentAction = 0;
            }

            currentAction = 0;
            running = false;
        }

        public double ComputeEfficiency(double mapWidth, double mapHeight, double initiallyBurningTrees,
            double totalTrees, double burnedTrees)
        {
            double mapComplexity = (initiallyBurningTrees / totalTrees) * (mapWidth * mapHeight);
            double algorithmEfficiency = instance.algorithms.Sum(algo => algo.actions.Count);
            double result = mapComplexity * algorithmEfficiency / (1 + burnedTrees);

            return result;
        }

        public void Execute()
        {
            // TODO: Контролируем конфликты
            throw new NotImplementedException();
        }

        public void Clear()
        {
            // TODO: Нужно ли чистить????? instance = null, а в памяти весь хлам остался
            instance = null;

            Cleared?.Invoke(this, new ClearEventArgs());
        }
    }
}
