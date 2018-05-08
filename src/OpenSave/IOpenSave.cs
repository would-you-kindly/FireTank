namespace FireSafety
{
    public interface IOpenSave
    {
        void SaveAlgorithm();
        ParallelAlgorithm OpenAlgorithm();
        void OpenMap();
    }
}
