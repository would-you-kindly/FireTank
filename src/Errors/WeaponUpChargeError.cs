namespace FireSafety
{
    public class WeaponUpChargeError : Error
    {
        public WeaponUpChargeError(Tank tank)
            : base()
        {
            message += $"Нельзя заряжать пушку, если она поднята ({tank.ToString()}).";
        }

        public override string ToString()
        {
            return message;
        }
    }
}
