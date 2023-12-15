using System;

namespace Modules.Common
{
    public interface IInputSource
    {
        event Action<InputEventData> OnTapDown;
        event Action<InputEventData> OnDrop;

        bool PointerDown { get; }
        bool PointerUp { get; }

        void TapDown(InputEventData inputEventData);
        void Drop(InputEventData inputEventData);
    }
}