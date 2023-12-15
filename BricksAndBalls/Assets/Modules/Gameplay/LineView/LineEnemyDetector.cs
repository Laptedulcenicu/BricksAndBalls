using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Modules.Gameplay
{
    public class LineEnemyDetector : MonoBehaviour
    {
        [SerializeField] private Transform transformModel;

        private readonly List<IInteractable> _enemyList = new();

        public int ActiveEnemiesCount()
        {
            _enemyList.Clear();

            Collider[] hitColliders = Physics.OverlapBox(transformModel.position, transformModel.localScale / 2,
                transform.rotation);
            AddDetectedEnemies(hitColliders);

            int count = _enemyList.Count(e => e.IsActive);
            return count;
        }

        private void AddDetectedEnemies(Collider[] hitColliders)
        {
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag(Tags.Enemy) && hitCollider.TryGetComponent(out IInteractable interactable))
                {
                    if (!_enemyList.Contains(interactable))
                    {
                        _enemyList.Add(interactable);
                    }
                }
            }
        }
    }
}