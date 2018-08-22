using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public RectTransform UIElement;

    public Animator anim;

    public bool bringUp;

    public void LowerTab()
    {
        bringUp = false;
    }

    public void BringUpTab()
    {
        if(bringUp == true)
        {
            bringUp = false;
        }
        else
        {
            bringUp = true;
        }

    }


    private void Update()
    {
        if(bringUp == true)
        {
            UIElement.position = Vector3.Lerp(UIElement.position, new Vector3(UIElement.position.x, Screen.height / 2), Time.deltaTime * 5);
        }
        else
        {
            UIElement.position = Vector3.Lerp(UIElement.position, new Vector3(UIElement.position.x, Screen.height / 25), Time.deltaTime * 5);
        }
    }

}
