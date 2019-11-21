using UnityEngine;
using Quaternion = System.Numerics.Quaternion;

namespace Player.Items
{
    public class MagicStick : MonoBehaviour, IEqItem
    {
        public GameObject projectile;
        public GameObject playerCamera;
        public GameObject bulletsContainer;
        public float MainCooldown { get; } = 1f;
        public float AdditionalCooldown { get; } = 1f;
        public float MainForceValue { get; } = 1f;
        public float AdditionalForceValue { get; } = 1f;
        public float ShotSpeed { get; } = 1f;
        
        public void MainAction(PlayerActionsController playerActions)
        {
            var bullet = Instantiate(
                projectile,
                playerCamera.transform.position,
                playerCamera.transform.rotation * new UnityEngine.Quaternion(50,30,30,10),
                bulletsContainer.transform
            );
            
            bullet.GetComponent<Rigidbody>().velocity = playerCamera.transform.TransformDirection(new Vector3(0f, 0f,playerActions.ShotSpeed));
            bullet.GetComponent<Bullet>().ExistanceTime = 2f;
        }

        public void AdditionalAction(PlayerActionsController playerActions)
        {
            
        }

        public void PasiveAction(float dt)
        {
            // do nothing
        }
    }
}