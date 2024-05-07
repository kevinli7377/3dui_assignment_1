using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{

    public GameObject mainCam;
    public GameObject partyRoomCam;

    public bool isMainCamOn;
    public bool isPartyCamOn;

    public UIManager uiManager;

    void Start()

    {
        //Initialize
        SwitchToMainCamera();
        isMainCamOn = true;
        isPartyCamOn = false;

        uiManager = GameObject.FindGameObjectWithTag("UI").GetComponent<UIManager>();
    }

    private void SwitchToMainCamera()
    {
        mainCam.SetActive(true);
        partyRoomCam.SetActive(false);
    }

    public void ToggleCamera()
    {
        mainCam.SetActive(!isMainCamOn);
        partyRoomCam.SetActive(!isPartyCamOn);

        isMainCamOn = !isMainCamOn;
        isPartyCamOn = !isPartyCamOn;

        uiManager.ToggleCameraUI(isMainCamOn);
    }
}
