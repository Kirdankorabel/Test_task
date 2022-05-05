using System;
using UnityEngine;

namespace GateScripts
{
    public class Pass : MonoBehaviour
    {
        [SerializeField] private TextMesh _text;
        [SerializeField] private MeshRenderer renderer;
        [SerializeField] private Collider _collider;

        private bool _isMultipler;
        private int _value;

        public event Action PlayerPassed;

        public bool IsMultipler => _isMultipler;
        public int Value => _value;
        public Collider Collider => _collider;

        private void OnCollisionEnter(Collision collision)
        {
            var player = collision.gameObject.GetComponent<KnifeController>();
            if (player != null)
                PlayerPassed?.Invoke();
        }

        public void SetPassProperties(int value, bool isMultipler, Vector3 pos)
        {
            _value = value;
            _isMultipler = isMultipler;
            if (value > 0)
            {
                renderer.material.color = new Color(0, 0, 1, 0.3f);
                if (_isMultipler)
                    _text.text = "x" + _value.ToString();
                else
                    _text.text = "+" + _value.ToString();
            }
            else
            {
                renderer.material.color = new Color(1, 0, 0, 0.3f);
                if (_isMultipler)
                    _text.text = "/" + (-_value).ToString();
                else
                    _text.text = _value.ToString();

            }
        }
    }
}
