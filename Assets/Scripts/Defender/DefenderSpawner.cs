using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    public GameObject defenderPrefab;

    [SerializeField] private float gridSize;
    [SerializeField] private float halfGridSize;

    private Dictionary<string, Vector2> occupiedSquares;

    private void OnMouseDown()
    {
        SpawnDefender(GetSquareClicked());
    }

    public void SetSelectedDefender(GameObject defenderToSelect)
    {
        defenderPrefab = defenderToSelect;
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 worldPos)
    {
        float newX = Mathf.Round(worldPos.x / gridSize + 0.5f) * gridSize - halfGridSize;
        float newY = Mathf.Round(worldPos.y / gridSize + 0.5f) * gridSize - halfGridSize;
        return new Vector2(newX, newY);

    }

    private void SpawnDefender(Vector2 gridPos)
    {
        GameObject newDefender = Instantiate(defenderPrefab, gridPos, Quaternion.identity);
    }

}
