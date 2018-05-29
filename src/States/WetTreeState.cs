using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FireSafety
{
    public class WetTreeState : TreeState
    {
        public WetTreeState()
        {
            currentTimeToDryOut = 0;
        }

        public override void Burn(Tree tree)
        {
            // Empty method
        }

        public override void Water(Tree tree)
        {
            tree.state.currentTimeToDryOut = 0;
        }

        public override void Fire(Tree tree, int power)
        {
            // Если дерево намочено, то оно начинает сохнуть
            if (tree.state.currentTimeToDryOut == timeToDryOut - (power - 1))
            {
                tree.state = new NormalTreeState();
            }
            else
            {
                tree.state.currentTimeToDryOut++;
            }
        }
    }
}
