using System.Collections.Generic;
using UnityEngine;

namespace TrackScripts
{
    public class TargetInstantiator : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _targetsPrefabs;
        private List<GameObject> _targets;

        private void Start()
        {
            GameController.Singletone.StartLevel += DestroyTargets;
        }

        public void InstantiateTargets(List<Vector3> positions)
        {
            _targets = new List<GameObject>();
            foreach (var position in positions)
                _targets.Add(Instantiate(_targetsPrefabs[Random.Range(0, _targetsPrefabs.Count)], position, Quaternion.identity));
        }

        public void DestroyTargets()
        {
            if (_targets != null)
                foreach (var target in _targets)
                    Destroy(target.gameObject);

            _targets = new List<GameObject>();
        }
    }
}