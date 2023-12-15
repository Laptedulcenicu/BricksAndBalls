using UnityEngine;

namespace Modules.Gameplay
{
    public class OpenDoorTrigger : MonoBehaviour, IInteractable
    {
        [SerializeField] private GateView gateView;
        private bool _isInteracted;

        public bool IsActive => !_isInteracted;

        public void Interact()
        {
            if (!_isInteracted)
            {
                _isInteracted = true;
                gateView.OpenDoor();
            }
        }
    }
}