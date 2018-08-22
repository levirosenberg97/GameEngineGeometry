using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwitch : MonoBehaviour
{
    public Material rippleMat;
    public Material smokeMat;
    public Material fireMat;
	
    public void ChangeToRed()
    {
        smokeMat.SetColor("_TintColor", Color.red);
        fireMat.SetColor("_TintColor", Color.red);
        rippleMat.color = Color.red;
    }

    public void ChangeToBlue()
    {
        rippleMat.color = Color.cyan;
        smokeMat.SetColor("_TintColor", Color.cyan);
        fireMat.SetColor("_TintColor", Color.cyan);
    }

    public void ChangeToGreen()
    {
        rippleMat.color = Color.green;
        smokeMat.SetColor("_TintColor", Color.green);
        fireMat.SetColor("_TintColor", Color.green);
    }

}
