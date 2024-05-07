using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;
    public Transform spawnPoint;
    public CaptureRange captureRange;
    public GameObject projectilePrefab;
    public RotateToPlayer rotateToPlayer;

    public float force = 1.0f;
    public float delay = 3.0f;
    public float initialDelay = 1.5f;

    float timer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rotateToPlayer = gameObject.GetComponent<RotateToPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (captureRange.isInRange)
        {
            timer += Time.deltaTime;
            if (timer >= delay) // Added delay to prevent shooting projectile upon facing player
            {
                Shoot();
                timer = 0f;
            }
        } else
        {
            timer = initialDelay; // reset timer
        }
    }


    // The force could be proportional to the distance between the spawnpoint and the player
    public void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();

        // Calculate the distance between the spawn point and the player
        float distance = Vector3.Distance(spawnPoint.position, player.transform.position);

        // Apply the force proportional to the distance between player and creature.
        // Remove distance if proportionality not needed.
        rb.AddForce(spawnPoint.forward * force * distance, ForceMode.VelocityChange);
    }
}
