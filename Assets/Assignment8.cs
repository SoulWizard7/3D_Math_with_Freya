using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment8 : MonoBehaviour
{
    [Range(0, 180)] public float deg;
    [Range(0, 20)] public float fovLength;

    private Vector3 rightDir;
    private Vector3 leftDir;
    private Vector3 camera;
    
    private float TAU = 6.28318530718f;

    public GameObject box;

    private void Update()
    {
        camera = Camera.main.transform.position;
        bool infront;

        float radiance = (deg / 2) * Mathf.Deg2Rad;

        // sin and cos switched out, alternatively subtract 180degrees
        rightDir = new Vector3(Mathf.Sin(radiance),  0,Mathf.Cos(radiance)).normalized * fovLength + camera;
        leftDir = new Vector3(-Mathf.Sin(radiance),  0,Mathf.Cos(radiance)).normalized * fovLength + camera;

        Vector3 boxPos = (box.transform.position - camera);
        float crossProduct = Vector3.Dot(camera, boxPos);

        

        Vector3 relativePos = Camera.main.transform.InverseTransformPoint(boxPos);
        float angle = Mathf.Atan2(boxPos.x, boxPos.z) * Mathf.Rad2Deg;

        float distance = Vector3.Distance(camera, box.transform.position);
        
        
        //Debug.Log(distance);
        //Debug.Log(deg);

        if (crossProduct < 0)
        {
            if (angle < (deg / 2) && angle > -(deg / 2) && distance < fovLength)
            {
                Debug.Log("inside FoV");
            }
            else
            {
                Debug.Log("nope");
            }
            //Debug.Log("box is infront of camera");
        }
        else
        {
            
            Debug.Log("box is behind of camera");
        }
        
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawWireSphere(camera, fovLength);
        Gizmos.color = Color.white;
        Gizmos.DrawLine(camera, rightDir);
        Gizmos.DrawLine(camera, leftDir);
    }
}
