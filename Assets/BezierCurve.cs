using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class BezierCurve : MonoBehaviour
{
    [Range(-1f, 2f)] public float t = 0f;

    private Vector2 A => transform.GetChild(0).position;
    private Vector2 B => transform.GetChild(1).position;
    private Vector2 C => transform.GetChild(2).position;
    private Vector2 D => transform.GetChild(3).position;

    public AnimationCurve _curve;

    private void Update()
    {
        //t = Mathf.Repeat(Time.time / 2, 1); // using time to repeat from 0 to 1
        
        //t = Mathf.PingPong(Time.time / 2, 1); // pingpong

        // t = (Mathf.Cos(Time.time) + 1) / 2; // using Cosine wave
        
        t = (Mathf.Sin(Time.time * 3) + 1) / 2;
        

        //t = _curve.Evaluate(Mathf.Repeat(Time.time / 2, 1));

    }

    private void OnDrawGizmos()
    {
        CubicBezier bez = new CubicBezier(A, B, C, D);

        Vector2 prev = bez.p0;
        for (int i = 0; i < 64; i++)
        {
            float v = i / (64f - 1f);
            Vector2 p =  bez.GetPoint(v);
            Gizmos.DrawLine(prev, p);
            prev = p;
        }
        Gizmos.DrawSphere(bez.GetPoint(t), 0.5f);
    }


    static void DoLerpThing(Vector2 p0, Vector2 p1, float t)
    {
        Gizmos.DrawLine(p0,p1);
        Vector2 pos = Vector2.Lerp(p0, p1, t);
        Gizmos.DrawSphere(pos,0.04f);
    }
    
    public struct CubicBezier
    {
        public Vector2 p0;
        public Vector2 p1;
        public Vector2 p2;
        public Vector2 p3;

        public CubicBezier(Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3)
        {
            this.p0 = p0;
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
        }

        public Vector2 GetPoint(float t)
        {
            Vector2 a = Vector2.LerpUnclamped(p0,p1, t);
            Vector2 b = Vector2.LerpUnclamped(p1,p2, t);
            Vector2 c = Vector2.LerpUnclamped(p2,p3, t);
            
            Vector2 d = Vector2.LerpUnclamped(a,b, t);
            Vector2 e = Vector2.LerpUnclamped(b,c, t);
            
            return Vector2.LerpUnclamped(d,e, t);
        }
    }

}
