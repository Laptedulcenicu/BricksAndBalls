using UnityEngine;

namespace Modules.Gameplay
{
    public class EnemyAnimator : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        private static readonly int s_Die = Animator.StringToHash("Die");

        public void PlayDeath()
        {
            animator.SetTrigger(s_Die);
        }
    }
}