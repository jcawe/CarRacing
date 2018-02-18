using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarWheel : MonoBehaviour
{
    public WheelCollider target;
    
    // Update is called once per frame
    void Update()
    {
        Vector3 wheelPosition;
        Quaternion wheelRotation;

        target.GetWorldPose(out wheelPosition, out wheelRotation);
        transform.position = wheelPosition;
        transform.rotation = wheelRotation;
    }
}
