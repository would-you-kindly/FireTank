namespace FireSafety
{
    public class WeaponAlreadyChargedError : Error
    {
        public WeaponAlreadyChargedError(Tank tank)
            : base()
        {
            message += $"Нельзя заряжать пушку, если она уже заряжена ({tank.ToString()}).";
        }

        public override string ToString()
        {
            return message;
        }
    }
}
