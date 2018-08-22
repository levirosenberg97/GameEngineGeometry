using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitch : MonoBehaviour
{
    public CinemachineVirtualCamera cam1;
    public CinemachineVirtualCamera cam2;
    public CinemachineVirtualCamera cam3;

    public void FirstCamera()
    {
        cam1.Priority = 50;
        cam2.Priority = 1;
        cam3.Priority = 1;
    }

    public void SecondCamera()
    {
        cam1.Priority = 1;
        cam2.Priority = 50;
        cam3.Priority = 1;
    }

    public void ThirdCamera()
    {
        cam1.Priority = 1;
        cam2.Priority = 1;
        cam3.Priority = 50;
    }

}
