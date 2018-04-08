using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FireSafety
{
    class Algorithm
    {
        public Queue<Action> actions;

        public Algorithm()
        {
            actions = new Queue<Action>();
        }

        public Action GetNextAction()
        {
            Action action = actions.Dequeue();

            return action;
        }

        public bool HasCommands()
        {
            return actions.Count != 0;
        }
    }
}
