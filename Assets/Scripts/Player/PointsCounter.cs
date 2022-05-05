using UnityEngine;

namespace KnifeScripts
{
    public class PointsCounter : MonoBehaviour
    {
        private int _pointsCount;

        public int PointsCount => _pointsCount;

        private void Start()
        {
            _pointsCount = 0;
        }

        public void AddPoints(int value)
        {
            _pointsCount += value;
        }
    }
}
