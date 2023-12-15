namespace Modules.Gameplay
{
    public class KilledEnemyChecker
    {
        private readonly LineEnemyDetector _lineEnemyDetector;
        private readonly PlayerMover _playerMover;
        private readonly InteractableController _interactableController;

        public KilledEnemyChecker(PlayerMover playerMover, LineEnemyDetector lineEnemyDetector,
            InteractableController interactableController)
        {
            _lineEnemyDetector = lineEnemyDetector;
            _interactableController = interactableController;
            _playerMover = playerMover;
        }

        public void CheckWinStatus()
        {
            if (_lineEnemyDetector.ActiveEnemiesCount() <= 0)
            {
                _playerMover.Move();
            }
            else
            {
                _interactableController.CanControl = true;
            }
        }
    }
}