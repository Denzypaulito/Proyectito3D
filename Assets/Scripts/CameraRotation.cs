using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public float tiltAngle = 30f;

    void Update()
    {
        // Rotar la cámara en círculos alrededor del eje Y
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // Inclinar la cámara hacia abajo
        Quaternion targetRotation = Quaternion.Euler(tiltAngle, transform.eulerAngles.y, transform.eulerAngles.z);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
    }
}
