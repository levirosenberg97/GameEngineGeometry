using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityController : MonoBehaviour
{
    Animator anim;

    private void Update()
    {
        bool pose1 = Input.GetKeyDown(KeyCode.Q);
        bool pose2 = Input.GetKeyDown(KeyCode.W);
        bool pose3 = Input.GetKeyDown(KeyCode.E);

        if(pose1) { anim.SetTrigger("Pose"); }
        if(pose2) { anim.SetTrigger("Jump"); }
        if(pose3) { anim.SetTrigger("Hands"); }
    }

    public void Reset()
    {
        anim = GetComponent<Animator>();
    }
}
