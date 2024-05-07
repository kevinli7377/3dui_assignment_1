using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject wonPanel;
    public GameObject allCaughtPanel;
    public GameObject gameOverPanel;

    public GameObject restartButton;

    public GameObject slider;
    public GameObject hearts;
    public GameObject joyStick;
    public GameObject cameraTouchPanel;
    public GameObject switchCameraButton;
    public GameObject throwOrbButton;
    public GameObject reticle;

    private void Start()
    {
        SetupUI();
    }

    public void SetupUI()
    {
        wonPanel.SetActive(false);
        allCaughtPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        restartButton.SetActive(false);

        slider.SetActive(true);
        hearts.SetActive(true);
        joyStick.SetActive(true);
        cameraTouchPanel.SetActive(true);
        switchCameraButton.SetActive(true);
        throwOrbButton.SetActive(true);
        reticle.SetActive(true);
    }

    public void ShowWonUI()
    {
        Debug.Log("One of each creature caught.");
        wonPanel.SetActive(true);
    }

    public void ShowCaughtAlUI()
    {
        Debug.Log("All Creatures Caught.");
        allCaughtPanel.SetActive(true);
        restartButton.SetActive(true);
    }

    public void ShowGameOverUI()
    {
        Debug.Log("GameOver");
        gameOverPanel.SetActive(true);
        slider.SetActive(false);
        joyStick.SetActive(false);
        cameraTouchPanel.SetActive(false);
        throwOrbButton.SetActive(false);
        switchCameraButton.SetActive(false);
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void ToggleCameraUI(bool isMainCamOn)
    {
        joyStick.SetActive(isMainCamOn);
        throwOrbButton.SetActive(isMainCamOn);
        slider.SetActive(isMainCamOn);
        reticle.SetActive(isMainCamOn);
    }
}
