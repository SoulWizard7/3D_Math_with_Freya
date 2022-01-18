using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleToVector : MonoBehaviour
{
    const float TAU = 6.28318530718f;

    [Range( 0, TAU )] public float angle = 0;
    [Range( 0, 4 )] public float length = 0;

    void OnDrawGizmos() {
        Vector2 dir = AngToDir( angle );
        Gizmos.DrawRay( Vector3.zero, dir * length );
    }

    public static float DirToAng(Vector2 dir)
    {
        return Mathf.Atan2(dir.y, dir.x);
    }
    
    public static Vector2 AngToDir( float angRad ) {
        return new Vector2(
            Mathf.Cos( angRad ),
            Mathf.Sin( angRad )
        );
    }
    
    
}
