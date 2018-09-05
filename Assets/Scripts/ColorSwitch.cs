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
        rippleMat.SetColor("_SecondaryColor", Color.red);
        smokeMat.SetColor("_TintColor", Color.red);
        fireMat.SetColor("_TintColor", Color.red);
    }

    public void ChangeToBlue()
    {
        rippleMat.SetColor("_SecondaryColor", Color.cyan);
        smokeMat.SetColor("_TintColor", Color.cyan);
        fireMat.SetColor("_TintColor", Color.cyan);
    }

    public void ChangeToGreen()
    {
        rippleMat.SetColor("_SecondaryColor", Color.green);
        smokeMat.SetColor("_TintColor", Color.green);
        fireMat.SetColor("_TintColor", Color.green);
    }

}
