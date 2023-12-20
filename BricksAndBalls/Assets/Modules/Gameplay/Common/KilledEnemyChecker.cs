namespace Modules.Gameplay
{
    public class KilledEnemyChecker
    {
        private readonly PlayerMover _playerMover;
        private readonly InteractableController _interactableController;

        public KilledEnemyChecker(PlayerMover playerMover,
            InteractableController interactableController)
        {
            _interactableController = interactableController;
            _playerMover = playerMover;
        }

        public void CheckWinStatus()
        {
           
        }
    }
}