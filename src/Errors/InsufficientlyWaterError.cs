namespace FireSafety
{
    public class InsufficientlyWaterError : Error
    {
        public InsufficientlyWaterError(Tank tank)
            : base()
        {
            message += $"Нельзя стрелять, если в запасе недостаточно воды ({tank.ToString()}).";
        }

        public override string ToString()
        {
            return message;
        }
    }
}
