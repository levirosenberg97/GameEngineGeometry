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
        rippleMat.SetColor("_PrimaryColor", Color.red);
        smokeMat.SetColor("_TintColor", Color.red);
        fireMat.SetColor("_Color", Color.red);
    }

    public void ChangeToBlue()
    {
        rippleMat.SetColor("_PrimaryColor", Color.cyan);
        smokeMat.SetColor("_TintColor", Color.cyan);
        fireMat.SetColor("_Color", Color.cyan);
    }

    public void ChangeToGreen()
    {
        rippleMat.SetColor("_PrimaryColor", Color.green);
        smokeMat.SetColor("_TintColor", Color.green);
        fireMat.SetColor("_Color", Color.green);
    }

}
