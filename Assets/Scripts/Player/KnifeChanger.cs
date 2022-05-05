using System.Collections.Generic;
using UnityEngine;

namespace KnifeScripts
{
    public class KnifeChanger : MonoBehaviour
    {
        [SerializeField] private List<int> _prises;
        [SerializeField] private List<GameObject> _knifesPrefabs;
        [SerializeField] private List<GameObject> _knifes;

        private void Awake()
        {
            for (var i = 0; i < _knifesPrefabs.Count; i++)
                _knifes.Add(Instantiate(_knifesPrefabs[i], this.transform));
        }
        public GameObject ChangeKnife(int knifePrise)
        {
            GameObject knife = null;
            for (var i = 0; i < _prises.Count; i++)
                if (_prises[i] < knifePrise && _knifes.Count >= i)
                    knife = _knifes[i];

            return knife;
        }
    }
}
