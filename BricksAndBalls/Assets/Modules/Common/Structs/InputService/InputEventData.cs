namespace Modules.Common
{
    public struct InputEventData
    {
        public bool IsTapDown { get; }

        public InputEventData(bool isTapDown)
        {
            IsTapDown = isTapDown;
        }
    }
}