using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{

    private float XMove; // Up and down
    private float YMove; // Let and right
    private float XRotation;
    [SerializeField] private Transform PlayerBody;
    public Vector2 LockAxis;
    public float Sensitivity = 40f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        XMove = LockAxis.x * Sensitivity * Time.deltaTime;
        YMove = LockAxis.y * Sensitivity * Time.deltaTime;
        XRotation -= YMove;
        XRotation = Mathf.Clamp(XRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(XRotation, transform.localEulerAngles.y, 0);

        // Create a quaternion for Y rotation and apply it to the PlayerBody
        Quaternion yQuaternion = Quaternion.Euler(0f, XMove, 0f);
        PlayerBody.rotation *= yQuaternion; // This applies the rotation in the PlayerBody's local space
    }
}
