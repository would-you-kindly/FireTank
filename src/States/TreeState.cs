namespace FireSafety
{
    public abstract class TreeState
    {
        public static readonly int maxHitPoints = 10;
        public static readonly int timeToSpread = 3;
        public static readonly int timeToDryOut = 3;

        public int hitPoints = 10;
        public int currentTimeToSpread = 0;
        public int currentTimeToDryOut = 0;

        // Поливает дерево
        public abstract void Water(Tree tree);

        // Поджигает дерево
        public abstract void Fire(Tree tree, int power);

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

        // Проверяет, намочено ли дерево
        public bool IsWet()
        {
            return this is WetTreeState;
        }
    }
}