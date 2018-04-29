﻿using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace FireSafety
{
    [Serializable]
    //[XmlRoot("ParallelAlgorithm")]
    public class Algorithm
    {
        // Классы для передачи параметров событий
        public class PerformNextActionEventArgs : EventArgs
        {
        }
        public class ExecuteEventArgs : EventArgs
        {
        }

        // События алгоритма
        public delegate void PerformNextActionEventHandler(object sender, PerformNextActionEventArgs e);
        public delegate void ExecuteEventHandler(object sender, ExecuteEventArgs e);
        public event PerformNextActionEventHandler NextActionPerforming;
        public event ExecuteEventHandler Executed;

        // Переменные алгоритма
        [XmlArray("Actions"), XmlArrayItem(typeof(Action), ElementName = "Action")]
        public List<Action> actions;
        [XmlIgnore]
        [NonSerialized]
        public int currentAction;

        public Algorithm()
        {
            actions = new List<Action>();
            currentAction = 0;

            Executed += ParallelAlgorithmController.ParallelAlgorithmController_AlgorithmExecuted;
        }

        public Action GetNextAction()
        {
            NextActionPerforming?.Invoke(this, new PerformNextActionEventArgs());

            return actions[currentAction++];
        }

        public bool HasActions()
        {
            //Executed?.Invoke(this, new ExecuteEventArgs());

            return actions.Count != currentAction;
        }
    }
}
