using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;
[RequireComponent(typeof(FarmLandGenerator))]
[RequireComponent(typeof(BorderGenerator))]

public class WorldMeshGenerator : MonoBehaviour
{
    [SerializeField] NavMeshSurface _navMeshSurface;
    [SerializeField] GameObject _pathway;
    [SerializeField] Vector2Int _gridSize = new Vector2Int(1,1);
    [SerializeField] float _roadThickness = 2;
    [SerializeField] float _width = 1;
    [SerializeField] float _length = 1;
     
    FarmLandGenerator _farmLandGen;
    BorderGenerator _borderGen;

    private List<Vector3> _FieldVertices = new List<Vector3>();
    private List<int> _FieldTriangles = new List<int>();

    private Mesh _mesh;
    private MeshCollider _col;

    Vector2 _pathOffset;

    float _cellWidth;
    float _cellLength;

    float _distance;

    void Start(){
        _mesh = _pathway.GetComponent<MeshFilter> ().mesh;
        _col = _pathway.GetComponent<MeshCollider> ();

        _farmLandGen = GetComponent<FarmLandGenerator>();
        _borderGen = GetComponent<BorderGenerator>();

        _pathOffset = new Vector2(_width/2,_length/2);
        _cellWidth = _width / (float)_gridSize.x;
        _cellLength = _length / (float)_gridSize.y;
        
        CalculateDistance();

        _farmLandGen.PopulateData(new Vector2(_cellWidth-(2*_distance), _cellLength - (2*_distance) ) / 2);
        _borderGen.PopulateData(_pathOffset);

        int count = 0;
        for (int y = 0; y < _gridSize.y; y++){
            for (int x = 0; x < _gridSize.x; x++){
                DrawPathway(x,y,count);
                _farmLandGen.GenerateFarmLandAt(new Vector3(-_pathOffset.x + _cellWidth * (x+0.5f), 0, -_pathOffset.y + _cellLength * (y+0.5f)));
                count++;
            }
        }


        PopulateMesh();

        _navMeshSurface.BuildNavMesh();
    }


    void DrawPathway(int x, int y, int index){
        float xPos = -_pathOffset.x + _cellWidth * x;
        float yPos = -_pathOffset.y + _cellLength * y;


        _FieldVertices.Add(new Vector3(xPos,                0,  yPos                ));
        _FieldVertices.Add(new Vector3(xPos,                0,  yPos + _cellLength  ));
        _FieldVertices.Add(new Vector3(xPos + _cellWidth,   0,  yPos + _cellLength  ));
        _FieldVertices.Add(new Vector3(xPos + _cellWidth,   0, yPos                 ));


        _FieldVertices.Add(new Vector3(xPos + _distance,                 0, yPos + _distance                  ));
        _FieldVertices.Add(new Vector3(xPos + _distance,                 0, yPos + (_cellLength - _distance)  ));
        _FieldVertices.Add(new Vector3(xPos + (_cellWidth - _distance),  0, yPos + (_cellLength - _distance)  ));
        _FieldVertices.Add(new Vector3(xPos + (_cellWidth - _distance),  0, yPos + _distance                  ));
        
        int offset = index * 8;
        
        //Left
        _FieldTriangles.Add(offset + 0);
        _FieldTriangles.Add(offset + 1);
        _FieldTriangles.Add(offset + 5);

        _FieldTriangles.Add(offset + 5);
        _FieldTriangles.Add(offset + 4);
        _FieldTriangles.Add(offset + 0);

        //Top
        _FieldTriangles.Add(offset + 1);
        _FieldTriangles.Add(offset + 2);
        _FieldTriangles.Add(offset + 6);

        _FieldTriangles.Add(offset + 6);
        _FieldTriangles.Add(offset + 5);
        _FieldTriangles.Add(offset + 1);

        //Right
        _FieldTriangles.Add(offset + 2);
        _FieldTriangles.Add(offset + 3);
        _FieldTriangles.Add(offset + 7);

        _FieldTriangles.Add(offset + 7);
        _FieldTriangles.Add(offset + 6);
        _FieldTriangles.Add(offset + 2);

        //bot
        _FieldTriangles.Add(offset + 3);
        _FieldTriangles.Add(offset + 0);
        _FieldTriangles.Add(offset + 4);

        _FieldTriangles.Add(offset + 4);
        _FieldTriangles.Add(offset + 7);
        _FieldTriangles.Add(offset + 3);

    }





    void PopulateMesh(){
        _mesh.Clear();
        _mesh.vertices = _FieldVertices.ToArray();
        _mesh.triangles = _FieldTriangles.ToArray();
        _mesh.Optimize();
        _mesh.RecalculateNormals();

        _col.sharedMesh = null;
        _col.sharedMesh = _mesh;
    }

    void CalculateDistance(){
        float widthSqr = _roadThickness * _roadThickness; // 4
        float distanceSqr = widthSqr / 2f; //2
        _distance = Mathf.Sqrt(distanceSqr); //1.14
    }
}
