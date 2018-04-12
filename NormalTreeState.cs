using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    class NormalTreeState : TreeState
    {
        public override void Extinguish(Tree tree)
        {
            // Empty method
        }

        public override void Fire(Tree tree)
        {
            tree.state = new BurningTreeState();
        }

        public override void Burn(Tree tree)
        {
            // Empty method
        }
    }
}
