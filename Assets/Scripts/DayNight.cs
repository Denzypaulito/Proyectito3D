using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{

    public float rotationScale = 0.25f;
    private float time = 720;

    void Update()
    {
        transform.Rotate(rotationScale * Time.deltaTime, 0, 0);
        time -=1 * Time.deltaTime;
        Debug.Log(time);
        
    }
}
