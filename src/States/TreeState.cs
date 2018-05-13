namespace FireSafety
{
    public abstract class TreeState
    {
        public readonly int maxHitPoints = 10;
        public int hitPoints = 10;
        public readonly int timeToSpread = 3;
        public int currentTimeToSpread = 0;

        // Тушит дерево
        public abstract void Extinguish(Tree tree);

        // Поджигает дерево
        public abstract void Fire(Tree tree);

        // Сжигает дерево
        public abstract void Burn(Tree tree);

        // Проверяет, не горит ли дерево
        public bool IsNormal()
        {
            return this is NormalTreeState;
        }

        // Проверяет, горит ли дерево
        public bool IsBurning()
        {
            return this is BurningTreeState;
        }

        // Проверяет, сгорело ли дерево
        public bool IsBurned()
        {
            return this is BurnedTreeState;
        }
    }
}