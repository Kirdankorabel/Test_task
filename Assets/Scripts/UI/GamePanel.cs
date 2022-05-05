using UnityEngine;
using UnityEngine.UI;

namespace UIScripts
{
    public class GamePanel : MonoBehaviour
    {
        [SerializeField] private Text _priseText;
        [SerializeField] private Text _pointsText;

        private void Start()
        {
            KnifeController.Singltone.PriseChanged += UpdatePriseText;
            KnifeController.Singltone.PointsCountChanged += UpdatePointsText;
        }

        public void UpdatePriseText()
            => _priseText.text = KnifeController.Singltone.Prise.ToString();

        public void UpdatePointsText()
            => _pointsText.text = KnifeController.Singltone.TotalPointsCount.ToString();
    }
}
