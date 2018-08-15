using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public RectTransform UIElement;

    public bool bringUp;

    private void Start()
    {

    }

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
            UIElement.position = Vector3.Lerp(UIElement.position, new Vector3(UIElement.position.x, Screen.height / 2), Time.deltaTime * 2);
        }
        else
        {
            UIElement.position = Vector3.Lerp(UIElement.position, new Vector3(UIElement.position.x, Screen.height / 25), Time.deltaTime * 2);
        }
    }

}
