using UnityEngine;

namespace Modules.Gameplay
{
    public class SizeSetter : MonoBehaviour
    {
        [SerializeField] private bool ignoreAxisX;
        [SerializeField] private bool ignoreAxisY;
        [SerializeField] private bool ignoreAxisZ;
        [SerializeField] private Transform transformModel;

        public Transform TransformModel => transformModel;

        public void ChangeCurrentSize(float sizeAmount)
        {
            var localScale = transformModel.localScale;

            if (!ignoreAxisX)
            {
                localScale  = new Vector3(localScale.x + sizeAmount, localScale.y, localScale.z);
            }

            if (!ignoreAxisY)
            {
                localScale = new Vector3(localScale.x, localScale.y + sizeAmount, localScale.z);
            }

            if (!ignoreAxisZ)
            {
                localScale = new Vector3(localScale.x, localScale.y, localScale.z + sizeAmount);
            }

            transformModel.localScale = localScale;
        }
    }
}