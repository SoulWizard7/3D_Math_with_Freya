using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment2and3 : MonoBehaviour
{
    public Vector2 localPos;
    public Vector2 localPos2;

    public Vector2 worldInputPos;
    public Vector2 localInputPos;

    public Vector2 w; // worldpos
    
    private void OnDrawGizmos()
    {
        //Assignment 2 - LOCAL TO WORLD POS
        Transform tf = transform;
        
        Vector2 worldPos = tf.position + tf.right * localPos.x + tf.up * localPos.y;
        //          ==
        //Vector2 worldPos = transform.TransformPoint(localPos);
        
        
        
        //Assignment 3 - World to local
        Vector2 op = tf.position;
        Vector2 relativeWorldPos = w - op;
        Vector2 localPos2 = new Vector2(
            Vector2.Dot(tf.right, relativeWorldPos), //local x
            Vector2.Dot(tf.up, relativeWorldPos)     //local y
            );
        //Vector2 localPos2 = tf.InverseTransformPoint(localPos);



    }
    
    
    /* FREYAS CODES ON WORLD TO LOCAL - LOCAL TO WORLD 
     
    public Vector2 localInputPos;
    public Vector2 w; // world position

    [Header( "Debug:" )]
    public Vector2 debugLocalPos; // read only

    void OnDrawGizmos() {
        Transform tf = transform;
        
        // assignment #2 (Local to world)
        //Vector2 worldPos = tf.position + tf.right * localInputPos.x + tf.up * localInputPos.y; // local to world
        //Vector3 worldPos = (Vector2)(tf.localToWorldMatrix * new Vector4( localInputPos.x, localInputPos.y, 0, 1 ));
        Vector2 worldPos = tf.TransformPoint( localInputPos ); // local to world
        Gizmos.DrawSphere( worldPos, 0.05f );


        // assignment #3 (World to local)
        //Gizmos.DrawSphere( w, 0.05f );
        /*Vector2 op = tf.position;
        Vector2 relWorldPos = w - op;
        Vector2 localPos = new Vector2(
            Vector2.Dot( tf.right, relWorldPos ),     // local x component
            Vector2.Dot( tf.up, relWorldPos )        // local y component
        );*/
    
    /*
        
        Vector2 localPos = tf.InverseTransformPoint( w ); // world to local

        debugLocalPos = localPos;
    */
    
    
}
