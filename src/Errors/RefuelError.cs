namespace FireSafety
{
    public class RefuelError : Error
    {
        public RefuelError(Tank tank)
        : base()
        {
            message += $"Нельзя переполнять запасы воды ({tank.ToString()}).";
        }

        public override string ToString()
        {
            return message;
        }
    }
}
