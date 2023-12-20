using System.Collections;
using Modules.Common;
using StansAssets.Foundation.Patterns;
using TMPro;
using UnityEngine;

namespace Modules.Gameplay
{
    public class PlayerShoot : MonoBehaviour
    {
        [SerializeField] private AudioClip shootAudio;
        [SerializeField] private Transform bulletParent;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private TextMeshProUGUI ballCounterText;
        [SerializeField] private Transform textParent;
        [SerializeField] private int maxBullets;
        private PrefabPool _bulletPool;
        private BulletView _currentActiveBullet;
        private IAudioService _audioService;
        private readonly WaitForSeconds _waitForSeconds = new(0.1f);
        private int _countBalls;

        public void Initialize(IAudioService audioService)
        {
            _audioService = audioService;
            _bulletPool = new PrefabPool(bulletPrefab);
            _countBalls = maxBullets;
            textParent.parent = null;
            ballCounterText.text = "x" + _countBalls;
            InitializeBullet();
        }

        public void InitializeBullet()
        {
            _currentActiveBullet = GetBullet();
            _currentActiveBullet.Initialize(_bulletPool, _audioService);

            _currentActiveBullet.transform.position = bulletParent.position;
     
        }

        public void Shoot()
        {
            StartCoroutine(ShootBall());
        }

        private IEnumerator ShootBall()
        {
            while (_countBalls >= 0)
            {
                yield return _waitForSeconds;
                var bulletTransform = _currentActiveBullet.transform;
                bulletTransform.eulerAngles = bulletParent.eulerAngles;
                _currentActiveBullet.Move(bulletTransform.forward);
               // _audioService.PlayOneShotSound(shootAudio, 1);
         
                _countBalls--;
               if(_countBalls> 0)
                    InitializeBullet();
                

                ballCounterText.text = "x" + _countBalls;
            }
        }

        private BulletView GetBullet()
        {
            return _bulletPool.Get().GetComponent<BulletView>();
        }
    }
}