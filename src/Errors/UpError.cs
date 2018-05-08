namespace FireSafety
{
    public class UpError : Error
    {
        public UpError(Tank tank)
            : base()
        {
            message += $"Нельзя поднимать пушку, если она уже поднята ({tank.ToString()}).";
        }

        public override string ToString()
        {
            return message;
        }
    }
}
