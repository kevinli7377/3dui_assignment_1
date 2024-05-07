using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glide : MonoBehaviour
{
    public Transform player;
    public CaptureRange captureRange;
    public Transform[] points; // Predefine points for translation movement; landcreature
    public float moveSpeed = 2.0f;

    private int current; // Used for point indexing

    void Start()
    {
        // Initialize
        current = 0; // Index for points
        player = GameObject.FindGameObjectWithTag("Player").transform;
        captureRange = GetComponentInChildren<CaptureRange>();
    }

    void Update()
    {
        if (!captureRange.isInRange) // If player not in capture range, mvove
        {
            Move();
        }
    }

    private void Move()
    {
        // Move to the next position
        Vector3 nextPosition = points[current].position;
        nextPosition.y = transform.position.y;

        if (transform.position != nextPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPosition, moveSpeed * Time.deltaTime);
        }
        else
            current = (current + 1) % points.Length;
    }
}
