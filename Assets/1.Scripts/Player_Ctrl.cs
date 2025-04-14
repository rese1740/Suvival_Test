using UnityEngine;

public class Player_Ctrl : MonoBehaviour
{
    [Header("Camera")]
    public Camera playerCamera;
    public float mouseSensitivity = 100f;
    float xRotation = 0f;

    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Rigidbody rb;
    Animator animator;
    bool isGrounded;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        playerCamera.transform.rotation = Quaternion.Euler(0f, 109f, 0f);  // x, y, z 회전값

        rb.useGravity = true; // 중력 사용을 활성화
    }

    void Update()
    {
        LookAround();
        Jump();
    }

    void FixedUpdate()
    {
        Move();
        GroundCheck();
    }

    void LookAround()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = transform.right * h + transform.forward * v;
        Vector3 newVelocity = new Vector3(move.x * moveSpeed, rb.velocity.y, move.z * moveSpeed);
        rb.velocity = newVelocity;

        // 애니메이션 상태 전환
        bool isMoving = move.magnitude > 0.1f;  // 일정 이상 입력이 있을 때만 true
        animator.SetBool("Move", isMoving);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z); // y 속도 초기화
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
    }


}
