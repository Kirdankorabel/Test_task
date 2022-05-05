using EzySlice;
using UnityEngine;


namespace TrackScripts
{
    public class Target : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private Material _mat;
        private GameObject _upperHull;
        private GameObject _lowerHull;
        private float timeOfDestroy = 0;

        private void FixedUpdate()
        {
            if (timeOfDestroy != 0 && Time.time > timeOfDestroy)
            {
                Destroy(_upperHull);
                Destroy(_lowerHull);
                Destroy(this.gameObject);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<KnifeController>() != null)
            {
                var plane = new EzySlice.Plane(Vector3.forward, Vector3.up);
                var slisebleObjcet = this.gameObject.Slice(plane);
                _upperHull = slisebleObjcet.CreateUpperHull(this.gameObject, _mat);
                _upperHull.AddComponent<Rigidbody>();
                _upperHull.GetComponent<Rigidbody>().AddForce(new Vector3(0, 5, 0), ForceMode.VelocityChange);
                _lowerHull = slisebleObjcet.CreateLowerHull(this.gameObject, _mat);
                //_lowerHull.AddComponent<Rigidbody>();
                this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                this.gameObject.GetComponent<Collider>().isTrigger = true;
                timeOfDestroy = Time.time + 10;
                _particleSystem.enableEmission = true;
            }
        }
    }
}
