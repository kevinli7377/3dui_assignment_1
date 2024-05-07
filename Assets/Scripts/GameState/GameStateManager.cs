using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public int[] creaturesCaught; // Array to keep track of creatures caught in order: Land, Air, Sea

    public bool hasWon;
    public bool hasCaughtAllCreatures;

    public UIManager uiManager;

    private void Start()
    {
        creaturesCaught = new int[3] { 0, 0, 0 };
        hasWon = false;
        hasCaughtAllCreatures = false;
        uiManager = GameObject.FindGameObjectWithTag("UI").GetComponent<UIManager>();

        // Render instructions interface
    }

    public void ReportPlayerDeath()
    {
        GameOver();
    }

    public void ReportCreatureCaught(string tag)
    {

        // Update the caught status based on input
        // 1 - "LandCreature
        // 2 - "AirCreature"
        // 3 - "SeaCreature"

        if (tag == "LandCreature")
            creaturesCaught[0] += 1;
        if (tag == "AirCreature")
            creaturesCaught[1] += 1;
        if (tag == "SeaCreature")
            creaturesCaught[2] += 1;

        WinChecker();
    }

    public void WinChecker()
    {
        // Checks if winning conditions have been met.
        // Called when a creature is caught.

        if (!hasWon && creaturesCaught[0] >= 1 && creaturesCaught[1] >= 1 && creaturesCaught[2] >= 1)
        {
            hasWon = true;
            WonUI(); // Only triggered once; conditional above
        }

        if (!hasCaughtAllCreatures && creaturesCaught[0] >= 2 && creaturesCaught[1] >= 2 && creaturesCaught[2] >= 2)
        {
            hasCaughtAllCreatures = true;
            CaughtAllUI();
        }
    }

    // Functions to control UI
    private void WonUI()
    {
        uiManager.ShowWonUI();
    }

    private void CaughtAllUI()
    {
        uiManager.ShowCaughtAlUI();
    }

    private void GameOver()
    {
        uiManager.ShowGameOverUI();
    }

    // Restart function
    public void Restart()
    {
        // Reload scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Quit application
    public void Quit()
    {
        Application.Quit();
    }

    
}
