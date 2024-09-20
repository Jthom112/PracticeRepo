using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 5, -10); // Offset from the player
    public float followSpeed = 10f; // Speed at which camera follows
    public float cameraTiltAngle = 30f; // Tilt angle in degrees

    private void LateUpdate()
    {
        // Smoothly follow the player
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        // Tilt the camera down by adjusting the X rotation (pitch)
        Vector3 cameraRotation = transform.eulerAngles;
        cameraRotation.x = cameraTiltAngle; // Set the desired tilt
        transform.eulerAngles = cameraRotation;

        // Optional: Adjust where the camera is looking
        transform.LookAt(player.position + Vector3.up * 1.5f); // Adjust height focus if needed
    }
}
