using DG.Tweening;
using UnityEngine;

public class HandAnimation : MonoBehaviour
{
    [SerializeField] private Vector3 minimScale;

    private void OnEnable()
    {
        transform.DOScale(minimScale, 1f).SetDelay(1f).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnDisable()
    {
        transform.DOKill();
    }
}