namespace FireSafety
{
    public class DownError : Error
    {
        public DownError(Tank tank)
            : base()
        {
            message += $"Нельзя опускать пушку, если она уже опущена ({tank.ToString()}).";
        }

        public override string ToString()
        {
            return message;
        }
    }
}
