using UnityEngine;

namespace Player.Items
{
    public class MagicStick : MonoBehaviour, IEqItem
    {
        private GameObject view;
        public float MainCooldown { get; } = 1f;
        public float AdditionalCooldown { get; } = 1f;
        public float MainForceValue { get; } = 1f;
        public float AdditionalForceValue { get; } = 1f;
        
        public void MainAction()
        {
            
        }

        public void AdditionalAction()
        {
            
        }

        public void PasiveAction(float dt)
        {
            // do nothing
        }
    }
}