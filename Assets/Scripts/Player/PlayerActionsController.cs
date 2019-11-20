using System;
using UnityEngine;

namespace Player
{
    public class PlayerActionsController : MonoBehaviour
    {
        public float mainMouseCooldown = 1f;
        public float additionalMouseCooldown = 5f;
        public Action MainMouseAction { get; private set; } = () => { };
        public Action AdditionalMouseAction { get; private set; } = () => { };
        void Start()
        {
            
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
                MainMouseAction();
                _mainCooldown = mainMouseCooldown;
            }
        }

        public void OnAdditionalMouseClick()
        {
            if (_additionalCooldown <= 0f)
            {
                AdditionalMouseAction();
                _additionalCooldown = additionalMouseCooldown;
            }
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