using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5000f;
    [SerializeField] private Transform playerBody;
    private float mouseSensitivity = 1200f;
    public bool mouseReverse = false;
    private Rigidbody rb;
    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private float yRotation = 0;
    private bool isJumping = false;
    private bool isGround = false;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;

        if (DataInstance.Instance != null)
        {
            mouseSensitivity = DataInstance.Instance.mouseSensitivity;
            mouseReverse = DataInstance.Instance.isMouseReversed;
        }
    }

    void Update()
    {
        Move();
        Jump();
        Rotate();
    }


    void FixedUpdate()
    {
        Vector3 newVelocity = new Vector3(moveVelocity.x, rb.linearVelocity.y, moveVelocity.z);
        rb.linearVelocity = newVelocity;

        if (isJumping)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = false;
        }
    }

    private void Move()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 inputDirection = new Vector3(moveX, 0f, moveZ).normalized;
        Vector3 moveDir = this.transform.TransformDirection(inputDirection);
        moveVelocity = moveDir * moveSpeed;
    }


    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            isJumping = true;
            isGround = false;
        }
    }

    private void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        float rotationAmount = mouseReverse ? -mouseX : mouseX;
        playerBody.Rotate(Vector3.up * rotationAmount);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
    }
}

