using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickBtn : MonoBehaviour
{
    public Text clickDisplay;
    public int clicks;
    public int defenders;
    public int forehorseman;
    public int cactus;


    public void Click()
    {
        clicks++;
        clickDisplay.text = clicks + " CLICKS";

        AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_TEST, 1);

    }

    public void Defenders()
    {

        defenders++;

        AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_DEFENDER, 1);
    }

    public void ForeHorseman()
    {


        forehorseman++;

        AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_FOREHORSEMAN, 1);
    }

    public void Cactus()
    {

        cactus++;

        AchievementManager.achievementManagerInstance.AddAchievementProgress(AchievementType.ZKS_CACTUS, 1);
    }
}
