using System;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementScript : MonoBehaviour
{
    [SerializeField] float speed;
    private Vector2 moveDirection;
    private Rigidbody rb;
    private PlayerInput playerInput;
    private InputAction moveAction;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Console.Write(rb.linearVelocity);
    }

    void Movement()
    {
        float movementSpeed = speed * 1000 * Time.deltaTime;
        moveDirection = moveAction.ReadValue<Vector2>();
        rb.AddForce(transform.forward * movementSpeed * moveDirection.y);
    }
}
