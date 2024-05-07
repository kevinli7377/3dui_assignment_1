using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bob : MonoBehaviour
{
    public Transform player;
    public CaptureRange captureRange;

    public float amplitude = 1.0f;
    public float speed = 1.0f;

    private float time;
    private float originalY;

    private void Start()
    {
        // Initialization
        originalY = transform.position.y;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        captureRange = GetComponentInChildren<CaptureRange>();
    }

    void Update()
    {
        if (!captureRange.isInRange) // if player is not in capture range
        {
            // Continue to bob up and down 
            time += Time.deltaTime;
            float move = Mathf.Abs(Mathf.Sin(time * speed)) * amplitude;
            transform.position = new Vector3(transform.position.x, move + originalY, transform.position.z);
        }
    }
}
