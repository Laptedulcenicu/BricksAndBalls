using Modules.Common;
using UnityEngine;

namespace Modules.Gameplay
{
    public class GameplaySceneController : MonoBehaviour
    {
        [SerializeField] private Transform inputControllerParent;
        [SerializeField] private InteractableController interactableController;
        [SerializeField] private Transform playerSpawnPoint;
        [SerializeField] private Transform obstaclesParent;

        private IInputController _inputController;
        public PlayerView Player { get; set; }
        public IUIController UIController { get; set; }

        public Transform PlayerSpawnPoint => playerSpawnPoint;
        
        public InteractableController InteractableController => interactableController;


        public void Initialize(IInputSource inputSource, IAudioService audioService, ISceneTransitionService sceneTransitionService, GameLoopEvents gameLoopEvents)
        {
            SetInputSource(inputSource);
            InitializeInteractableController(inputSource);
            InitializeObstacles(audioService);
            Player.Initialize(gameLoopEvents,audioService);
            sceneTransitionService.FadeOut();
        }

        private void InitializeObstacles(IAudioService audioService)
        {
            var obstaclesView = obstaclesParent.GetComponentsInChildren<ObstacleView>();
            foreach (var obstacleView in obstaclesView)
            {
                obstacleView.Initialize(audioService);
            }
        }

        private void SetInputSource(IInputSource inputSource)
        {
            _inputController = inputControllerParent.GetComponent<IInputController>();
            _inputController.Setup(inputSource);
        }

        private void InitializeInteractableController(IInputSource inputSource) =>
            interactableController.Initialize(inputSource, Player);
    }
}