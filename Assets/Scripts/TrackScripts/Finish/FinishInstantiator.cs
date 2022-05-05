using System.Collections.Generic;
using UnityEngine;


namespace TrackScripts
{
    public class FinishInstantiator : MonoBehaviour
    {
        [SerializeField] private GameObject _finishPrefab;
        [SerializeField] private FinalScale _finalScale;
        [SerializeField] private Vector3 _offset;
        [SerializeField] private FinishScaleTarget _finishScaleTargetPrefab;
        [SerializeField] private List<Color> _colors;
        [SerializeField] private int _pointsMult = 100;

        private List<GameObject> _objects;

        private void Start()
        {
            GameController.Singletone.StartLevel += DestroyObjects;
        }

        public void InstantiateFinish(Vector3 pos, int count)
        {
            _objects = new List<GameObject>();
            var finish = Instantiate(_finishPrefab, pos, Quaternion.identity, transform);
            _objects.Add(finish.gameObject);
            InstantiateScale(pos, count);
        }

        public void DestroyObjects()
        {
            if (_objects != null)
                foreach (var obj in _objects)
                    Destroy(obj.gameObject);
        }

        private void InstantiateScale(Vector3 pos, int count)
        {
            var pos2 = pos + new Vector3(0, 2, 0);
            for (var i = 0; i < count; i++)
            {
                var scaleMark = Instantiate(_finalScale, pos + _offset * (i + 1), Quaternion.identity, transform);
                scaleMark.SetProps(1 + i * 0.1f, _colors[i % _colors.Count]);
                _objects.Add(scaleMark.gameObject);
                var target = Instantiate(_finishScaleTargetPrefab, pos2 + _offset * (i + 1), Quaternion.identity, transform);
                target.SetProperties(1 + i * 0.1f, (int)((1 + i) * _pointsMult));
                _objects.Add(target.gameObject);
            }
        }
    }
}
