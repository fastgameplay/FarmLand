using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshCollider))]
public class WorldMeshGenerator : MonoBehaviour
{
    
     
    private List<Vector3> _FieldVertices = new List<Vector3>();
    private List<int> _FieldTriangles = new List<int>();

    private Mesh _mesh;
    private MeshCollider _col;


    float _width;
    float _length;

    void Start(){
        _mesh = GetComponent<MeshFilter> ().mesh;
        _col = GetComponent<MeshCollider> ();

        _width = transform.localScale.x;
        _length = transform.localScale.z;


        _FieldVertices.Add(new Vector3(0,0,0));
        _FieldVertices.Add(new Vector3(0,0,_length));
        _FieldVertices.Add(new Vector3(_width,0,_length));
        _FieldVertices.Add(new Vector3(_width,0,0));


        _FieldTriangles.Add(0);
        _FieldTriangles.Add(1);
        _FieldTriangles.Add(2);
        _FieldTriangles.Add(0);
        _FieldTriangles.Add(2);
        _FieldTriangles.Add(3);

        UpdateMesh();
    }

    void UpdateMesh(){
        _mesh.Clear();
        _mesh.vertices = _FieldVertices.ToArray();
        _mesh.triangles = _FieldTriangles.ToArray();
        _mesh.Optimize();
        _mesh.RecalculateNormals();
    }
}
