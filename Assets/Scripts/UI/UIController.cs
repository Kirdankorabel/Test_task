using System;
using UnityEngine;

namespace UIScripts
{
    public class UIController : MonoBehaviour
    {
        public static UIController Singletone;

        [SerializeField] private ResultPanel _resultPanel;
        [SerializeField] private MenuPanel _menuPanel;
        [SerializeField] private GamePanel _gamePanel;

        public event Action NextLevelStart;

        private void Awake()
        {
            Singletone = this;
        }

        private void Start()
        {
            KnifeController.Singltone.EndLevel += ShowResultPanel;
            ShowMenuPanel();

            _resultPanel.AcceptButton.onClick.AddListener(ShowMenuPanel);

            _menuPanel.PlayButton.onClick.AddListener(() => NextLevelStart?.Invoke());
            _menuPanel.PlayButton.onClick.AddListener(ShowGamePanel);

        }

        private void ShowResultPanel()
        {
            _resultPanel.gameObject.SetActive(true);
            _resultPanel.ShowResult(KnifeController.Singltone.PointsCount);
            _gamePanel.gameObject.SetActive(false);
            _menuPanel.gameObject.SetActive(false);
        }

        private void ShowGamePanel()
        {
            _gamePanel.gameObject.SetActive(true);
            _menuPanel.gameObject.SetActive(false);
            _resultPanel.gameObject.SetActive(false);
        }

        public void ShowMenuPanel()
        {
            _gamePanel.gameObject.SetActive(false);
            _menuPanel.gameObject.SetActive(true);
            _resultPanel.gameObject.SetActive(false);
        }
    }
}
