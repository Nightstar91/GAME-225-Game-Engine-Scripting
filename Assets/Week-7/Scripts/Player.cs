using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;


namespace Week7
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        float speed = 5.0f;
        [SerializeField]
        float rotation = 5.0f;

        [SerializeField] TextMeshProUGUI healthText;
        [SerializeField] TextMeshProUGUI keyText;
        [SerializeField] TextMeshProUGUI coinText;

        private float health = 100f;
        public int keyAmount = 0;
        private int coinAmount = 0;

        public PlayerControls playerControls;

        private float mouseDeltaX = 0f;
        private float mouseDeltaY = 0f;
        private float cameraRotX = 0f;
        private int rotDir = 0;

        private InputAction move;
        private InputAction look;
        private InputAction fire;

        Rigidbody rb;

        private void Awake()
        {
            playerControls = new PlayerControls();

            rb = GetComponent<Rigidbody>();
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            move = playerControls.Player.Move;
            look = playerControls.Player.Look;
            fire = playerControls.Player.Fire;
        }

        private void OnEnable()
        {       
            move.Enable();
            look.Enable();
            fire.Enable();
        }

        private void OnDisable()
        {
            move.Disable();
            look.Disable();
            fire.Disable();
        }


        private void Update()
        {
            HandleHorizontalRotation();
            HandleVerticalRotation();

            DisplayHUD();
        }

        private void FixedUpdate()
        {
            HandleMovement();
        }

        void HandleMovement()
        {

            Vector2 axis = move.ReadValue<Vector2>();

            Vector3 input = (axis.x * transform.right) + (transform.forward * axis.y);

            input *= speed;

            rb.velocity = new Vector3(input.x, rb.velocity.y, input.z);
        }


        void HandleHorizontalRotation()
        {

            mouseDeltaX = look.ReadValue<Vector2>().x;

            if (mouseDeltaX != 0)
            {
                rotDir = mouseDeltaX > 0 ? 1 : -1;

                transform.eulerAngles += new Vector3(0, rotation * Time.deltaTime * rotDir, 0);
            }
        }

        void HandleVerticalRotation()
        {
            mouseDeltaY = look.ReadValue<Vector2>().y;

            if (mouseDeltaY != 0)
            {
                rotDir = mouseDeltaY > 0 ? -1 : 1;

                cameraRotX += rotation * Time.deltaTime * rotDir;
                cameraRotX = Mathf.Clamp(cameraRotX, -45f, 45f);

                var targetRotation = Quaternion.Euler(Vector3.right * cameraRotX);


                //Vector3 angle = new Vector3(rotation * Time.deltaTime * rotDir, 0, 0);

                //Debug.Log(Camera.main.transform.localRotation.x);

                Camera.main.transform.localRotation = targetRotation;
                //Camera.main.transform.Rotate(angle, Space.Self);

            }
        }


        // Function to be use for the trap of the assingment
        public void DamagePlayer(float amount)
        {
            health -= amount;
        }


        public void GetKey(int amount)
        {
            keyAmount += amount;
        }

        public void GetCoin(int amount)
        {
            coinAmount += amount;
        }

        public void GetPlayerHealth()
        {
            Debug.Log($"player health = {health}");
        }

        void DisplayHUD()
        {
            healthText.text = string.Format("Health: {0}", health);
            keyText.text = string.Format("Key: {0}", keyAmount);
            coinText.text = string.Format("Coin: {0}", coinAmount);
        }
    }
}
