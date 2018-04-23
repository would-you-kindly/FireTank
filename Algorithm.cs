using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FireSafety
{
    [Serializable]
    public class Algorithm
    {
        // Классы для передачи параметров событий
        public class PerformNextActionEventArgs : EventArgs
        {
        }

        // События алгоритма
        public delegate void PerformNextActionEventHandler(object sender, PerformNextActionEventArgs e);
        public event PerformNextActionEventHandler NextActionPerforming;

        // Переменные алгоритма
        public List<Action> actions;
        [NonSerialized]
        public int currentAction;

        public Algorithm()
        {
            actions = new List<Action>();
            currentAction = 0;
        }

        public Action GetNextAction()
        {
            NextActionPerforming?.Invoke(this, new PerformNextActionEventArgs());

            return actions[currentAction++];
        }

        public bool HasActions()
        {
            return actions.Count != currentAction;
        }
    }
}
