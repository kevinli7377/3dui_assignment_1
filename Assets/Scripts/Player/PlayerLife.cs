using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public GameObject[] hearts;
    public bool isAlive;
    public float forceMultiplier = 10f;

    public GameStateManager gameStateManager;

    private int lifeCount;

    void Start()
    {
        lifeCount = hearts.Length;
        isAlive = true;
        gameStateManager = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameStateManager>();
    }

    public void TakeDamage(int d=1) // take damage
    {
        if (lifeCount >= 1)
        {
            lifeCount -= d;
            hearts[lifeCount].SetActive(false);
            if (lifeCount < 1)
            {
                isAlive = false;
                gameStateManager.ReportPlayerDeath(); // Report to gamestatemanager
            }
        }
    }


    void OnCollisionEnter(Collision other)  
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            TakeDamage();
        }
    }
}
