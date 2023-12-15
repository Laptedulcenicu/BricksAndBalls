using Modules.Common;
using Modules.Core.Scripts.Utilities;
using Modules.Gameplay;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Modules.Core
{
    public class LoadLevelState : IState
    {
        private const string k_SceneName = "Lv 1";

        private readonly IUIFactory _uiFactory;
        private readonly IAudioService _audioService;
        private readonly ISceneFactory _sceneFactory;
        private readonly ISceneTransitionService _transitionService;
        private readonly GameStateMachine _gameStateMachine;

        public LoadLevelState(IAudioService audioService, ISceneFactory sceneFactory, IUIFactory uiFactory,
            ISceneTransitionService sceneTransitionService, GameStateMachine gameStateMachine)
        {
            _uiFactory = uiFactory;
            _audioService = audioService;
            _sceneFactory = sceneFactory;
            _transitionService = sceneTransitionService;
            _gameStateMachine = gameStateMachine;
        }


        public void Enter()
        {
            _transitionService.ChangeScene(k_SceneName, SceneLoaded);
        }

        private void SceneLoaded()
        {
            var scene = SceneManager.GetActiveScene();
          //  var sceneController = scene.GetComponent<GameplaySceneController>();

         //   InitScene(sceneController);
         //   InitUI(sceneController);

            _gameStateMachine.Enter<GameLoopState>();
        }

        private void InitUI(GameplaySceneController sceneController)
        {
            var ui = _uiFactory.CreateUI();
            sceneController.UIController = ui.GetComponent<IUIController>();
        }

        private void InitScene(GameplaySceneController sceneController)
        {
            InitPlayer(sceneController);
            InitLineView(sceneController);
            InitGate(sceneController);
            InitEnemies(sceneController);
        }

        private void InitPlayer(GameplaySceneController sceneController)
        {
            var player = _sceneFactory.CreatePlayer();
            sceneController.Player = player.GetComponent<PlayerView>();
            InitObject(player.transform, sceneController.PlayerMarker);
        }


        private void InitLineView(GameplaySceneController sceneController)
        {
            var lineView = _sceneFactory.CreateLineView();
            sceneController.LineView = lineView.GetComponent<LineView>();
            InitObject(lineView.transform, sceneController.LineViewMarker);
        }

        private void InitGate(GameplaySceneController sceneController)
        {
            var gate = _sceneFactory.CreateGate();
            sceneController.GateView = gate.GetComponent<GateView>();
            InitObject(gate.transform, sceneController.GateMarker);
        }

        private void InitEnemies(GameplaySceneController sceneController)
        {
            foreach (var sceneControllerEnemiesMarker in sceneController.EnemiesMarkers)
            {
                var currentEnemy = _sceneFactory.CreateEnemy();
                sceneController.Enemies.Add(currentEnemy.GetComponent<EnemyView>());
                InitObject(currentEnemy.transform, sceneControllerEnemiesMarker);
            }
        }

        private void InitObject(Transform currentObject, Transform marker)
        {
            currentObject.position = marker.position;
            currentObject.eulerAngles = marker.eulerAngles;
            currentObject.transform.SetParent(marker);
        }
    }
}