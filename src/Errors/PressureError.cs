namespace FireSafety
{
    public class PressureError : Error
    {
        public PressureError(Tank tank)
            : base()
        {
            message += $"Нельзя переполнять давление воды ({tank.ToString()}).";
        }

        public override string ToString()
        {
            return message;
        }
    }
}
