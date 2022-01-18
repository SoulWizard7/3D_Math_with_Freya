using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    public float minRange;
    public float maxRange;
    public float maxDamage = 500f;

    public Transform player;
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, minRange);
        Gizmos.DrawWireSphere(transform.position, maxRange);

        float damage = GetDamage(player.transform.position);
        Debug.Log(damage);

    }


    float GetDamage(Vector3 position)
    {
        float dist = Vector3.Distance(transform.position, position);
        return Remap(maxRange, minRange,  maxDamage,0, dist);

    }

    static float Remap(float iMin, float iMax, float oMin, float oMax, float v)
    {
        float t = Mathf.InverseLerp(iMax, iMin, v);
        return Mathf.Lerp(oMin, oMax, t);
    }
    
}
