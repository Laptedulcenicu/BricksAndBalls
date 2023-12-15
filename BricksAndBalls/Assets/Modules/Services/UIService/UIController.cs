using System;
using Modules.Common;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Modules.Services.UIService
{
    public class UIController : MonoBehaviour, IUIController
    {
        public event Action OnPlay = delegate { };
        public event Action OnNextLevel = delegate { };
        public event Action OnRestart = delegate { };

        [SerializeField] private GameObject winPanel;
        [SerializeField] private GameObject mainMenuPanel;
        [SerializeField] private GameObject losePanel;
        [SerializeField] private TextMeshProUGUI textLevel;

        [SerializeField] private Button restartButton;
        [SerializeField] private Button nextLevelButton;
        [SerializeField] private EventTrigger playButton;

        private void Awake()
        {
            restartButton.onClick.AddListener(() => OnRestart?.Invoke());
            nextLevelButton.onClick.AddListener(() => OnNextLevel?.Invoke());

            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerDown;
            entry.callback.AddListener((_) => OnPlay?.Invoke());
            playButton.triggers.Add(entry);
        }

        public void Initialize(int level)
        {
            textLevel.text = level.ToString();
        }

        public void Play()
        {
            mainMenuPanel.SetActive(false);
        }

        public void ActivateLosePanel()
        {
            winPanel.SetActive(false);
            losePanel.SetActive(true);
            mainMenuPanel.SetActive(false);
        }

        public void ActivateWinPanel()
        {
            winPanel.SetActive(true);
            losePanel.SetActive(false);
            mainMenuPanel.SetActive(false);
        }
    }
}