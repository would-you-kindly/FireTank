namespace FireSafety
{
    public class LeftMapError : Error
    {
        public LeftMapError(Tank tank)
            : base()
        {
            message += $"{tank.ToString()} покинул пределы карты.";
        }

        public override string ToString()
        {
            return message;
        }
    }
}
