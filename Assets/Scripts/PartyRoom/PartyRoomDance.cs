using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyRoomDance : MonoBehaviour
{

    public bool isDancing;
    public Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ToggleDance()
    {
        if (isDancing)
        {
            StopDancing();
        } else
        {
            Dance();
        }
    }

    public void Dance()
    {
        // Dancing animation/code
        isDancing = true;
        anim.SetTrigger("PartyDance");
    }

    public void StopDancing()
    {
        isDancing = false;
        anim.SetTrigger("StopDancing");
    }
}
