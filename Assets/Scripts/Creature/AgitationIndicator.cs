using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgitationIndicator : MonoBehaviour
{

    // Code to update the projectiles floating around creatures

    public Transform center;

    void Update()
    { 
        transform.RotateAround(center.position, Vector3.up, 15 * Time.deltaTime);
    }
}
