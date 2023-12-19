namespace Modules.Gameplay
{
    public class SizeConverter
    {
        private readonly PlayerView _playerView;
        private readonly LineView _lineView;

        private const float k_SpeedSizeBullet = 2;

        public SizeConverter(PlayerView playerView, LineView lineView)
        {
            _playerView = playerView;
            _lineView = lineView;
        }

        public void ChangeSize(float sizeAmount)
        {
            _lineView.SizeSetter.ChangeCurrentSize(-sizeAmount);
        }
    }
}