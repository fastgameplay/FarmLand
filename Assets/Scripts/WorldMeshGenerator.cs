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

    private int _faceCount;

    float width;
    float length;

    void Start(){
        _mesh = GetComponent<MeshFilter> ().mesh;
        _col = GetComponent<MeshCollider> ();

        width = transform.
    }

    void Update()
    {
        
    }
}
