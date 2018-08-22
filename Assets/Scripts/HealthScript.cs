using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class HealthScript : MonoBehaviour
{
    ColorGrading colorGrader;
    Vignette vignette;
    PostProcessVolume volume;
    public bool damaged;
    float blue = 1;
    float green = 1;

	// Use this for initialization
	void Start ()
    {
        damaged = false;

        vignette = ScriptableObject.CreateInstance<Vignette>();
        vignette.enabled.Override(true);
        vignette.intensity.Override(0f);
        vignette.color.Override(new Color(1, green, blue)); 

        volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, vignette);

        colorGrader = ScriptableObject.CreateInstance<ColorGrading>();
        colorGrader.enabled.Override(true);
        colorGrader.colorFilter.Override(new Color(1f, green, blue,1));

	}

    void Damaged()
    {
        green -= .1f;
        blue -= .1f;

        vignette.intensity.value+= .1f;   
        colorGrader.colorFilter.Override(new Color(1f, green, blue));
        vignette.color.Override(new Color(1, green, blue));
        damaged = false;
    }

    private void OnDestroy()
    {
        RuntimeUtilities.DestroyVolume(volume, true, true);
    }

    // Update is called once per frame
    void Update ()
    {
		if(damaged == true)
        {
            Damaged();
        }
	}
}
