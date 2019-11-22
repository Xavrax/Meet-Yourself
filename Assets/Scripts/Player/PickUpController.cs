using UnityEngine;

namespace Player
{
    public class PickUpController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Item"))
            {
                // todo : maybe later
            }
        }
    }
}