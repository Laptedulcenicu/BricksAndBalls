using System.Linq;
using DG.Tweening;

namespace Modules.Gameplay
{
    public class ObstaclesController
    {
        private readonly GameplaySceneController _gameplaySceneController;
        private readonly GameLoopEvents _gameLoopEvents;

        public ObstaclesController(GameplaySceneController gameplaySceneController, GameLoopEvents gameLoopEvents)
        {
            _gameplaySceneController = gameplaySceneController;
            _gameLoopEvents = gameLoopEvents;
            _gameLoopEvents.OnMoveObstacles += MoveObstacles;
            _gameLoopEvents.OnDestroyObstacle+= OnDestroyObstacle;
        }

        private void OnDestroyObstacle()
        {
            if (_gameplaySceneController.ObstaclesView.All(e => e.IsDestroyed))
            {
                _gameLoopEvents.OnWin?.Invoke();
            }
        }

        private void MoveObstacles()
        {
            foreach (var obstacleView in _gameplaySceneController.ObstaclesView)
            {
                if (!obstacleView.IsDestroyed)
                {
                    obstacleView.Move();
                }
            }

            Reload();
        }

        private void Reload()
        {
            DOVirtual.DelayedCall(0.3f, () =>
            {
                _gameplaySceneController.Player.PlayerShoot.Reload();
                _gameplaySceneController.InteractableController.CanControl = true;
            });
        }
    }
}