using System.Collections.Generic;
using UnityEngine;

namespace Modules.Gameplay
{
    public class BulletDeathZone : MonoBehaviour
    {
        [SerializeField] private TriggerObserver triggerObserver;
        [SerializeField] private Transform deathZone;

        private readonly List<IInteractable> _enemyList = new();

        public List<IInteractable> EnemyList => _enemyList;

        private void Awake()
        {
            triggerObserver.TriggerEnter += TriggerEnter;
            triggerObserver.TriggerExit += OnTriggerExit;
        }

        public void ChangeDeathZoneSize(float sizeAmount)
        {
            deathZone.localScale += Vector3.one * sizeAmount;
        }

        public void KillEnemies()
        {
            foreach (var interactable in _enemyList)
            {
                interactable.Interact();
            }
        }

        private void TriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Enemy))
            {
                if (!other.TryGetComponent(out IInteractable interactable)) return;
                if (!_enemyList.Contains(interactable))
                {
                    _enemyList.Add(interactable);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(Tags.Enemy))
            {
                if (!other.TryGetComponent(out IInteractable interactable)) return;
                if (_enemyList.Contains(interactable))
                {
                    _enemyList.Remove(interactable);
                }
            }
        }
    }
}