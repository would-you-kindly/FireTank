using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    class BurningTreeState : TreeState
    {
        public override void Extinguish(Tree tree)
        {
            tree.state = new NormalTreeState();
        }

        public override void Fire(Tree tree)
        {
            // Empty method
        }

        public override void Burn(Tree tree)
        {
            tree.state = new BurnedTreeState();
        }
    }
}
