using System.Collections.Generic;
using UnityEngine;

public class HexMesh : MonoBehaviour
{
    Mesh hexMesh;
    List<Vector3> vertices;
    List<int> triangles;

    public void trigulateCells(HexCell[] activeCells){
        hexMesh.Clear();
        vertices.Clear();
        triangles.Clear();

        for (int index = 0; index < activeCells.Length; index++){
            triangulateCell();
        }

    }

    void Awake(){

        hexMesh = new Mesh();
        GetComponent<MeshFilter>().mesh = hexMesh;
        hexMesh.name = "Hex Mesh";
        
        vertices = new List<Vector3>();
        triangles = new List<int>();
    }

    private void triangulateCell(HexCell targetCell){
        
    }


}
