using KnifeScripts;
using UnityEngine;

namespace TrackScripts
{
    public class FinishScaleTarget : MonoBehaviour
    {
        private int _point;
        private float _multipler;

        public float Multipler
        {
            get => _multipler;
            set
            {
                if (_multipler == 0)
                    _multipler = value;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            var knifePrise = collision.gameObject.GetComponent<KnifePrise>();
            if (knifePrise != null)
                knifePrise.TakeAway(_point);
        }

        public void SetProperties(float mult, int point)
        {
            _point = point;
            _multipler = mult;
        }
    }
}
