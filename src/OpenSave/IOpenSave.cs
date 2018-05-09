namespace FireSafety
{
    public interface IOpenSave
    {
        void SaveAlgorithm();
        ParallelAlgorithm OpenAlgorithm();
        Map OpenMap();
    }
}
