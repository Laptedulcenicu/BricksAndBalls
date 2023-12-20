using Modules.Common;
using Modules.Gameplay;
using TMPro;
using UnityEngine;

public class ObstacleView : MonoBehaviour
{
    [SerializeField] private int obstacleValue;
    [SerializeField] private TextMeshProUGUI valueText;
    [SerializeField] private InteractionDetection interactionDetection;
    [SerializeField] private GameObject model;
    [SerializeField] private GameObject collider;

    private int _currentObstacleValue;
    private IAudioService _audioService;

    public void Initialize(IAudioService audioService)
    {
        _audioService = audioService;
        _currentObstacleValue = obstacleValue;
        valueText.text = obstacleValue.ToString();
        interactionDetection.OnInteract += Interact;
    }

    private void Interact(BulletView playerView)
    {
        _currentObstacleValue--;
        valueText.text = _currentObstacleValue.ToString();

        if (_currentObstacleValue <= 0)
        {
            Destroy();
        }
    }

    private void Destroy()
    {
        collider.SetActive(false);
        model.SetActive(false);
        valueText.transform.parent.gameObject.SetActive(false);
    }
}