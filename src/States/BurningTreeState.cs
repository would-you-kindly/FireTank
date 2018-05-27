namespace FireSafety
{
    class BurningTreeState : TreeState
    {
        public BurningTreeState()
        {
            // Empty method
        }

        public override void Water(Tree tree)
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
