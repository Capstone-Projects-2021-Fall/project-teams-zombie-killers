using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickBtn : MonoBehaviour
{
    public Text clickDisplay;
    public int clicks;

    public void Click()
    {
        clicks++;
        clickDisplay.text = clicks + " CLICKS";

        AchievementManager.achievementManagerInstance.AddAchievementProgress("ZKS_TEST", 1);

    }

    public void Defender()
    {
        AchievementManager.achievementManagerInstance.AddAchievementProgress("ZKS_DEFENDER", 1);
    }

    public void ForeHorseman()
    {
        AchievementManager.achievementManagerInstance.AddAchievementProgress("ZKS_FOREHORSEMAN", 1);
    }

    public void Cactus()
    {
        AchievementManager.achievementManagerInstance.AddAchievementProgress("ZKS_CACTUS", 1);
    }
}
