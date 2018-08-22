using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RippleRepeater : MonoBehaviour
{
    public float maximumValue;
    public float maxWidth;
    public float speed;
    bool collided;
    Vector3 collisionPoint;
    public Material mat;
    public GameObject smoke;
    public GameObject fire;
    ParticleSystem fireParticles;
    ParticleSystem smokeParticles;

    float distance = 0.0f;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ball")
        {
            collided = true;
            ResetValues();
            collisionPoint = collision.contacts[0].point;
            mat.SetVector("_RippleOrigin", collisionPoint);

            fire.transform.position = collisionPoint;
            fire.SetActive(true);

            smoke.transform.position = collisionPoint;
            smoke.SetActive(true);
        }
    }

    

    private void Start()
    {
        smokeParticles = smoke.GetComponent<ParticleSystem>();
        fireParticles = fire.GetComponent<ParticleSystem>();
        ResetValues();
    }

    void ResetValues()
    {
        var fireShape = fireParticles.shape;
        fireShape.radius = 0;

        var smokeShape = smokeParticles.shape;
        smokeShape.radius = 0;

        distance = 0f;
        width = 1;
        mat.SetFloat("_RippleDistance", 0);
        mat.SetVector("_RippleOrigin", Vector4.zero);
        mat.SetFloat("_RippleWidth", 1);
    }

    float width = 1;

    private void Update()
    {
        if (collided == true)
        {
            var fireShape = fireParticles.shape;
            var smokeShape = smokeParticles.shape;
            //Vector4 location = collisionPoint;

            mat.SetFloat("_RippleDistance", distance);
            mat.SetFloat("_RippleWidth", width);

            distance += Time.deltaTime * speed;
            smokeShape.radius = distance;
            fireShape.radius = distance;
            if(width < maxWidth)
            {
                width += Time.deltaTime * speed;
            }

            if(distance >= maximumValue)
            {
                ResetValues();
                smoke.SetActive(false);
                fire.SetActive(false);
                collided = false;
            }
        }
       
    }
}
