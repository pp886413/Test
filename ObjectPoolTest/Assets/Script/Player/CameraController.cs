using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Camera sensitive
    [SerializeField]
    private float yawSensity = 10.0f;
    [SerializeField]
    private float pitchSensity = 10.0f;
    
    // Camera pitch up down limit 
    [SerializeField]
    private float maxPitchLimit = 30.0f; 
    [SerializeField]
    private float minPitchLimit = -30.0f;

    [SerializeField]
    private float yawDamping = 0.5f;
    [SerializeField]
    private float pitchDamping = 0.5f;

    // Camera yaw , pitch value 
    private float cameraYaw = 0.0f;
    private float cameraPitch = 0.0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        SetCameraYaw();
    }
    private void SetCameraYaw()
    {
        cameraYaw += Input.GetAxis("Mouse X") * yawSensity * yawDamping;
        cameraPitch -= Input.GetAxis("Mouse Y") * pitchSensity * pitchDamping;

        cameraPitch = Mathf.Clamp(cameraPitch, minPitchLimit, maxPitchLimit);

        transform.rotation = Quaternion.Euler(cameraPitch, cameraYaw, 0.0f);
    }
}
