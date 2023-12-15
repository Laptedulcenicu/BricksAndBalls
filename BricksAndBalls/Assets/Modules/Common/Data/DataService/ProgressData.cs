using System.Collections.Generic;
using Modules.Services.Common;
using SW.Modules.Services.PersistenceService;

namespace Modules.Common
{
    public class ProgressData : IProgressData
    {
        private readonly Level _level = new();
        private readonly IPersistent _persistent;

        public ProgressData(IPersistent persistent)
        {
            _persistent = persistent;
        }

        public Level Level => _level;

        public void OnApplicationQuit() => SaveProgress();

        public void OnApplicationFocus(bool hasFocus) => SaveProgress();

        public void OnApplicationPause(bool isPaused) => SaveProgress();

        public void SaveProgress()
        {
            var currentSavData = new Dictionary<string, ISaveModel>()
            {
                { _level.Key, _level }
            };

            _persistent.SavePersistantData(currentSavData);
        }

        public void LoadProgress()
        {
            var levelLoaded = _persistent.GetPersistentData(_level.Key);
            if (levelLoaded == null)
            {
                return;
            }

            _level.CurrentLevel = ((Level)levelLoaded).CurrentLevel;
        }
    }
}