using DG.Tweening;
using Modules.Common;
using UnityEngine;

namespace Modules.Gameplay
{
    public class EnemyView : MonoBehaviour, IInteractable
    {
        [SerializeField] private AudioClip dieAudio;
        [SerializeField] private GameObject deathFx;
        [SerializeField] private Collider enemyCollider;
        [SerializeField] private EnemyAnimator enemyAnimator;

        private IAudioService _audioService;

        private bool _isDeath;

        public bool IsActive => !_isDeath;

        public void Initialize(IAudioService audioService)
        {
            _audioService = audioService;
        }

        public void Interact()
        {
            if (_isDeath) return;
            Die();
        }

        private void Die()
        {
            _isDeath = true;
            enemyCollider.enabled = false;
            enemyAnimator.PlayDeath();
            DOVirtual.DelayedCall(1, ActivateFX);
        }

        private void ActivateFX()
        {
            _audioService.PlayOneShotSound(dieAudio,0.1f);
            Instantiate(deathFx, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}