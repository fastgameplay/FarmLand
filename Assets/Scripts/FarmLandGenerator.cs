using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmLandGenerator : MonoBehaviour{
    [SerializeField] GameObject _farmLandPrefab;
    [SerializeField] float _hight;
    [SerializeField] float _thickness;
    Vector3[] _vertices;

    int[] _triangles;
    
    
    public void PopulateData(float distance, float cellWidth, float cellLength){

        float widthSqr = _thickness * _thickness; // 4
        float distanceSqr = widthSqr / 2f; //2
        float _calculatedThickness = Mathf.Sqrt(distanceSqr); //1.14

        _vertices = new Vector3[]{
            new Vector3(distance,                 0, distance               ),
            new Vector3(distance,                 0, cellLength - distance  ),
            new Vector3(cellWidth - distance,     0, cellLength - distance  ),
            new Vector3(cellWidth - distance,     0, distance               ),
            new Vector3(distance + _calculatedThickness,                _hight, distance + _calculatedThickness                 ),
            new Vector3(distance + _calculatedThickness,                _hight, (cellLength - distance)  - _calculatedThickness ),
            new Vector3((cellWidth - distance) - _calculatedThickness,  _hight, (cellLength - distance) - _calculatedThickness  ),
            new Vector3((cellWidth - distance) - _calculatedThickness,  _hight, distance + _calculatedThickness                 )

        };

        _triangles = new int[]{
            0,1,5,
            5,4,0,
            1,2,6,
            6,5,1,
            2,3,7,
            7,6,2,
            3,0,4,
            4,7,3,
            4,5,7,
            7,5,6
        };
    }

    public void GenerateFarmLandAt(Vector3 position){

        GameObject fLand = Instantiate(_farmLandPrefab);
        fLand.transform.parent = transform;
        fLand.transform.localPosition = position;

        Mesh mesh = fLand.GetComponent<MeshFilter> ().mesh;


        mesh.Clear();
        mesh.vertices = _vertices;
        mesh.triangles = _triangles;
        mesh.RecalculateNormals();
        mesh.Optimize();

    }
}
