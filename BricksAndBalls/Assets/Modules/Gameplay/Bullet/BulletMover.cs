using StansAssets.Foundation.Patterns;
using UnityEngine;

namespace Modules.Gameplay
{
    public class BulletMover : MonoBehaviour
    {
        private const float k_MaxDistance = 20;

        [SerializeField] private float speedMove = 3;

        private bool _isMoving;
        private PrefabPool _bulletPool;
        private KilledEnemyChecker _killedEnemyChecker;

        private void Update()
        {
            if (_isMoving)
            {
                transform.position += transform.forward * (Time.deltaTime * speedMove);
            }

            if (transform.position.z >= k_MaxDistance)
            {
                StopMove();
                _bulletPool.Release(gameObject);
                _killedEnemyChecker.CheckWinStatus();
            }
        }

        public void Initialize(KilledEnemyChecker killedEnemyChecker, PrefabPool bulletPool)
        {
            _killedEnemyChecker = killedEnemyChecker;
            _bulletPool = bulletPool;
        }

        public void Move()
        {
            _isMoving = true;
        }

        public void StopMove()
        {
            _isMoving = false;
        }
    }
}