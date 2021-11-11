using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{

<<<<<<< Updated upstream
    [SerializeField] int stars = 100;
    Text starText;
=======
    [SerializeField] int stars = 30;
    TextMeshProUGUI starText;
>>>>>>> Stashed changes

    void Start()
    {
        starText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
<<<<<<< Updated upstream
        starText.text = stars.ToString();
=======
        starText.text = "Star Coins: " + stars.ToString();
>>>>>>> Stashed changes
    }

    public bool HaveEnoughStars(int amount)
    {
        return stars >= amount;
    }

    public void AddStars(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }

    public void SpendStars(int amount)
    {
        if (stars >= amount)
        {
            stars -= amount;
            UpdateDisplay();
        }
    }
}