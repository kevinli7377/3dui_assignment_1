using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyRoomCreatureRotation : MonoBehaviour
{
    public float rotationAngle = 15.0f;
    void Update()
    {
        transform.Rotate(new Vector3(0, rotationAngle, 0) * Time.deltaTime);
    }
}
