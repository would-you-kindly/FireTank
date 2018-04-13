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
        public List<Action> Actions { get; set; }

        public Algorithm()
        {
            Actions = new List<Action>();
        }

        public Action GetNextAction()
        {
            Action action = Actions[Actions.Count - 1];
            Actions.RemoveAt(Actions.Count - 1);

            return action;
        }

        public bool HasCommands()
        {
            return Actions.Count != 0;
        }
    }
}
