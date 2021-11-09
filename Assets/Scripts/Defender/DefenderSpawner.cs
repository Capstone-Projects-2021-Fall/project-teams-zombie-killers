using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    public GameObject defenderPrefab;

    [SerializeField] private float gridSize;
    [SerializeField] private float halfGridSize;

    private List<Vector2> occupiedSquares;

    public static DefenderSpawner singleton;

    private void Start()
    {
        occupiedSquares = new List<Vector2>();
        if (singleton == null)
        {
            singleton = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        AttemptToPlaceDefender(GetSquareClicked());


    }

    public void SetSelectedDefender(GameObject defenderToSelect)
    {
        defenderPrefab = defenderToSelect;
    }

     private void AttemptToPlaceDefender(Vector2 gridPos)
    {
        var StarDisplay = FindObjectOfType<StarDisplay>();
        var defenderCost = defenderPrefab.GetComponent<Defender>().GetStarCost();
        if (StarDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefender(gridPos);
            StarDisplay.SpendStars(defenderCost);
        }
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

        Vector2 check = gridPos;
        if (!occupiedSquares.Contains(check))
        {
            GameObject newDefender = Instantiate(defenderPrefab, gridPos, Quaternion.identity);
            occupiedSquares.Add(gridPos);

            AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_DEFENDER, 1);

            if (defenderPrefab.name.Contains("Cactus"))
            {

                AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_CACTUS, 1);

            }

            else if (defenderPrefab.name.Contains("Trophy"))
            {

                AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_TROPHY, 1);

            }

            else if (defenderPrefab.name.Contains("Forehorseman"))
            {

                AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_FOREHORSEMAN, 1);

            }

        }
        else
        {
            Debug.LogError("Space is already occupied!");
        }
    }

    public void Unoccupy(Vector2 destroyedPos)
    {
        if (occupiedSquares.Contains(destroyedPos))
        {
            occupiedSquares.Remove(destroyedPos);
        }
    }
}
