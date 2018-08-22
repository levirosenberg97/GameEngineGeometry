using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityLocomotion : MonoBehaviour
{
    public Animator anim;
    public Rigidbody rb;

	void Update ()
    {
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"),
                                    0.0f,
                                    Input.GetAxis("Vertical"));

        //rb.velocity = 
	}
}
