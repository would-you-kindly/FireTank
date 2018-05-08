using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace FireSafety
{
    public class NormalTreeState : TreeState
    {
        public NormalTreeState()
        {
            currentTimeToSpread = 0;
        }

        public override void Extinguish(Tree tree)
        {
            // Empty method
        }

        public override void Fire(Tree tree)
        {
            if (currentTimeToSpread == timeToSpread)
            {
                tree.state = new BurningTreeState();
            }
            else
            {
                currentTimeToSpread++;
            }
        }

        public override void Burn(Tree tree)
        {
            // Empty method
        }
    }
}
