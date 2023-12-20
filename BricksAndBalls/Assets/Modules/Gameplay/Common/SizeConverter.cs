namespace Modules.Gameplay
{
    public class SizeConverter
    {
        private readonly PlayerView _playerView;

        private const float k_SpeedSizeBullet = 2;

        public SizeConverter(PlayerView playerView)
        {
            _playerView = playerView;
        }

        public void ChangeSize(float sizeAmount)
        {
        }
    }
}