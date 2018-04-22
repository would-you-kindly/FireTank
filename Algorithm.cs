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
        public List<Action> actions;

        public Algorithm()
        {
            actions = new List<Action>();
        }

        public Action GetNextAction()
        {
            Action action = actions.Last();
            actions.RemoveAt(actions.Count - 1);

            return action;
        }

        public bool HasCommands()
        {
            return actions.Count != 0;
        }
    }
}
