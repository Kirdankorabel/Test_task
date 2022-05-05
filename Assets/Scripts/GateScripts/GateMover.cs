using System.Collections;
using UnityEngine;

namespace GateScripts
{
    public class GateMover : MonoBehaviour
    {
        public float speed = 2;
        public float border = 0.45f;
        public void Move()
        {
            StartCoroutine(MoveCoroutine());
        }

        IEnumerator MoveCoroutine()
        {
            if (this.transform.position.x < -border)
                speed = -speed;
            else if (this.transform.position.x > border)
                speed = -speed;
            transform.position += Vector3.left * speed * Time.deltaTime;
            yield return null;
        }
    }
}
