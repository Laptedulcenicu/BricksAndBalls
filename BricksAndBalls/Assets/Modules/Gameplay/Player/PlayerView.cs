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
        [SerializeField] private GameObject reflectionLine;

        public PlayerShoot PlayerShoot => playerShoot;

        public SizeSetter SizeSetter => sizeSetter;

        public PlayerMinimSizeChecker MinimSizeChecker => playerMinimSizeChecker;

        public PlayerMover PlayerMover => playerMover;

        public GameObject ReflectionLine => reflectionLine;

        public void Initialize(GameLoopEvents gameLoopEvents, KilledEnemyChecker killedEnemyChecker, IAudioService audioService)
        {
            // playerMinimSizeChecker.Initialize(gameLoopEvents);
            // playerShoot.Initialize(killedEnemyChecker,audioService);
            // triggerObserver.TriggerEnter += TriggerEnter;
        }
        
    }
}