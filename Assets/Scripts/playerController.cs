using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    public float speed = 5f;

    public float jumpForce = 2.5f;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;

    private Rigidbody rb;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.position += new Vector3(horizontalInput, 0, verticalInput) * speed * Time.deltaTime;

        // Check if the player is grounded
        isGrounded = Physics.CheckSphere(transform.position, groundCheckRadius, groundLayer);

        // Jump if the player is grounded and the jump button is pressed
        if (isGrounded && Input.GetKeyDown(KeyCode.Space)) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

        void OnDrawGizmosSelected() {
        // Draw a wire sphere to show the ground check radius
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, groundCheckRadius);
    }
}
