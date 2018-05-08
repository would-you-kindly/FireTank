namespace FireSafety
{
    public class NearLakeError : Error
    {
        public NearLakeError(Tank tank)
        : base()
        {
            message += $"Нельзя пополнять запасы воды, не находясь рядом с озером ({tank.ToString()}).";
        }

        public override string ToString()
        {
            return message;
        }
    }
}
