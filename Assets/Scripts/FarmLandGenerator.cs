using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmLandGenerator : MonoBehaviour{
    [SerializeField] GameObject _farmLandPrefab;
    Vector3[] _vertices;

    int[] _triangles = new int[]{
        0,1,3,2,3,1
    };
        
    public void PopulateVertices(Vector3[] vertices){
        _vertices = vertices;
    }

    public void GenerateFarmLandAt(Vector3 position){

        GameObject fLand = Instantiate(_farmLandPrefab);
        fLand.transform.parent = transform;
        fLand.transform.localPosition = position;

        Mesh mesh = fLand.GetComponent<MeshFilter> ().mesh;


        mesh.Clear();
        mesh.vertices = _vertices;
        mesh.triangles = _triangles;
        mesh.Optimize();
        mesh.RecalculateNormals();

    }
}
