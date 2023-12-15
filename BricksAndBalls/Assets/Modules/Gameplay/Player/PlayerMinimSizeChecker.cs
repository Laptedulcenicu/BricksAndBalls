using UnityEngine;

namespace Modules.Gameplay
{
    public class PlayerMinimSizeChecker : MonoBehaviour
    {
        [SerializeField] private SizeSetter sizeSetter;
        [SerializeField] private float minimSize;

        private GameLoopEvents _gameLoopEvents;

        public void Initialize(GameLoopEvents gameLoopEvents)
        {
            _gameLoopEvents = gameLoopEvents;
        }

        public void CheckMinimSize()
        {
            if (sizeSetter.TransformModel.localScale.x <= minimSize)
            {
                _gameLoopEvents.OnFail?.Invoke();
            }
        }
    }
}