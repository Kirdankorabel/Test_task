using UnityEngine;

namespace GateScripts
{
    public class Gate : MonoBehaviour
    {
        [SerializeField] private Pass _pass1;
        [SerializeField] private Pass _pass2;
        [SerializeField] private bool _isMoveble;
        [SerializeField] private GateMover mover;
        [SerializeField] private Animator _animator;

        private void Update()
        {
            if (_isMoveble)
                mover.Move();
        }

        private void Start()
        {
            _pass1.PlayerPassed += DeactivateGate;
            if (_pass2 != null)
                _pass2.PlayerPassed += DeactivateGate;
        }

        public void SetProperties(int value1, bool isMultipler, bool isMoveble, Vector3 pos)
        {
            _pass1.SetPassProperties(value1, isMultipler, pos);
            _isMoveble = isMoveble;
        }

        public void SetProperties(int value1, int value2, bool isMultipler1, bool isMultipler2, Vector3 pos)
        {
            _pass1.SetPassProperties(value1, isMultipler1, pos);
            _pass2.SetPassProperties(value2, isMultipler2, pos);
        }

        public void DeactivateGate()
        {
            _animator.SetBool("IsActive", false);
            _pass1.Collider.isTrigger = true;
            if (_pass2 != null)
                _pass2.Collider.isTrigger = true;
        }
    }
}