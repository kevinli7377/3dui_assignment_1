using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureRange : MonoBehaviour
{
    // Code to control behavior of capture range and whether to display

    private SpriteRenderer spriteRenderer;
    public bool isInRange;

    void Start()
    {
        // Initialization
        Transform captureRangeVisual = transform.Find("CaptureRangeVisual");
        spriteRenderer = captureRangeVisual.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = true;

    }

    void OnTriggerEnter(Collider other) // If player enters capture range
    {
        if (other.CompareTag("Player"))
        {
            spriteRenderer.enabled = false;
            isInRange = true;
        }
    }

    void OnTriggerExit(Collider other) // If player exits capture range
    {
        if (other.CompareTag("Player"))
        {
            spriteRenderer.enabled = true;
            isInRange = false;

        }
    }

    
}
