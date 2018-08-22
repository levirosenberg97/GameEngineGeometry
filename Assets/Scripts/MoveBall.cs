using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
	void Start ()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.right * speed, ForceMode.Force);
	}
}
