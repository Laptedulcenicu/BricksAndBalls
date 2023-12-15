using System;
using Modules.Common;

namespace Modules.Services.InputService
{
    public abstract class BaseInputSource : IInputSource
    {
        public event Action<InputEventData> OnTapDown = delegate { };
        public event Action<InputEventData> OnDrop = delegate { };

        public abstract bool PointerDown { get; }
        public abstract bool PointerUp { get; }

        public void TapDown(InputEventData inputEventData)
        {
            OnTapDown?.Invoke(inputEventData);
        }

        public void Drop(InputEventData inputEventData)
        {
            OnDrop?.Invoke(inputEventData);
        }
    }
}