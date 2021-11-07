using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Lives : MonoBehaviour
{

    [SerializeField] int lives = 3;
    [SerializeField] int damage = 1;
    private TextMeshProUGUI livesText;

    void Start()
    {
        livesText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        livesText.text = "Lives: " + lives.ToString();
    }

    public void TakeLife()
    {
        lives -= damage;
        UpdateDisplay();

        if (lives <= 0)
        {
            FindObjectOfType<ProgressController>().HandleLoseCondition();
        }
    }
}
