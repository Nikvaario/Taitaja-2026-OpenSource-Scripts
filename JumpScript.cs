using UnityEngine;
using UnityEngine.InputSystem;

public class JumpScript : MonoBehaviour
{
    [SerializeField] float jumpForce;
    [SerializeField] float groundCheckDistance = 1.01f;
    [SerializeField] LayerMask groundLayer;
    private bool isGrounded = false;

    private Rigidbody rb;
    private PlayerInput playerInput;
    private InputAction jumpAction;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        jumpAction = playerInput.actions.FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpAction.WasPressedThisFrame() && isGrounded) Jump();
        PerformGroundCheck();
    }

    void Jump(){
        rb.AddForce(Vector3.up * jumpForce * 1000);
    }

    void PerformGroundCheck(){
        if (Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer)){
            isGrounded = true;
        } else {
            isGrounded = false;
            rb.AddForce(Vector3.down * 9.81f * rb.mass);
        }
    }
}
