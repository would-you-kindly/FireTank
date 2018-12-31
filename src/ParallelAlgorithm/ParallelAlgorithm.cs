using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace FireSafety
{
    [Serializable]
    public class ParallelAlgorithm
    {
        [XmlIgnore]
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
        public class ChangePlanItemEventArgs : EventArgs
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
        public class ReloadEventArgs : EventArgs
        {
        }
        public class PerformNextActionEventArgs : EventArgs
        {
        }

        // События параллельного алгоритма
        public delegate void AddActionEventHandler(object sender, AddActionEventArgs e);
        public delegate void ChangeCommandEventHandler(object sender, ChangeCommandEventArgs e);
        public delegate void RemoveActionEventHandler(object sender, RemoveActionEventArgs e);
        public delegate void PlanItemChangedEventHandler(object sender, ChangePlanItemEventArgs e);
        public delegate void ClearEventHandler(object sender, ClearEventArgs e);
        public delegate void SaveEventHandler(object sender, SaveEventArgs e);
        public delegate void LoadEventHandler(object sender, LoadEventArgs e);
        public delegate void ReloadEventHandler(object sender, ReloadEventArgs e);
        public delegate void PerformNexActionEventHandler(object sender, PerformNextActionEventArgs e);
        public event AddActionEventHandler ActionAdded;
        public event ChangeCommandEventHandler CommandChanged;
        public event RemoveActionEventHandler ActionRemoved;
        public event PlanItemChangedEventHandler PlanItemChanged;
        public event ClearEventHandler Cleared;
        public event SaveEventHandler Saving;
        public event LoadEventHandler Loaded;
        public event ReloadEventHandler Reloaded;
        public event PerformNexActionEventHandler NextActionPerforming;

        // Переменные параллельного алгоритма
        [XmlArray("Algorithms"), XmlArrayItem(typeof(Algorithm), ElementName = "Algorithm")]
        public List<Algorithm> algorithms;
        [XmlElement(Namespace = "Plan")]
        public Plan plan;

        [XmlIgnore]
        [NonSerialized]
        public Errors errors;
        [XmlIgnore]
        [NonSerialized]
        public bool running;
        [XmlIgnore]
        [NonSerialized]
        public bool step;
        [XmlIgnore]
        [NonSerialized]
        public int currentAction;
        [XmlIgnore]
        [NonSerialized]
        IOpenSave openSave;

        private ParallelAlgorithm()
        {
            algorithms = new List<Algorithm>();
            //plan = new Plan();
            errors = new Errors();
            running = false;
            step = false;
            currentAction = 0;

            for (int i = 0; i < Utilities.GetInstance().TANKS_COUNT; i++)
            {
                algorithms.Add(new Algorithm());
            }

            // TODO: Модель начинает знать что-то о контроллере - плохо
            // При загрузке алгоритма заполняем таблицу данными алгоритма
            Loaded += ParallelAlgorithmController.ParallelAlgorithmController_Loaded;
            // При очистке алгоритма очищаем таблицу
            Cleared += ParallelAlgorithmController.ParallelAlgorithmController_Cleared;
            // При переходе алгоритма к следующему шагу подсвечиваем соответствующие строки таблицы
            NextActionPerforming += ParallelAlgorithmController.ParallelAlgorithmController_NextActionPerforming;
            // При перезагрузке алгоритма отключаем подсветку строк в таблице
            Reloaded += ParallelAlgorithmController.ParallelAlgorithmController_Reloaded;
            Saving += ParallelAlgorithmController.ParallelAlgorithmController_Saving;
            Cleared += ParallelAlgorithmController.ParallelAlgorithm_Cleared;

            foreach (Algorithm algorithm in algorithms)
            {
                algorithm.NextActionPerforming += Algorithm_NextActionPerforming;
            }
            NextActionPerforming += Instance_NextActionPerforming;
        }

        public static ParallelAlgorithm GetInstance()
        {
            if (instance == null)
            {
                instance = new ParallelAlgorithm();
            }

            return instance;
        }

        public void SetNextAction()
        {
            currentAction++;

            instance.NextActionPerforming?.Invoke(instance, new PerformNextActionEventArgs());
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
            //if (instance.algorithms.Where(algo => algo.HasActions()).Select(algo => algo.currentAction).Distinct().Count() == 1)
            //{
            //    instance.currentAction = instance.algorithms.MaxBy(algo => algo.actions.Count).currentAction;
            //}

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

        public void InsertAction(int algorithmNumber, Action action, int index)
        {
            algorithms[algorithmNumber].actions.Insert(index, action);

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

        public void SetPlanItem(int algorithmNumber, int actionNumber, uint planItem)
        {
            algorithms[algorithmNumber].actions[actionNumber].planItem = planItem;

            PlanItemChanged?.Invoke(this, new ChangePlanItemEventArgs());
        }

        public void LoadAlgorithm(IOpenSave openSave)
        {
            instance = openSave.OpenAlgorithm();

            Loaded?.Invoke(this, new LoadEventArgs());
        }

        public void SaveAlgorithm(IOpenSave openSave)
        {
            Saving?.Invoke(this, new SaveEventArgs());

            openSave.SaveAlgorithm();
        }

        public void Run()
        {
            foreach (Algorithm algorithm in algorithms)
            {
                algorithm.currentAction = 0;
            }

            running = true;
            step = false;
            currentAction = 0;
        }

        public void Step()
        {
            running = false;
            step = true;
        }

        public void Reload()
        {
            foreach (Algorithm algorithm in algorithms)
            {
                algorithm.currentAction = 0;
            }

            running = false;
            step = false;
            currentAction = 0;

            Reloaded?.Invoke(this, new ReloadEventArgs());
        }

        public bool IsExecuted()
        {
            return instance.algorithms.Where(algo => !algo.blocked).All(algo => algo.currentAction >= algo.actions.Count);
        }

        public double ComputeEfficiency(double mapWidth, double mapHeight, double initiallyBurningTrees,
            double totalTrees, double burnedTrees)
        {
            double kTrees = totalTrees / (mapWidth * mapHeight);
            double kFire = initiallyBurningTrees / (mapWidth * mapHeight);
            double mapComplexity = kTrees * kFire;
            double algorithmLength = instance.algorithms.Sum(algo => algo.actions.Count);
            double result = (algorithmLength / (1 + burnedTrees)) / mapComplexity;
            //double result = 100 * mapComplexity / (algorithmLength * burnedTrees + 1);

            return result;
        }

        public void Clear()
        {
            foreach (Algorithm algorithm in instance.algorithms)
            {
                algorithm.actions.Clear();
            }

            // TODO: Нужно ли чистить????? instance = null, а в памяти весь хлам остался
            instance = null;

            Cleared?.Invoke(this, new ClearEventArgs());
        }
    }
}
