using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{

    // Code for animations

    public Animator anim;
    public float current = 0;

    void Start()
    {
        anim=GetComponentInChildren<Animator>();
    }

    public void Jump()
    {
        anim.SetTrigger("Jump");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("JumpTrigger")) // Trigger on path of sea creature
        {
            if (current + 3 < Time.time) // If at least 3 seconds have passed
            {
                current = Time.time;
                Jump();
            }
        }
    }
}
