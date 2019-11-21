using System;
using System.Collections.Generic;
using Player.Items;
using UnityEngine;

namespace Player
{
    public class PlayerActionsController : MonoBehaviour
    {
        public float mainMouseCooldown = 1f;
        public float additionalMouseCooldown = 5f;
        public float shotSpeed = 10f;
        
        public float MainMouseCooldown => 
            mainMouseCooldown * RightHand.MainCooldown * LeftHand.MainCooldown;

        public float AdditionalMouseCooldown =>
            additionalMouseCooldown * RightHand.AdditionalCooldown * LeftHand.AdditionalCooldown;

        public float ShotSpeed =>
            shotSpeed * RightHand.ShotSpeed * LeftHand.ShotSpeed;
        
        public IEqItem RightHand { get; set; }
        public IEqItem LeftHand { get; set; }
        void Start()
        {
            RightHand = new NoItem();
            LeftHand = new NoItem();
        }

        // Update is called once per frame
        void Update()
        {
            Cooldown();
        }

        public void OnMouseClick()
        {
            if (_mainCooldown <= 0f)
            {
                RightHand.MainAction(this);
                _mainCooldown = MainMouseCooldown;
            }
        }

        public void OnAdditionalMouseClick()
        {
            if (_additionalCooldown <= 0f)
            {
                RightHand.AdditionalAction(this);
                _additionalCooldown = additionalMouseCooldown;
            }
        }

        public void PasiveAction(float dt)
        {
            RightHand.PasiveAction(dt);
            LeftHand.PasiveAction(dt);
        }
        private void Cooldown()
        {
            if (_mainCooldown > 0f)
            {
                _mainCooldown -= Time.deltaTime;
            }

            if (_additionalCooldown > 0f)
            {
                _additionalCooldown -= Time.deltaTime;
            }
        }

        private float _mainCooldown;
        private float _additionalCooldown;

    }
}