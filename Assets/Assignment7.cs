using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment7 : MonoBehaviour
{
    
    [Range(2,100)]public int sides;
    [Range(1,40)]public int starInt;
    
    public float timer = 0;
    private void Update()
    {
        /*
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            sides++;
            timer = 0.8f;
        }*/
    }

    private void OnDrawGizmos()
    {
        float TAU = 6.28318530718f;
        float angle = (TAU / sides);
        
        Vector2 firstDot = transform.position;
        
        for (int i = 0; i < sides; i++)
        {
            float curAngle = ((i + 1) * angle) * starInt;
            
            Vector2 secondDot = new Vector2(Mathf.Cos(curAngle), Mathf.Sin(curAngle)) + firstDot;
            
            Gizmos.DrawLine(firstDot, secondDot);

            firstDot = secondDot;
        }
    }
}
