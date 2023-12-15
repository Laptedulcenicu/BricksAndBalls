using Modules.Common;
using Modules.Core.Scripts.Utilities;
using Modules.Gameplay;
using UnityEngine.SceneManagement;

namespace Modules.Core
{
    public class GameLoopState : IState
    {
        private readonly ProgressData _progressData;
        private readonly IInputSource _inputSource;
        private readonly IAudioService _audioService;
        private readonly GameStateMachine _gameStateMachine;
        private readonly ISceneTransitionService _sceneTransitionService;
        private readonly Level _level;

        private GameLoopEvents _gameLoopEvents;
        private SizeConverter _sizeConverter;
        private KilledEnemyChecker _killedEnemyChecker;

        public GameLoopState(Level level, IInputSource inputSource, IAudioService audioService,
            ISceneTransitionService sceneTransitionService, GameStateMachine gameStateMachine)
        {
            _level = level;
            _inputSource = inputSource;
            _audioService = audioService;
            _gameStateMachine = gameStateMachine;
            _sceneTransitionService = sceneTransitionService;
        }

        private void RestartLevel()
        {
            _gameStateMachine.Enter<LoadLevelState>();
        }

        public void Enter()
        {
            // _gameLoopEvents = new GameLoopEvents();
            // var scene = SceneManager.GetActiveScene();
            // var sceneController = scene.GetComponent<GameplaySceneController>();
            // _sizeConverter = new SizeConverter(sceneController.Player, sceneController.LineView);
            // _killedEnemyChecker = new KilledEnemyChecker(sceneController.Player.PlayerMover, sceneController.LineView.EnemyDetector, sceneController.InteractableController);
            // InitializeGameplayUI(sceneController.UIController, sceneController.InteractableController);
            //
            // sceneController.Initialize(_inputSource, _audioService, _sceneTransitionService, _gameLoopEvents,
            //     _sizeConverter, _killedEnemyChecker);
        }

        private void InitializeGameplayUI(IUIController uiController, InteractableController interactableController)
        {
            uiController.Initialize(_level.CurrentLevel);
            uiController.OnRestart += RestartLevel;
            uiController.OnNextLevel += RestartLevel;
            uiController.OnPlay += uiController.Play;
            _gameLoopEvents.OnWin += () => Win(uiController, interactableController);
            _gameLoopEvents.OnFail += () => Fail(uiController, interactableController);
        }

        private void Fail(IUIController uiController, InteractableController interactableController)
        {
            interactableController.CanControl = false;
            uiController.ActivateLosePanel();
        }

        private void Win(IUIController uiController, InteractableController interactableController)
        {
            _level.CurrentLevel += 1;
            interactableController.CanControl = false;
            uiController.ActivateWinPanel();
        }
    }
}