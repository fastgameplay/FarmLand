using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshCollider))]
public class WorldMeshGenerator : MonoBehaviour
{
    [SerializeField] float _roadThickness = 2;
    [SerializeField] float _width = 1;
    [SerializeField] float _length = 1;
     
    private List<Vector3> _FieldVertices = new List<Vector3>();
    private List<int> _FieldTriangles = new List<int>();

    private Mesh _mesh;
    private MeshCollider _col;

    int _faceCount;
  
    void Start(){
        _mesh = GetComponent<MeshFilter> ().mesh;
        _col = GetComponent<MeshCollider> ();
        _width = transform.localScale.x;
        _length = transform.localScale.z;
        _faceCount = 0;


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

        float widthSqr = _roadThickness * _roadThickness; // 4
        float distanceSqr = widthSqr / 2f; //2
        float distance = Mathf.Sqrt(distanceSqr); //1.14

        _FieldVertices.Add(new Vector3(distance,            0, distance ));
        _FieldVertices.Add(new Vector3(distance,            0, _length - distance ));
        _FieldVertices.Add(new Vector3(_width - distance,   0, _length - distance ));
        _FieldVertices.Add(new Vector3(_width - distance, 0, distance));
        //Left
        _FieldTriangles.Add(0);
        _FieldTriangles.Add(1);
        _FieldTriangles.Add(5);

        _FieldTriangles.Add(5);
        _FieldTriangles.Add(4);
        _FieldTriangles.Add(0);

        //Top
        _FieldTriangles.Add(1);
        _FieldTriangles.Add(2);
        _FieldTriangles.Add(6);

        _FieldTriangles.Add(6);
        _FieldTriangles.Add(5);
        _FieldTriangles.Add(1);

        //Right
        _FieldTriangles.Add(2);
        _FieldTriangles.Add(3);
        _FieldTriangles.Add(7);

        _FieldTriangles.Add(7);
        _FieldTriangles.Add(6);
        _FieldTriangles.Add(2);

        //bot
        _FieldTriangles.Add(3);
        _FieldTriangles.Add(0);
        _FieldTriangles.Add(4);

        _FieldTriangles.Add(4);
        _FieldTriangles.Add(7);
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
