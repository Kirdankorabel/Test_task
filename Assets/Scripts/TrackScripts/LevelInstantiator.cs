using GateScripts;
using System.Collections.Generic;
using UnityEngine;

namespace TrackScripts
{
    public class LevelInstantiator : MonoBehaviour
    {
        [SerializeField] private GameObject _trassPrefab;
        [SerializeField] private TargetInstantiator _targetInstantiator;
        [SerializeField] private GateInstantiator _gateInstantiator;
        [SerializeField] private FinishInstantiator _finishInstantiator;
        [SerializeField] private float _trassOffset;

        private List<GameObject> objects;

        private void Start()
        {
            GameController.Singletone.StartLevel += DestroyLevel;
        }

        public void CreateLevel(int level)
        {
            if (level > Levels.levels.Count) return;
            var levelInfo = Levels.GetLevel(level);
            LoadLevel(levelInfo);
        }

        private void LoadLevel(LevelInfo levelInfo)
        {
            objects = new List<GameObject>();
            var gates = levelInfo.gates;
            _targetInstantiator.InstantiateTargets(levelInfo.targetsPositions);
            for (var i = 0; i < gates.Count; i++)
                _gateInstantiator.InstantiateGate(gates[i], new Vector3(0, 1.5f, i * _trassOffset));
            _finishInstantiator.InstantiateFinish(new Vector3(0, 0, (gates.Count + 1) * _trassOffset), levelInfo.finishScaleLeght);

            for (var i = -1; i < gates.Count + 1; i++)
            {
                var obj = Instantiate(_trassPrefab, new Vector3(0, 0, i * _trassOffset), Quaternion.identity, this.transform);
                objects.Add(obj);
            }
        }

        private void DestroyLevel()
        {
            if (objects != null)
                foreach (var obj in objects)
                    Destroy(obj.gameObject);
        }
    }
}
