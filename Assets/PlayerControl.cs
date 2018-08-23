using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    Animator anim;
    bool isMoving;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
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
        //Vector3.Lerp(rb.velocity, Vector3.zero, Time.deltaTime);
        //if(Input.GetKey(KeyCode.W)||
        //   Input.GetKey(KeyCode.A)||
        //   Input.GetKey(KeyCode.S)||
        //   Input.GetKey(KeyCode.D))
        //{
            //isMoving = true;

            
        //}
        //else
        //{
           // isMoving = false;
        //}
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();

        //if (isMoving == true)
        //{
        //    Move();
        //}
        //else
        //{
        //    rb.velocity = Vector3.zero;
        //}
    }
}
