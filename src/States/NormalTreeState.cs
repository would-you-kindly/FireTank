namespace FireSafety
{
    public class NormalTreeState : TreeState
    {
        public NormalTreeState()
        {
            currentTimeToSpread = 0;
        }

        public override void Water(Tree tree)
        {
            tree.state = new WetTreeState();
        }

        // Пытаемся поджечь дерево
        public override void Fire(Tree tree, int power)
        {
            // Если дерево в обычном состоянии, то оно начинает загораться
            if (tree.state.currentTimeToSpread == timeToSpread - (power - 1))
            {
                tree.state = new BurningTreeState();
            }
            else
            {
                tree.state.currentTimeToSpread++;
            }
        }

        public override void Burn(Tree tree)
        {
            // Empty method
        }
    }
}
