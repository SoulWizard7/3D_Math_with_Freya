using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyLazer : MonoBehaviour
{
    public int timesToBounce = 10;
    

    private void OnDrawGizmos()
    {
        Ray ray = new Ray(transform.position, transform.up);
        for (int i = 0; i < timesToBounce; i++)
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(ray.origin, hit.point);

                Vector2 normal = hit.normal;
                float dot = Vector2.Dot(ray.origin, normal);
                
                Vector2 newDir = (Vector2)ray.origin - 2 * normal * dot;

                ray.origin = hit.point;
                ray.direction = newDir;

            }
            else
            {
                break;
            }
            
            /*
            ray1 = Physics2D.Raycast(transform.position, transform.up, Mathf.Infinity);
        
            startPointRelativeToRayHit = (Vector2)transform.position - ray1.point;
            Vector2 surfaceNormal = ray1.normal;
            float dot = Vector2.Dot(startPointRelativeToRayHit, surfaceNormal);
            projPos = surfaceNormal * dot;
            Vector2 newRaycastDirection = startPointRelativeToRayHit - 2 * surfaceNormal * dot;
            ray2 = Physics2D.Raycast(ray1.point, -newRaycastDirection, Mathf.Infinity, layerMask);*/
        }
    }
}
