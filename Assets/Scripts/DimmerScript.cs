using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimmerScript : MonoBehaviour
{
    Light spotLight;
    public float dimTime;
    public bool startDim;
    public float newIntensity;
    float counter = 0;
    float maximum;

	// Use this for initialization
	void Start ()
    {
        spotLight = GetComponent<Light>();
        startDim = false;
        counter = 0;
	}
    float timePercentage;

    void IncreaseIntensity()
    {
        if (counter < dimTime)
        {
            timePercentage = counter / dimTime;
            if (spotLight.intensity != newIntensity)
            {
                spotLight.intensity += spotLight.intensity * timePercentage;
            }
            if (spotLight.intensity > newIntensity)
            {
                spotLight.intensity = newIntensity;
            }
        }
    }

    void DecreaseIntensity()
    {
        if(counter < dimTime)
        {
            timePercentage = counter / dimTime;
            if (spotLight.intensity != newIntensity)
            {
                spotLight.intensity -= spotLight.intensity * timePercentage;
            }
            if (spotLight.intensity < newIntensity)
            {
                spotLight.intensity = newIntensity;
            }
        }
    }

	// Update is called once per frame
	void Update ()
    {
        if (startDim == true)
        {
            counter += Time.deltaTime;
            if(newIntensity > spotLight.intensity)
            {
                IncreaseIntensity();
            }
            if(newIntensity < spotLight.intensity)
            {
                DecreaseIntensity();
            }

            if(spotLight.intensity == newIntensity)
            {
                startDim = false;
            }

        }
        if (startDim == false)
        {
            counter = 0;
        }
	}
}
