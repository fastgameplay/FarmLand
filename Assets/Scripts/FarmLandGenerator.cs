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
            new Vector3(distance,      0, distance      ), //0
            new Vector3(distance,      0, cellLength    ), //1   
            new Vector3(cellWidth,     0, cellLength    ), //2
            new Vector3(cellWidth,     0, distance      ), //3

            new Vector3(distance + _calculatedThickness,           _hight, distance + _calculatedThickness            ), //4

            new Vector3(distance + _calculatedThickness,           _hight, cellLength  - _calculatedThickness  ), //5
            new Vector3(distance + _calculatedThickness,           _hight, cellLength  - _calculatedThickness  ), //6

            new Vector3(cellWidth - _calculatedThickness,  _hight, cellLength - _calculatedThickness    ), //7
            new Vector3(cellWidth - _calculatedThickness,  _hight, cellLength - _calculatedThickness    ), //8

            new Vector3(cellWidth - _calculatedThickness,  _hight, distance + _calculatedThickness             ), //9
            new Vector3(cellWidth - _calculatedThickness,  _hight, distance + _calculatedThickness             ), //10

            new Vector3(distance + _calculatedThickness,           _hight, distance + _calculatedThickness            ), //11

            new Vector3(distance + _calculatedThickness,           _hight, distance + _calculatedThickness            ), //12
            new Vector3(distance + _calculatedThickness,           _hight, cellLength  - _calculatedThickness  ), //13
            new Vector3(cellWidth - _calculatedThickness,  _hight, cellLength - _calculatedThickness    ), //14
            new Vector3(cellWidth - _calculatedThickness,  _hight, distance + _calculatedThickness             ), //15


        };

        _triangles = new int[]{
            0,1,5,
            5,4,0,
            1,2,7,
            7,6,1,
            2,3,9,
            9,8,2,
            3,0,11,
            11,10,3,
            12,13,15,
            15,13,14

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
        mesh.Optimize();
        mesh.RecalculateNormals();

    }
}
