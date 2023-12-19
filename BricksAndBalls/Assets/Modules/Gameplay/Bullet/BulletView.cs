using System;
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
        private bool _isTouched;
        private bool _isMoving;
        private Vector3 _lastVelocity;
        private Vector3 _direction;


        public void Initialize(PrefabPool prefabPool, IAudioService audioService)
        {
            _audioService = audioService;
            _prefabPool = prefabPool;
            _isTouched = false;
            collisionObserver.CollisionEnter += CollisionEnter;
        }

        private void FixedUpdate()
        {
            if (rigidbody.velocity.magnitude < bulletSpeed)
            {
                rigidbody.velocity = _direction;
            }
            _lastVelocity = rigidbody.velocity;
        }

        public void Move(Vector3 vel)
        {
            _isMoving = true;
            rigidbody.isKinematic = false;
            rigidbody.velocity = vel*bulletSpeed;
            _direction = vel * bulletSpeed;
        }

        private void CollisionEnter(Collision other)
        {
            _direction = Vector3.Reflect(_lastVelocity.normalized, other.contacts[0].normal)*bulletSpeed;
            rigidbody.velocity = _direction ;
            // if (_isTouched) return;
            // _isTouched = true;
            //
            // if (other.CompareTag(Tags.Enemy))
            // {
            //     if (!other.TryGetComponent(out IInteractable _)) return;
            //     Instantiate(shootParticles, transform.position, Quaternion.identity);
            //     _audioService.PlayOneShotSound(bulletAudio,1);
            //     _prefabPool.Release(gameObject);
            //     _killedEnemyChecker.CheckWinStatus();
            // }
        }
    }
}