using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshAreaCalculator : MonoBehaviour
{
    public Mesh mesh;

    // called every time some inspector thing changes or reloads
    private void OnValidate()
    {
        if (mesh == null)
        {
            return;
        }

        Vector3[] vPositions = mesh.vertices;
        int[] triIndicies = mesh.triangles;


        float totalArea = 0;
        for (int i = 0; i < triIndicies.Length; i+=3)
        {
            int i0 = triIndicies[i];
            int i1 = triIndicies[i+1];
            int i2 = triIndicies[i+2];
            
            Vector3 v0 = vPositions[i0];
            Vector3 v1 = vPositions[i1];
            Vector3 v2 = vPositions[i2];

            totalArea += TriangleArea(v0, v1, v2);
            

        }
        
        Debug.Log($"{mesh.name} area = {totalArea:0.00}");
        Debug.Log(mesh.name + " area = " + totalArea);
    }
    float TriangleArea(Vector3 v0, Vector3 v1, Vector3 v2)
    {
        Vector3 a = v1 - v0;
        Vector3 b = v2 - v0;
        return Vector3.Cross(a, b).magnitude / 2;
    }
}
