using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotProductThing : MonoBehaviour
{
    public Vector2 startPoint;
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine( transform.right, -transform.right );

        Vector2 surfaceNormal = transform.up; // surface normal
        
        float dot = Vector2.Dot(startPoint, surfaceNormal);

        Vector2 projPos = surfaceNormal * dot;

        Vector2 blueLine = (startPoint - projPos);

        Vector2 newRaycastDirection = (projPos - blueLine).normalized;
        
        RaycastHit2D ray2 = Physics2D.Raycast(Vector2.zero, newRaycastDirection, Mathf.Infinity);
        
        
        
        
        
        
        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector2.zero, startPoint);
        
        Gizmos.color = Color.magenta;        
        Gizmos.DrawLine( blueLine, projPos );
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine( Vector2.zero, ray2.point );
        
        Gizmos.DrawWireSphere(ray2.point, 0.5f);
        
        RaycastHit2D ray1 = Physics2D.Raycast(startPoint, Vector2.zero, Mathf.Infinity);
        /* 
         Gizmos.color = Color.green;
         Gizmos.DrawLine( Vector2.zero, projPos );        
         Gizmos.color = Color.blue;
         Gizmos.DrawLine( startPoint, projPos ); 
         Gizmos.color = Color.cyan;
         Gizmos.DrawLine( Vector2.zero, surfaceNormal );
          Gizmos.color = Color.magenta;        
        Gizmos.DrawLine( blueLine, projPos );
         */
    }
    /*
    void OnDrawGizmos() {
        Vector2 surfaceNormal = transform.up; // surface normal
        float dot = Vector2.Dot( velocity, surfaceNormal );
        float impactSpeed = -dot;
        // Audio.PlaySound( impactSpeed, audioClip );

        Vector2 projPos = surfaceNormal * dot;

        Gizmos.DrawLine( transform.right, -transform.right );
        Gizmos.DrawLine( Vector2.zero, projPos );
        Gizmos.DrawLine( velocity, projPos );

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine( Vector2.zero, surfaceNormal );

        Gizmos.color = Color.red;
        Gizmos.DrawLine( Vector2.zero, velocity );
    }*/
    
}
