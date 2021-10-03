using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FerrisWheelCar : MonoBehaviour
{
    public GameObject wheel;

    void Update()
    {

        //TODO: Didn't actually figure this out yet.
        // Get y rotation of wheel transform
        float wheelRotation = wheel.transform.rotation.eulerAngles.y;

        // Rotate car transform
        transform.rotation = Quaternion.Euler(0, -wheelRotation, 0);
    }
}

