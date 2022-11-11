using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmLandGenerator : MonoBehaviour{
    [SerializeField] GameObject _farmLandPrefab;
    [SerializeField] GameObject _farmLandsHolder;
    [SerializeField] float _hight;
    [SerializeField] float _thickness;
    Vector3[] _vertices;

    int[] _triangles;
    
    
    public void PopulateData(Vector2 halfSize){



        float widthSqr = _thickness * _thickness; // 4
        float distanceSqr = widthSqr / 2f; //2
        float _calculatedThickness = Mathf.Sqrt(distanceSqr); //1.14

        
        _vertices = new Vector3[]{

            new Vector3(-halfSize.x,      0, -halfSize.y     ), //0
            new Vector3(-halfSize.x,      0, halfSize.y    ), //1   
            new Vector3(halfSize.x,     0, halfSize.y    ), //2
            new Vector3(halfSize.x,     0, -halfSize.y      ), //3

            new Vector3(-halfSize.x + _calculatedThickness,  _hight, -halfSize.y + _calculatedThickness ), //4 (4)

            new Vector3(-halfSize.x + _calculatedThickness,   _hight, halfSize.y - _calculatedThickness ), //5 (5)
            new Vector3(-halfSize.x + _calculatedThickness,   _hight, halfSize.y - _calculatedThickness ), //6 (5)

            new Vector3(halfSize.x  - _calculatedThickness,  _hight,  halfSize.y - _calculatedThickness ), //7 (6)
            new Vector3(halfSize.x  - _calculatedThickness,  _hight,  halfSize.y - _calculatedThickness ), //8 (6)

            new Vector3(halfSize.x  - _calculatedThickness,  _hight, -halfSize.y + _calculatedThickness ), //9 (7)
            new Vector3(halfSize.x  - _calculatedThickness,  _hight, -halfSize.y + _calculatedThickness ), //10 (7)

            new Vector3(-halfSize.x + _calculatedThickness,  _hight, -halfSize.y + _calculatedThickness ), //11 (4)

            new Vector3(-halfSize.x + _calculatedThickness,  _hight, -halfSize.y + _calculatedThickness ), //12 (4)
            new Vector3(-halfSize.x + _calculatedThickness,  _hight,  halfSize.y - _calculatedThickness ), //13 (5)
            new Vector3( halfSize.x - _calculatedThickness,  _hight,  halfSize.y - _calculatedThickness ), //14 (6)
            new Vector3( halfSize.x - _calculatedThickness,  _hight, -halfSize.y + _calculatedThickness ), //15 (7)

            
            new Vector3(-halfSize.x,      0, -halfSize.y     ), //16 (0)
            new Vector3(-halfSize.x,      0, halfSize.y    ), //17 (1)   
            new Vector3(halfSize.x,     0, halfSize.y    ), //18 (2)
            new Vector3(halfSize.x,     0, -halfSize.y      ), //19 (3)
        };

        _triangles = new int[]{
            //left
            0,1,5,
            5,4,0,
            //top
            17,18,7,
            7,6,17,
            //rigt
            2,3,9,
            9,8,2,
            //bot
            19,16,11,
            11,10,19,
            //topCube
            12,13,15,
            15,13,14

        };
    }

    public void GenerateFarmLandAt(Vector3 position){

        GameObject fLand = Instantiate(_farmLandPrefab);
        fLand.transform.parent = _farmLandsHolder.transform;
        fLand.transform.localPosition = position;

        Mesh mesh = fLand.GetComponent<MeshFilter> ().mesh;
        MeshCollider col = fLand.GetComponent<MeshCollider> ();

        mesh.Clear();
        mesh.vertices = _vertices;
        mesh.triangles = _triangles;
        mesh.Optimize();
        mesh.RecalculateNormals();

        col.sharedMesh=null;
        col.sharedMesh=mesh;
    }
}
