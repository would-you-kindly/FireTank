namespace FireSafety
{
    public interface IFlammable
    {
        void Water();
        void Fire(int power);
        void Burn();
    }
}