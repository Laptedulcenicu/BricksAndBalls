using System.Collections.Generic;
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
        public List<EnemyView> Enemies { get; } = new();
        public IUIController UIController { get; set; }

        public Transform PlayerSpawnPoint => playerSpawnPoint;
        
        public InteractableController InteractableController => interactableController;


        public void Initialize(IInputSource inputSource, IAudioService audioService, ISceneTransitionService sceneTransitionService, GameLoopEvents gameLoopEvents)
        {
            SetInputSource(inputSource);
            InitializeInteractableController(inputSource);
  //          InitializeEnemies(audioService);
//            Player.Initialize(gameLoopEvents,killedEnemyChecker,audioService);
            sceneTransitionService.FadeOut();
        }

        private void InitializeEnemies(IAudioService audioService)
        {
            foreach (var enemy in Enemies)
            {
                enemy.Initialize(audioService);
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