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
        public Queue<Action> Actions { get; set; }

        public Algorithm()
        {
            Actions = new Queue<Action>();
        }

        public Action GetNextAction()
        {
            Action action = Actions.Dequeue();

            return action;
        }

        public bool HasCommands()
        {
            return Actions.Count != 0;
        }
    }
}
