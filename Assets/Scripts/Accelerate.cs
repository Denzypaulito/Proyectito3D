using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerate : MonoBehaviour
{
    public PrometeoCarController carController; // Reference to the PrometeoCarController script
    void Start()
    {

    }
    void Update()
    {
        // Assuming you have a reference to the PrometeoCarController script.
        // You can access the accelerationMultiplier parameter like this:
        int accelerationMultiplierValue = carController.accelerationMultiplier;
        float maxSpeedValue = carController.carSpeed;
        // Now you can use the 'accelerationMultiplierValue' in this script.
        //Debug.Log("Acceleration Multiplier: " + accelerationMultiplierValue);
    }
}

