using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    public Vector2 startPointRelativeToRayHit;
    private RaycastHit2D ray1;
    private RaycastHit2D ray2;
    private RaycastHit2D ray3;

    private Vector2 newDir;

    private Vector2 projPos;
    private Vector2 blueLine;
    

    public Transform spot;

    public LayerMask layerMask;

    public int timesToBounce = 10;
    
    void Update()
    {
        for (int i = 0; i < timesToBounce; i++)
        {
            
        }
        ray1 = Physics2D.Raycast(transform.position, transform.up, Mathf.Infinity);
        
        startPointRelativeToRayHit = (Vector2)transform.position - ray1.point;
        
        Vector2 surfaceNormal = ray1.normal;

        float dot = Vector2.Dot(startPointRelativeToRayHit, surfaceNormal);

        projPos = surfaceNormal * dot;

        Vector2 newRaycastDirection = startPointRelativeToRayHit - 2 * surfaceNormal * dot;

        ray2 = Physics2D.Raycast(ray1.point, -newRaycastDirection, Mathf.Infinity, layerMask);


        /*
        ray1 = Physics2D.Raycast(transform.position, transform.up, Mathf.Infinity);
        startPointRelativeToRayHit = (Vector2)transform.position - ray1.point;
        Vector2 surfaceNormal = ray1.normal;
        float dot = Vector2.Dot(startPointRelativeToRayHit, surfaceNormal);
        projPos = surfaceNormal * dot;
        blueLine = ((startPointRelativeToRayHit) - projPos);
        Vector2 newRaycastDirection = (projPos - blueLine).normalized;
        ray2 = Physics2D.Raycast(ray1.point, newRaycastDirection, Mathf.Infinity, layerMask);
        */
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        
        Gizmos.DrawLine(ray1.point, ray1.normal + ray1.point);
        
        Gizmos.color = Color.magenta;   
        //Gizmos.DrawLine( blueLine, projPos );
        
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, ray1.point);
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(ray1.point, ray2.point);
        
        
    }
    
    /*  FREYAS LAZER BOUNCE CODE
     
     
    public int maxBounceCount = 32;

    void OnDrawGizmos() {
        // ray origin
        // ray direction
        Ray ray = new Ray( transform.position, transform.right );

        for( int i = 0; i < maxBounceCount; i++ ) {
            if( Physics.Raycast( ray, out RaycastHit hit ) ) {
                Gizmos.color = Color.red;
                Gizmos.DrawLine( ray.origin, hit.point );
                // Gizmos.color = Color.cyan;
                // Gizmos.DrawRay( hit.point, hit.normal );
                // Gizmos.color = Color.white;
                Vector3 reflected = Reflect( ray.direction, hit.normal );
                // Gizmos.DrawRay( hit.point, reflected );

                // move ray to the new bounce location + direction
                ray.origin = hit.point + hit.normal * 0.001f; // tiny offset margin to avoid starting inside colliders
                ray.direction = reflected;
            } else {
                break; // no more bounces
            }
        }
    }

    Vector3 Reflect( Vector3 inDir, Vector3 normal ) {
        return inDir - 2 * normal * Vector3.Dot( normal, inDir );
    }*/
    
}
