using UnityEngine;

namespace PlayerTesting
{
    public class PlayerRestorerController : MonoBehaviour
    {
        public GameObject player;
    
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void LateUpdate()
        {
            if (player.transform.position.y < -5f)
            {
                player.transform.position = new Vector3(2.5f, 2.5f, 2.5f);
            }
        }
    }
}
