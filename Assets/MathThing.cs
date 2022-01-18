using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathThing : MonoBehaviour
{
    [Range(0f, 4f)] public float radius = 1f;

    public GameObject player;

    private void Update()
    {
        throw new NotImplementedException();
    }

    private void OnDrawGizmos()
    {
        Vector3 goalPos = transform.position;
        Vector3 playerPos = player.transform.position;

        Vector3 relativePos = playerPos - goalPos;
        
        
        
        float distance = Vector3.Distance(goalPos, playerPos);
        //   ==
        float dist = relativePos.magnitude;
        bool isWithinRadius = distance < radius;


        
        float distSq = relativePos.sqrMagnitude;  // does not do sqrt // Optimation stuff
        bool isWithin = distSq < radius * radius;
        
        
        Gizmos.DrawLine(goalPos, playerPos);

        Gizmos.color = isWithinRadius ? Color.green : Color.red;
        Gizmos.DrawWireSphere(goalPos, radius);

        Gizmos.color = isWithin ? Color.yellow : Color.magenta;
        Gizmos.DrawWireSphere(goalPos, radius+.5f );

    }
    
    /*        FREYAS VERSION
    void OnDrawGizmos() {
        Vector3 goalPos = transform.position;
        Vector3 playerPos = playerTransform.position;

        // vector from goal to player
        Vector3 relPlayerPos = playerPos - goalPos;

        // less optimized version, but using actual distances
        float dist = relPlayerPos.magnitude; // sqrt is here
        bool isWithinRadius = dist < radius;

        // optimized version:
        //float distSq = relPlayerPos.sqrMagnitude; // does not do sqrt!
        //bool isWithinRadius = distSq < radius*radius;

        Gizmos.DrawLine( goalPos, goalPos + relPlayerPos );
        Gizmos.color = isWithinRadius ? Color.green : Color.red;
        Gizmos.DrawWireSphere( goalPos, radius );
    }*/
    /* // FREYA 2nd part
    void OnDrawGizmos() {
        Vector2 goalPos = transform.position;
        Vector2 playerPos = playerTransform.position;

        // vector from goal to player
        Vector2 relPlayerPos = playerPos - goalPos;


        // less optimized version, but using actual distances
        float dist = relPlayerPos.magnitude; // sqrt is here
        bool isWithinRadius = dist < radius;

        // optimized version:
        //float distSq = relPlayerPos.sqrMagnitude; // does not do sqrt!
        //bool isWithinRadius = distSq < radius*radius;

        // get direction to player
        Vector2 dirToPlayer = relPlayerPos.normalized;

        Gizmos.color = Color.green;

        // draw dot thingy
        Vector2 thingPos = dirToPlayer * distanceFromGoal; // calculate dot position along the direction
        Gizmos.DrawSphere( goalPos + thingPos, 0.03f );

        // draw offset dot thingies
        Vector2 tangent = new Vector2( -dirToPlayer.y, dirToPlayer.x ); // rotate 90 degrees CCW
        Gizmos.DrawSphere( goalPos + thingPos + tangent * barrelSeparation, 0.03f );
        Gizmos.DrawSphere( goalPos + thingPos - tangent * barrelSeparation, 0.03f );

        // draw line from goal to player
        Gizmos.DrawLine( goalPos, goalPos + dirToPlayer );

        // draw circular trigger
        Gizmos.color = isWithinRadius ? Color.green : Color.red;
        Gizmos.DrawWireSphere( goalPos, radius );
    }*/
    

}
