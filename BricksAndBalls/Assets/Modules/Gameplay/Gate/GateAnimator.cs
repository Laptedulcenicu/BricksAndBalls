using UnityEngine;

namespace Modules.Gameplay
{
    public class GateAnimator : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        private static readonly int s_OpenDoor = Animator.StringToHash("OpenDoor");


        public void OpenDoor()
        {
            animator.SetTrigger(s_OpenDoor);
        }
    }
}