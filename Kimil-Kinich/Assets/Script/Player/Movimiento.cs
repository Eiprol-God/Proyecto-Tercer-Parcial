using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 10f;
    public float jumpForce = 7f;

    public Transform cameraTransform;
    public Transform groundCheck;
    public float groundDistance = 0.3f;
    public LayerMask groundLayer;

    private Rigidbody rb;
    private bool isGrounded;
    private Vector3 moveDirection;
    private bool jumpRequest;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // ----------- INPUT ----------
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // ----------- DIRECCIÓN SEGÚN CÁMARA ----------
        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward.Normalize();
        camRight.Normalize();

        moveDirection = (camForward * v + camRight * h).normalized;

        // ----------- DETECCIÓN DE SUELO ----------
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

        // ----------- INPUT DE SALTO ----------
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jumpRequest = true;
        }
    }

    void FixedUpdate()
    {
        // ----------- MOVIMIENTO ----------
        if (moveDirection.magnitude > 0.1f)
        {
            Vector3 move = moveDirection * speed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + move);

            // Rotación
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            rb.MoveRotation(Quaternion.Slerp(
                rb.rotation,
                targetRotation,
                rotationSpeed * Time.fixedDeltaTime
            ));
        }

        // ----------- SALTO ----------
        if (jumpRequest)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
            jumpRequest = false;
        }
    }
}