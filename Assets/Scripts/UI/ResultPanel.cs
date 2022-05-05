using UnityEngine;
using UnityEngine.UI;

namespace UIScripts
{
    public class ResultPanel : MonoBehaviour
    {
        [SerializeField] private Text _resultTest;
        [SerializeField] private Button _acceptButton;

        public Button AcceptButton => _acceptButton;

        public void ShowResult(int value)
        {
            _resultTest.text = $"{KnifeController.Singltone.PointsCount} x {KnifeController.Singltone.Multipler}";
        }
    }
}
