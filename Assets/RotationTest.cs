using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTest : MonoBehaviour
{
    public Transform vectorTransform;
    public float angle;
    public float rotateSpeedMultiplier = 2f;

    public Vector3 eulerAngles;
    
    private void Update()
    {
        // auto rotate
        angle = Mathf.Repeat(Time.time * rotateSpeedMultiplier, Mathf.PI * 2); // using time to repeat from 0 to 1
    }
    
    private void OnDrawGizmos()
    {
        Vector3 angleAxis = vectorTransform.position;

        Vector3 axis = angleAxis.normalized;
        //angle = angleAxis.magnitude;
        
        // convert from angle-axis to quaternion (rad2deg becomes 1 TAO = 360degrees)
        Quaternion rotation = Quaternion.AngleAxis( angle * Mathf.Rad2Deg, axis);
        transform.rotation = rotation;
        
        Quaternion offset = Quaternion.Euler(eulerAngles.x, eulerAngles.y, eulerAngles.z);
        
        
        Gizmos.DrawLine(transform.position, vectorTransform.position);
    }
}
