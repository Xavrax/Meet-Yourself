using UnityEngine;

namespace Utils
{
    public class LevitateScript : MonoBehaviour
    {
        public float maxDistance = 1f;

        public float speed = 0.2f;
        // Start is called before the first frame update
        void Start()
        {
            _delta = maxDistance;
            _reverse = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (_delta > 0)
            {
                var direction = _reverse ? -1f : 1f;
                var distance = speed * Time.deltaTime;
                transform.position = transform.position + new Vector3(0f, distance * direction , 0f);
                _delta -= distance;
            }
            else
            {
                _delta = maxDistance;
                _reverse = !_reverse;
            }
        
        }

        private float _delta;
        private bool _reverse;
    }
}
