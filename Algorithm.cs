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
        public Queue<Action> actions;

        public Algorithm()
        {
            actions = new Queue<Action>();
        }

        public Action GetNextAction()
        {
            return actions.Dequeue();
        }

        public bool HasCommands()
        {
            return actions.Count != 0;
        }
    }
}
