using UnityEngine;

namespace Modules.Services.InputService
{
    public class AndroidInputSource : BaseInputSource
    {
        public override bool PointerDown => Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
        public override bool PointerUp => Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended;
    }
}