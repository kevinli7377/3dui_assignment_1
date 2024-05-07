using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour // Intermediary between touch input field and CameraLook
{
    public FixedTouchField _FixedTouchField;
    public CameraLook _CameraLook;
    void Start()
    {

    }


    void Update()
    {
        _CameraLook.LockAxis = _FixedTouchField.TouchDist;
        // Link the distance the user has dragged on the touch field to the camera's look direction
    }
}
