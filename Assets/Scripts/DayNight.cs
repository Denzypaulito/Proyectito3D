using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    public float rotationScale = 0.25f;
    public Light sunLight; // Asigna la luz del sol desde el Inspector
    private float time = 720;


    void Update()
    {
        transform.Rotate(rotationScale * Time.deltaTime, 0, 0);
        time -= 1 * Time.deltaTime;
        if (transform.rotation.eulerAngles.x >= 360.0f)
        {
            // Reiniciar rotación a 0 grados después de 360 grados
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        // Ajustar la intensidad de la luz en función de la rotación
        float normalizedRotation = transform.rotation.eulerAngles.x / 180.0f;
        float intensity;
        if (normalizedRotation < 0.5f)
        {
            // Aumentar intensidad de 0.3 a 1 de 0 a 90 grados
            intensity = Mathf.Lerp(0.3f, 1f, normalizedRotation * 2);
        }
        else
        {

            // Disminuir intensidad de 1 a 0 de 90 a 180 grados
            intensity = Mathf.Lerp(1f, 0f, (normalizedRotation - 0.5f) * 2);
        }
        sunLight.intensity = intensity;
    }
}
