using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrbShooter : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject orbPrefab;
    public Slider slider;
    public RectTransform aimTransform;

    public float rotationAmount;

    public float force;
    public float aimMovementAmount;

    void Start()
    {
        rotationAmount = 20.0f;
        force = 10.0f;
        aimMovementAmount = 15;
    }

    public void Shoot(){
        // shoot the orb
        GameObject orb = Instantiate(orbPrefab, spawnPoint.position,spawnPoint.rotation);
        Rigidbody rb = orb.GetComponent<Rigidbody>();
        rb.AddForce(spawnPoint.forward * force, ForceMode.VelocityChange);
    }


    public void SetShootAngle()
    {
        float rotationAngle = Mathf.Lerp(-rotationAmount, rotationAmount, (slider.value - slider.minValue) / (slider.maxValue - slider.minValue));

        // Apply rotation in local space, relative to camera parent
        Vector3 localRotation = spawnPoint.localEulerAngles;
        localRotation.y = rotationAngle;
        spawnPoint.localEulerAngles = localRotation;

        Vector3 position = aimTransform.anchoredPosition;
        position.x = slider.value * aimMovementAmount;
        aimTransform.anchoredPosition = position;
    }


}
