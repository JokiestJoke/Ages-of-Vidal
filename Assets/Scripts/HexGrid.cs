using UnityEngine.UI;
using UnityEngine;

public class HexGrid : MonoBehaviour
{
    public HexCell hexCellPrefab;
    public int gridHeight = 6;
    public int gridWidth = 6;
    public Text cellLabel;
    Canvas gridCanvas;
    private const float DEFAULT_CELL_X_POSITION_DISTANCE = TunableHexagonParameters.INNER_RADIUS * 2f;
    private const float DEFAULT_CELL_Z_POSITION_DISTANCE = TunableHexagonParameters.OUTER_RADIUS * 1.5f;
    private const float DEFAULT_SPACING_MODIFIER = 0.5f;
    
    HexCell[] activeHexCells;

    void Awake()
    {
        gridCanvas = GetComponentInChildren<Canvas>();

        activeHexCells = new HexCell[gridHeight * gridWidth];

        createCellsForGrid();
    }

    private void createCellsForGrid(){
        int cellID = 0;
        
        for (int zPosition = 0; zPosition < gridHeight; zPosition++){
            for (int xPosition = 0; xPosition < gridWidth; xPosition++){
                createCell(xPosition, zPosition, cellID++);
            }
        }
    }

    private void createCell(int xPosition, int zPosition, int currentCellID){
        Vector3 currentCellPosition = assignCellPosition(xPosition, zPosition);

        HexCell targetCell = assignHexCell(currentCellID, currentCellPosition);
        
        Text label = assignHexLabel(currentCellPosition, xPosition, zPosition);  
    }

    private Vector3 assignCellPosition(int xPosition, int zPosition){
        Vector3 cellPosition;
        
        cellPosition.x = (xPosition + zPosition * DEFAULT_SPACING_MODIFIER - zPosition / 2) * DEFAULT_CELL_X_POSITION_DISTANCE;
        cellPosition.y = 0f;
        cellPosition.z = zPosition * DEFAULT_CELL_Z_POSITION_DISTANCE;
        
        return cellPosition;
    }

    private HexCell assignHexCell(int cellID, Vector3 targetCellPosition){
        HexCell targetCell = activeHexCells[cellID] = Instantiate<HexCell>(hexCellPrefab);
        targetCell.transform.SetParent(transform, false);
        targetCell.transform.localPosition = targetCellPosition;
        
        return targetCell;
    }

    private Text assignHexLabel(Vector3 targetCellPosition, int xPosition, int zPosition){
        Text currentLabel = Instantiate<Text>(cellLabel);
        currentLabel.rectTransform.SetParent(gridCanvas.transform, false);

        currentLabel.rectTransform.anchoredPosition = new Vector2(targetCellPosition.x, targetCellPosition.z);
        currentLabel.text = xPosition.ToString() + "\n" + zPosition.ToString();
        
        return currentLabel;
    }

}
