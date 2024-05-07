using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyRoomController : MonoBehaviour
{

    public GameObject partyRoomCamera;

    void Update()
    {
        // Should only run if the partyRoomCamera is on
        if(partyRoomCamera.activeInHierarchy && Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = partyRoomCamera.GetComponent<Camera>().ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.CompareTag("LandCreature") ||
                        hit.collider.gameObject.CompareTag("AirCreature") ||
                        hit.collider.gameObject.CompareTag("SeaCreature"))
                    {
                        hit.collider.gameObject.GetComponent<PartyRoomDance>().ToggleDance();
                    }
                }
            }
        }
    }
}
