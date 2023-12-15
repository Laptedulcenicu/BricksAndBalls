using System;

namespace Modules.Common
{
    public interface IUIController
    {
        event Action OnPlay;
        event Action OnNextLevel;
        event Action OnRestart;

        void Initialize(int level);
        void Play();
        void ActivateLosePanel();
        void ActivateWinPanel();
    }
}