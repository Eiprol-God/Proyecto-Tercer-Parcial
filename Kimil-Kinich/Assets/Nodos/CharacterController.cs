using System;
using System.Collections;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public float speed = 3f;
    public float rotationSpeed = 720f;
    public Animator animator;
    private CharacterController controller;
    private Vector3 velocity;


    public float gravity = -8f;
    public float jumpHeight = 1.5f;
    public Transform cameraTransform;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
    }

    // Update is called once per frame
    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        animator.SetFloat("Speed", direction.magnitude);

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref rotationSpeed, 0.1f);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            animator.SetBool("IsJumping", true);
        }
        else if (controller.isGrounded)
        {
            animator.SetBool("IsJumping", false);
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("SpeedPower"))
        {
            speed = speed * 2;
            Destroy(other.gameObject);
            StartCoroutine(StopSpeedUp());
        }
    }

    private IEnumerator StopSpeedUp()
    {
        yield return new WaitForSeconds(5f);
        speed = speed / 2;
    }
}

