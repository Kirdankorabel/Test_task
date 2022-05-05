using UnityEngine;
using UnityEngine.UI;

namespace UIScripts
{
    public class MenuPanel : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _exitButton;

        public Button PlayButton => _playButton;

        private void Start()
        {
            _exitButton.onClick.AddListener(Application.Quit);
        }
    }
}
