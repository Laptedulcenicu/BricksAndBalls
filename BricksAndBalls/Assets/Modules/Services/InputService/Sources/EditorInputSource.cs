using UnityEngine;

namespace Modules.Services.InputService
{
    public class EditorInputSource : BaseInputSource
    {
        public override bool PointerDown => Input.GetMouseButtonDown(0);
        public override bool PointerUp => Input.GetMouseButtonUp(0);
    }
}