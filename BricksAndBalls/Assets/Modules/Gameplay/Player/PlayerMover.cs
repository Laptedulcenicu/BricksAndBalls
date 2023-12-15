using System.Collections;
using UnityEngine;

namespace Modules.Gameplay
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private float targetDistance = 20;
        [SerializeField] private float jumpHeight = 2f;
        [SerializeField] private float jumpDuration = 1f;
        [SerializeField] private int numJumps = 5;

        public void Move()
        {
            StartCoroutine(AutoJumps());
        }

        IEnumerator AutoJumps()
        {
            for (int i = 0; i < numJumps; i++)
            {
                JumpDestination(targetDistance / numJumps);
                yield return new WaitForSeconds(jumpDuration);
            }
        }

        void JumpDestination(float distance)
        {
            Vector3 targetPosition = transform.position + transform.forward * distance;

            StartCoroutine(JumpAnimation(targetPosition));
        }

        IEnumerator JumpAnimation(Vector3 targetPosition)
        {
            var elapsedTime = 0f;
            Vector3 initialPosition = transform.position;

            while (elapsedTime < jumpDuration)
            {
                var t = elapsedTime / jumpDuration;
                var yOffset = Mathf.Sin(t * Mathf.PI) * jumpHeight;
                transform.position = Vector3.Lerp(initialPosition, targetPosition, t) + new Vector3(0f, yOffset, 0f);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = targetPosition;
        }
    }
}