using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawners : MonoBehaviour
{
    [SerializeField] GameObject defender;

    private void OnMouseDown()
    {
        SpawnDefender(GetSquareClicked());  
    }
    private Vector2 GetSquareClicked()
    {

        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = snapTpGrid(worldPos);
        return gridPos;
    }

    private Vector2 snapTpGrid(Vector2 rawWordlPos)
    {
        float nexX = Mathf.RoundToInt(rawWordlPos.x);
        float nexY = Mathf.RoundToInt(rawWordlPos.y);
        return new Vector2(nexX, nexY);
    }


    private void SpawnDefender(Vector2 roundedPos)
    {
        GameObject newDefender = Instantiate(defender, roundedPos, Quaternion.identity) as GameObject;
        Debug.Log(roundedPos);
    }
}
