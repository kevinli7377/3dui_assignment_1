using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureLife : MonoBehaviour
{
    public bool isCaught;
    public CaptureRange captureRange;
    public Transform startingPosTransform;
    public GameObject partyRoomCreature;

    public GameStateManager gameStateManager;

    void Start()
    {
        isCaught = false;
        partyRoomCreature.SetActive(false);
        captureRange = GetComponentInChildren<CaptureRange>();

        // Intialize the positions etc for the creature
        transform.position = startingPosTransform.position;
        transform.rotation = startingPosTransform.rotation;
        transform.localScale = startingPosTransform.localScale;

        // Find the gamestatemanager
        gameStateManager = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameStateManager>();
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.CompareTag("Orb") && captureRange.isInRange) // check if collision gameobject is orb and if player is in range
        {
            isCaught = true;
            // Toggle the active statues of the creature in the game
            // and its corresponding one in the party room
            partyRoomCreature.SetActive(true);
            gameObject.SetActive(false);

            // Report creature status to gameStateManager
            gameStateManager.ReportCreatureCaught(gameObject.tag);
        }
    }
}
