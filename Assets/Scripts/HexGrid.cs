using UnityEngine.UI;
using UnityEngine;

public class HexGrid : MonoBehaviour
{
    public HexCell hexCellPrefab;
    public int gridHeight = 6;
    public int gridWidth = 6;
    public Text cellLabel;
    Canvas gridCanvas;

    HexCell[] activeHexCells;

    void Awake()
    {
        gridCanvas = GetComponentInChildren<Canvas>();

        activeHexCells = new HexCell[gridHeight * gridWidth];

        createCells();
    }

    private void createCells(){
        int cellID = 0;
        
        for (int zPosition = 0; zPosition < gridHeight; zPosition++){
            for (int xPosition = 0; xPosition < gridWidth; xPosition++){
                createCell(xPosition, zPosition, cellID++);
            }
        }
    
    }

    private void createCell(int xPosition, int zPosition, int cellID){
        Vector3 cellPosition;
        
        cellPosition.x = xPosition * 10f;
        cellPosition.y = 0f;
        cellPosition.z = zPosition * 10f;

        HexCell targetCell = activeHexCells[cellID] = Instantiate<HexCell>(hexCellPrefab);
        targetCell.transform.SetParent(transform, false);
        targetCell.transform.localPosition = cellPosition;

        Text label = Instantiate<Text>(cellLabel);
        label.rectTransform.SetParent(gridCanvas.transform, false);
        label.rectTransform.anchoredPosition = new Vector2(cellPosition.x, cellPosition.z);
        label.text = xPosition.ToString() + "\n" + zPosition.ToString();
        

    }

}
