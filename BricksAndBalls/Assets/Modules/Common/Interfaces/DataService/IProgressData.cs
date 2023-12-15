namespace Modules.Common
{
    public interface IProgressData : ILifecycleDelegate
    {
        Level Level { get; }

        void SaveProgress();

        void LoadProgress();
    }
}