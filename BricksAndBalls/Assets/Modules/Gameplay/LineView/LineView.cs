using UnityEngine;

namespace Modules.Gameplay
{
    public class LineView: MonoBehaviour
    {
        [SerializeField] private LineEnemyDetector lineEnemyDetector;
        [SerializeField] private SizeSetter sizeSetter;

        public SizeSetter SizeSetter => sizeSetter;

        public LineEnemyDetector EnemyDetector => lineEnemyDetector;
    }
}