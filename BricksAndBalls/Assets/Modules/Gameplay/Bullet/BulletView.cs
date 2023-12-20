using Modules.Common;
using StansAssets.Foundation.Patterns;
using UnityEngine;

namespace Modules.Gameplay
{
    public class BulletView : MonoBehaviour
    {
        [SerializeField] private float bulletSpeed;
        [SerializeField] private AudioClip bulletAudio;
        [SerializeField] private GameObject shootParticles;
        [SerializeField] private CollisionObserver collisionObserver;
        [SerializeField] private Rigidbody rigidbody;

        private PrefabPool _prefabPool;
        private IAudioService _audioService;
        private bool _isMoving;
        private Vector3 _lastVelocity;
        private Vector3 _direction;


        public void Initialize(PrefabPool prefabPool, IAudioService audioService)
        {
            _audioService = audioService;
            _prefabPool = prefabPool;
            collisionObserver.CollisionEnter += CollisionEnter;
        }

        private void FixedUpdate()
        {
            if (!_isMoving)
                return;

            rigidbody.velocity = _direction;
            _lastVelocity = rigidbody.velocity;
        }

        public void Move(Vector3 vel)
        {
            _isMoving = true;
            rigidbody.isKinematic = false;
            _direction = vel * bulletSpeed;
            rigidbody.velocity = _direction;
        }

        private void CollisionEnter(Collision other)
        {
            _direction = Vector3.Reflect(_lastVelocity.normalized, other.contacts[0].normal) *
                         Mathf.Max(bulletSpeed, 0);
            rigidbody.velocity = _direction;


            if (!other.gameObject.TryGetComponent(out IInteractable interactable)) return;
            interactable.Interact(this);
        }
    }
}