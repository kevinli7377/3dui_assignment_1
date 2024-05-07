using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Transform target;
    public Transform player;
    public CaptureRange captureRange;
    public float rotationSpeed = 1.0f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        captureRange = GetComponentInChildren<CaptureRange>();
    }

    void Update()
    {
        if (!captureRange.isInRange)
        {
            transform.RotateAround(target.position, transform.up, Time.deltaTime * rotationSpeed);
        }
    }
}
