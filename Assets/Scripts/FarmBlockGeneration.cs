using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmBlockGeneration : MonoBehaviour{
    

    public void GenerateBlock(Vector3[] vertices){
        List<int> triangles = new List<int>();
        triangles.Add(0);
        triangles.Add(1);
        triangles.Add(3);

        triangles.Add(2);
        triangles.Add(3);
        triangles.Add(1);

        Mesh mesh = GetComponent<MeshFilter> ().mesh;


        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles.ToArray();
        mesh.Optimize();
        mesh.RecalculateNormals();

        Destroy(this);
    }
}
