using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    public Transform player;
    public CaptureRange captureRange;
    public float rotationSpeed;

    public bool isFacingPlayer;

    void Start()
    {
        // Initialized
        player = GameObject.FindGameObjectWithTag("Player").transform;
        captureRange = GetComponentInChildren<CaptureRange>();
        isFacingPlayer = false;
    }

    void Update()
    {
        if(captureRange.isInRange) // If player in capture range
        {
            Rotate(); // Rotate to face player
            CheckFacingPlayer();
        }
    }

    private void Rotate()
    {
        Vector3 dir = (player.position - transform.position).normalized;
        dir.y = 0;
        Vector3 newDir = Vector3.RotateTowards(transform.forward,dir,rotationSpeed*Time.deltaTime,0);

        transform.rotation = Quaternion.LookRotation(newDir);
    }

    private void CheckFacingPlayer() // Check if facing player
    {
        Vector3 dir = (player.position - transform.position).normalized;
        isFacingPlayer = Vector3.Dot(transform.forward, dir) > 0.99f; // If facing player, forward should be parallel to dir
    }
}
