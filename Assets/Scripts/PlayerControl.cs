using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    Animator anim;
    bool isMoving;
    public LayerMask groundLayers;
    public float jumpForce = 7;
    CapsuleCollider col;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        anim = GetComponent<Animator>();
    }

    bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x,
                              col.bounds.min.y, col.bounds.center.z),
                              col.radius * .9f, groundLayers);
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Debug.Log("Jump");
    }

    void Move()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalMovement, 0f, verticalMovement);

        Vector3 desiredVelocity = movement.normalized * speed;
        //rb.AddForce(movement * speed);
        rb.AddForce(desiredVelocity - rb.velocity, ForceMode.Impulse);
    }

    private void Update()
    {
        anim.SetFloat("Speed", rb.velocity.magnitude);                
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
}
