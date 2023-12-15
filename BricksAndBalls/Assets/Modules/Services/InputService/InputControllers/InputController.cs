using Modules.Common;
using UnityEngine;

namespace Modules.Services.InputService
{
    public class InputController : MonoBehaviour, IInputController
    {
        private IInputSource _inputSource;
        private bool _isTapDown;

        private void Update()
        {
            if (_inputSource == null)
            {
                return;
            }

            if (_inputSource.PointerDown)
            {
                InputDown();
            }

            if (_inputSource.PointerUp)
            {
                InputUp();
            }
        }

        public void Setup(IInputSource inputSource)
        {
            _inputSource = inputSource;
        }

        private void InputDown()
        {
            _isTapDown = true;
            _inputSource.TapDown(new InputEventData(_isTapDown));
        }

        private void InputUp()
        {
            _isTapDown = false;
            _inputSource.Drop(new InputEventData(_isTapDown));
        }
    }
}