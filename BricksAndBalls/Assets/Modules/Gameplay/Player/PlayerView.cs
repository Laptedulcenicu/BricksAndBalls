using Modules.Common;
using UnityEngine;

namespace Modules.Gameplay
{
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private TriggerObserver triggerObserver;
        [SerializeField] private PlayerMover playerMover;
        [SerializeField] private SizeSetter sizeSetter;
        [SerializeField] private PlayerShoot playerShoot;
        [SerializeField] private PlayerMinimSizeChecker playerMinimSizeChecker;

        public PlayerShoot PlayerShoot => playerShoot;

        public SizeSetter SizeSetter => sizeSetter;

        public PlayerMinimSizeChecker MinimSizeChecker => playerMinimSizeChecker;

        public PlayerMover PlayerMover => playerMover;

        public void Initialize(GameLoopEvents gameLoopEvents, KilledEnemyChecker killedEnemyChecker, IAudioService audioService)
        {
            playerMinimSizeChecker.Initialize(gameLoopEvents);
            playerShoot.Initialize(killedEnemyChecker,audioService);
            triggerObserver.TriggerEnter += TriggerEnter;
        }

        private void TriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Gate))
            {
                if (!other.TryGetComponent(out IInteractable interactable)) return;
                interactable.Interact();
            }
        }
    }
}