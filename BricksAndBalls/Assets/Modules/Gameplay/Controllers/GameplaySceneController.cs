using System.Collections.Generic;
using Modules.Common;
using UnityEngine;

namespace Modules.Gameplay
{
    public class GameplaySceneController : MonoBehaviour
    {
        [SerializeField] private Transform inputControllerParent;
        [SerializeField] private InteractableController interactableController;
        [SerializeField] private Transform playerMarker;
        [SerializeField] private Transform gateMarker;
        [SerializeField] private Transform lineViewMarker;
        [SerializeField] private Transform[] enemiesMarkers;

        private IInputController _inputController;
        public PlayerView Player { get; set; }
        public GateView GateView { get; set; }
        public LineView LineView { get; set; }
        public List<EnemyView> Enemies { get; } = new();
        public IUIController UIController { get; set; }

        public Transform PlayerMarker => playerMarker;

        public Transform GateMarker => gateMarker;

        public Transform LineViewMarker => lineViewMarker;

        public Transform[] EnemiesMarkers => enemiesMarkers;

        public InteractableController InteractableController => interactableController;


        public void Initialize(IInputSource inputSource, IAudioService audioService, ISceneTransitionService sceneTransitionService, GameLoopEvents gameLoopEvents, SizeConverter sizeConverter,
            KilledEnemyChecker killedEnemyChecker)
        {
            SetInputSource(inputSource);
            InitializeInteractableController(inputSource, sizeConverter);
            InitializeEnemies(audioService);
            GateView.Initialize(audioService, gameLoopEvents);
            Player.Initialize(gameLoopEvents,killedEnemyChecker,audioService);
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

        private void InitializeInteractableController(IInputSource inputSource, SizeConverter sizeConverter) =>
            interactableController.Initialize(inputSource, sizeConverter, Player);
    }
}