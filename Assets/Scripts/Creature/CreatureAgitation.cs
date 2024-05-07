using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureAgitation : MonoBehaviour
{

    public GameObject player;
    public CaptureRange captureRange;
    public AgitationIndicator agitationIndicator;

    public bool isAgitated;


    void Start()
    {
        ExitAgitationMode();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (captureRange.isInRange) // Constantly check if player enters capture range
        {
            EnterAgitationMode();
        } else
        {
            ExitAgitationMode();
        }
    }

    private void EnterAgitationMode()
    {
        isAgitated = true;
        agitationIndicator.gameObject.SetActive(true);
    }

    private void ExitAgitationMode()
    {
        isAgitated = false;
        agitationIndicator.gameObject.SetActive(false);
    }
}
