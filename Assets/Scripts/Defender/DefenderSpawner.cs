using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DefenderSpawner : MonoBehaviour, IPointerDownHandler
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

    public void OnPointerDown(PointerEventData eventData)
    {
        AttemptToPlaceDefender(GetSquareClicked());
        //defenderPrefab = null;
    }

    public void SetSelectedDefender(GameObject defenderToSelect)
    {
        defenderPrefab = defenderToSelect;
    }

    private void AttemptToPlaceDefender(Vector2 gridPos)
    {
        if (defenderPrefab == null)
        {
            Debug.LogError("No defender selected!");
        }
        else
        {
            if (defenderPrefab.CompareTag("Defender")) {
                var StarDisplay = FindObjectOfType<StarDisplay>();
                var defenderCost = defenderPrefab.GetComponent<Defender>().GetStarCost();
                if (StarDisplay.HaveEnoughStars(defenderCost) && !gridOccupied(gridPos))
                {
                    SpawnDefender(gridPos);
                    StarDisplay.SpendStars(defenderCost);
                }
            }
            else
            {
                Instantiate(defenderPrefab, gridPos, Quaternion.identity);
            }
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

    private bool gridOccupied(Vector2 check)
    {
        return occupiedSquares.Contains(check);
    }

    private void SpawnDefender(Vector2 gridPos)
    {

        Vector2 check = gridPos;
        if (!gridOccupied(check))
        {
            GameObject newDefender = Instantiate(defenderPrefab, gridPos, Quaternion.identity);
            occupiedSquares.Add(gridPos);

            AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_DEFENDER, 1);
            AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_MASTERDEFENDER, 1);
            AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_EXPERTDEFENDER, 1);

            if (defenderPrefab.name.Contains("Cactus"))
            {

                AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_CACTUS, 1);
                AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_MASTERCACTUS, 1);
                AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_EXPERTCACTUS, 1);

            }

            else if (defenderPrefab.name.Contains("Trophy"))
            {

                AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_TROPHY, 1);
                AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_MASTERTROPHY, 1);
                AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_EXPERTTROPHY, 1);

            }

            else if (defenderPrefab.name.Contains("Forehorseman"))
            {

                AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_FOREHORSEMAN, 1);
                AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_MASTERFOREHORSEMAN, 1);
                AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_EXPERTMASTERFOREHORSEMAN, 1);

            }

            else if (defenderPrefab.name.Contains("Liberty Bell"))
            {

                AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_LIBERTYBELL, 1);
                AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_MASTERLIBERTYBELL, 1);
                AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_EXPERTLIBERTYBELL, 1);

            }

            else if (defenderPrefab.name.Contains("Gnome"))
            {

                AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_GNOME, 1);
                AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_EXPERTGNOME, 1);
                AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_MASTERGNOME, 1);

            }

            else if (defenderPrefab.name.Contains("Ninja"))
            {

                AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_NINJA, 1);
                AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_EXPERTNINJA, 1);
                AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_MASTERNINJA, 1);

            }

            else if (defenderPrefab.name.Contains("Rocky"))
            {

                AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_ROCKY, 1);
                AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_EXPERTROCKY, 1);
                AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_MASTERROCKY, 1);

            }

            else if (defenderPrefab.name.Contains("Fireman"))
            {

                AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_FIREMAN, 1);
                AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_EXPERTFIREMAN, 1);
                AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_MASTERFIREMAN, 1);

            }

            else if (defenderPrefab.name.Contains("Adventure_girl"))
            {

                AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_ADVENTUREGIRL, 1);
                AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_EXPERTADVENTUREGIRL, 1);
                AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_MASTERADVENTUREGIRL, 1);

            }

            else if (defenderPrefab.name.Contains("Robot"))
            {

                AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_ROBOT, 1);
                AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_EXPERTROBOT, 1);
                AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_MASTERROBOT, 1);

            }

            else if (defenderPrefab.name.Contains("Freek"))
            {

                AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_FREEK, 1);
                AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_EXPERTFREEK, 1);
                AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_MASTERFREEK, 1);

            }

            else if (defenderPrefab.name.Contains("Bomber"))
            {

                AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_BOMBER, 1);
                AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_EXPERTBOMBER, 1);
                AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_MASTERBOMBER, 1);

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
