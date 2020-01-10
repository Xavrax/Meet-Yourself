using System;
using Player.Items;
using PlayerTesting;
using UnityEngine;


namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public CharacterController characterControler;
        public GameObject playerCamera;

        public float movementSpeed = 9.0f;
        public float strokeHeight = 7.0f;
        public float actialStrokeHeight = 0f;

        public float mouseSensitivity = 3.0f;
        public float mouseUpDown = 0.0f;
        public float mouseUpDownRange = 90.0f;


        void Start()
        {
            _playerActions = GetComponent(typeof(PlayerActionsController)) as PlayerActionsController;
            characterControler = GetComponent<CharacterController>();
            _rightHand = transform.Find("Main Camera").Find("RightHand").gameObject;
            _leftHand = transform.Find("Main Camera").Find("LeftHand").gameObject;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (_isAlive)
            {
                Keyboard();
                Mouse();
                if (_rightHand.transform.childCount > 0)
                {
                    var component = _rightHand.transform.GetChild(0).GetComponent<IEqItem>();
                    if (_playerActions.RightHand != component)
                    {
                        _playerActions.RightHand = component;
                    }
                }    
            }
        }

        public void Die()
        {
            if (_isAlive)
            {
                transform.Rotate(new Vector3(0, 0, 90f));
                GetComponent<Rigidbody>().useGravity = false;
                _isAlive = false;
            }
        }
        
        private void Keyboard()
        {
            PlayerMovement();
            _playerActions.PasiveAction(Time.deltaTime);
#if UNITY_EDITOR
            ProgressEditorUtilities();
#else
            ExitGameInput();
#endif
        }

        private void Mouse()
        {
            var mouseRightLeft = Input.GetAxis("Mouse X") * mouseSensitivity;
            transform.Rotate(0, mouseRightLeft, 0);
            mouseUpDown -= Input.GetAxis("Mouse Y") * mouseSensitivity;

            mouseUpDown = Mathf.Clamp(mouseUpDown, -mouseUpDownRange, mouseUpDownRange);
            playerCamera.transform.localRotation = Quaternion.Euler(mouseUpDown, 0, 0);

            if (Input.GetKey(KeyCode.Mouse0))
            {
                _playerActions.OnMouseClick();
            }

            if (Input.GetKey(KeyCode.Mouse1))
            {
                _playerActions.OnAdditionalMouseClick();
            }
        }


        private void PlayerMovement()
        {
            var verticalMovement = Input.GetAxis("Vertical") * movementSpeed;
            var horizontalMovement = Input.GetAxis("Horizontal") * movementSpeed;

            if (characterControler.isGrounded && Input.GetButton("Jump"))
            {
                actialStrokeHeight = strokeHeight;
            }
            else if (!characterControler.isGrounded)
            {
                actialStrokeHeight += Physics.gravity.y * Time.deltaTime;
            }

            var move = new Vector3(horizontalMovement, actialStrokeHeight, verticalMovement);
            move = transform.rotation * move;

            characterControler.Move(move * Time.deltaTime);
        }

#if UNITY_EDITOR
        private void ProgressEditorUtilities()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                UnityEditor.EditorApplication.isPlaying = false;
            }

            if (Input.GetKeyDown(KeyCode.F3))
            {
                Cursor.lockState = Cursor.lockState == CursorLockMode.Locked
                    ? CursorLockMode.None
                    : CursorLockMode.Locked;
                Cursor.visible = !Cursor.visible;
            }
        }
#else
        private void ExitGameInput() {
              if (Input.GetKeyDown(KeyCode.Escape))
              {
                    Application.Quit();
              }
        }
#endif

        private PlayerActionsController _playerActions;
        private GameObject _rightHand;
        private GameObject _leftHand;
        private bool _isAlive = true;
    }
}