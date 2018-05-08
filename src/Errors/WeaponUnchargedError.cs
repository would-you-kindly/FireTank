namespace FireSafety
{
    public class WeaponUnchargedError : Error
    {
        public WeaponUnchargedError(Tank tank)
            : base()
        {
            message += $"Нельзя стрелять из пушки, если она еще не заряжена ({tank.ToString()}).";
        }

        public override string ToString()
        {
            return message;
        }
    }
}
