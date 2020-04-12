namespace RuntimeCode.Interfaces
{
    public interface IInitializable
    {
        bool IsInitialized { get; }
        void Initialize();
    }
}