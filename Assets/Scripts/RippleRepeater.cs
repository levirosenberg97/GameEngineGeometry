using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RippleRepeater : MonoBehaviour
{
    public GameObject plane;
    public float planeWidth;
    public float planeHeight;

    public float maximumValue;
    public float maxWidth;
    public float speed;

    public Material mat;
    public GameObject smoke;
    public GameObject fire;

    bool collided;
    Vector3 collisionPoint;

    ParticleSystem fireParticles;
    ParticleSystem smokeParticles;
    float distance = 0.0f;
    float particleDistance;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ball")
        {
            collided = true;
            ResetValues();
            collisionPoint = collision.contacts[0].point;
            Vector2 newOffset;
           
            mat.SetVector("_RippleOrigin", collisionPoint);
            float offsetX = (collision.gameObject.transform.position.x - plane.transform.position.x) / planeWidth;
            float offsetY = (collision.gameObject.transform.position.z - plane.transform.position.z) / planeHeight;
            
            newOffset = new Vector2(offsetX, offsetY);
            mat.SetTextureOffset("_MainTex", newOffset * 0.1f);

            
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

    public void ResetValues()
    {
        var fireShape = fireParticles.shape;
        fireShape.radius = 0;

        var smokeShape = smokeParticles.shape;
        smokeShape.radius = 0;

        particleDistance = 0;
        distance = 10f;
        width = 0f;

        mat.SetFloat("_RippleDistance", 0);
        mat.SetVector("_RippleOrigin", Vector4.zero);
        mat.SetFloat("_RippleWidth", .1f);
        
    }

    float width;

    private void Update()
    {
        if (collided == true)
        {
            var fireShape = fireParticles.shape;
            var smokeShape = smokeParticles.shape;
           

            mat.SetFloat("_RippleDistance", distance);
            mat.SetFloat("_RippleWidth", width);
            mat.SetFloat("_Transition", distance);

            distance -= Time.deltaTime * speed;
            particleDistance += Time.deltaTime * (speed + 1.5f);

            smokeShape.radius = particleDistance;
            fireShape.radius = particleDistance;


            if(width < maxWidth)
            {
                width += Time.deltaTime;
            }

            if(distance <= maximumValue)
            {
                Color newPrimary = mat.GetColor("_SecondaryColor");
                
                ResetValues();
                smoke.SetActive(false);
                fire.SetActive(false);
                collided = false;
            }
        }
       
    }
}
