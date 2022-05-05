using UnityEngine;
using UnityEngine.UI;

namespace UIScripts
{
    public class StartPanel : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _exitButton;

        private void Start()
        {
            _exitButton.onClick.AddListener(Application.Quit);
        }
    }
}
