using UnityEngine;

namespace TrackScripts
{
    public class FinalScale : MonoBehaviour
    {
        [SerializeField] private TextMesh _text;
        [SerializeField] private Renderer _renderer;

        public void SetProps(float value, Color color)
        {
            _text.text = value.ToString();
            _renderer.material.color = color;
        }
    }
}
