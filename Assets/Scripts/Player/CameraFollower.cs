using UnityEngine;

namespace KnifeScripts
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Vector3 _offset;

        private void Update()
        {
            var pos = this.transform.position + _offset;
            _camera.transform.position = pos;
        }
    }
}
