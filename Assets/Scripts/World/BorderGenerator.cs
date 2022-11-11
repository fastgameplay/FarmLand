using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderGenerator : MonoBehaviour{
    [SerializeField] GameObject _borderObject;

    [SerializeField] float _BorderSize = 10;
    Vector3[] _vertices;
    int[] _triangles;

    Mesh _mesh;
    MeshCollider _col;
    public void PopulateData(Vector2 halfSIze){
        
        _vertices = new Vector3[]{
            new Vector3(-halfSIze.x,0, -halfSIze.y),
            new Vector3(-halfSIze.x,0,  halfSIze.y),
            new Vector3(halfSIze.x ,0,  halfSIze.y),
            new Vector3(halfSIze.x ,0, -halfSIze.y),

            new Vector3(-halfSIze.x - _BorderSize, 0, -halfSIze.y - _BorderSize),
            new Vector3(-halfSIze.x - _BorderSize, 0,  halfSIze.y + _BorderSize),
            new Vector3( halfSIze.x + _BorderSize, 0,  halfSIze.y + _BorderSize),
            new Vector3( halfSIze.x + _BorderSize, 0, -halfSIze.y - _BorderSize),
        };
        _triangles = new int[]{
            //left
            0,4,5,
            5,1,0,
            //top
            1,5,6,
            6,2,1,
            //right
            2,6,7,
            7,3,2,
            //bot
            3,7,4,
            4,0,3
        };

        _mesh = _borderObject.GetComponent<MeshFilter> ().mesh;
        _col = _borderObject.GetComponent<MeshCollider>();

        _mesh.Clear();
        _mesh.vertices = _vertices;
        _mesh.triangles = _triangles;
        _mesh.Optimize();
        _mesh.RecalculateNormals();

        _col.sharedMesh = null;
        _col.sharedMesh = _mesh;
    }
}
