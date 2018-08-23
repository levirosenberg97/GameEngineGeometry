using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationSpeedController : MonoBehaviour
{
    public Slider speedSlider;
    public Animator anim;

	void Start ()
    {
        anim.speed = 0;
	}	

    public void BlendSpeed()
    {
        anim.speed = speedSlider.value;
    }
}
