using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeStuff : MonoBehaviour
{
    public Transform dog;
    
    private void OnDrawGizmos()
    {
        
        Vector2 dogInversePoint = transform.InverseTransformPoint(dog.position);
        
        print(dogInversePoint);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(dogInversePoint, Vector3.zero);
        Gizmos.DrawLine(transform.position, dog.position);
        

        Vector2 dogPoint = transform.TransformPoint(dog.localPosition);
        
        Gizmos.color = Color.red;
        Gizmos.DrawLine(dogPoint, Vector3.zero);
        /*Gizmos.color = Color.magenta;
        Gizmos.DrawLine(dog.position, Vector3.zero);
        Gizmos.DrawLine(transform.position, dogPoint);*/

        Vector2 dogVector = transform.TransformVector(dog.position);


    }
}
