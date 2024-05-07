using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbLifetime : MonoBehaviour
{
    public float lifetime = 3.0f;
    private float currentTime = 0;

    void Start()
    {
        GameObject pool = GameObject.FindGameObjectWithTag("Pond");
        // Ignore collision with the pools collider ot allow pools to travel in air space of pool area
        Physics.IgnoreCollision(pool.GetComponent<SphereCollider>(), GetComponent<SphereCollider>());
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > lifetime)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("LandCreature") ||
                        collision.gameObject.CompareTag("AirCreature") ||
                        collision.gameObject.CompareTag("SeaCreature") ||
                        collision.gameObject.CompareTag("Pond"))
        {
            Destroy(gameObject);
        }
    }
}
