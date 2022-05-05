using GateScripts;
using System.Collections.Generic;
using UnityEngine;

namespace TrackScripts
{
    public class GateInstantiator : MonoBehaviour
    {
        [SerializeField] private Gate _gatePrefab;
        [SerializeField] private Gate _gateVariantPrefab;
        [SerializeField] private GameObject _trass;

        private List<GameObject> _gates;

        private void Start()
        {
            _gates = new List<GameObject>();
            GameController.Singletone.StartLevel += DestroyGates;
        }

        public void InstantiateGate(GateInfo gateInfo, Vector3 pos)
        {
            Gate gate;

            if (gateInfo.secondPassValue == 0)
            {
                gate = Instantiate(_gatePrefab, pos, Quaternion.identity, _trass.transform);
                gate.GetComponent<Gate>().SetProperties
                    (gateInfo.firstPassValue, gateInfo.firstPassIsMultipler, gateInfo.isMovebleGate, pos);
                _gates.Add(gate.gameObject);
            }
            else
            {
                gate = Instantiate(_gateVariantPrefab, pos, Quaternion.identity, _trass.transform);
                gate.GetComponent<Gate>().SetProperties
                    (gateInfo.firstPassValue, gateInfo.secondPassValue, gateInfo.firstPassIsMultipler, gateInfo.secondPassIsMultipler, pos);
            }
            _gates.Add(gate.gameObject);
        }

        private void DestroyGates()
        {
            if (_gates != null)
                foreach (var gate in _gates)
                    Destroy(gate.gameObject);
            _gates = new List<GameObject>();
        }
    }
}
