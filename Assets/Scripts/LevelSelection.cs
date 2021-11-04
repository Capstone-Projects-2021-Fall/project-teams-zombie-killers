using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{

    public void Level2()
    {
        SceneManager.LoadScene("NewLevel2");
    }

    public void Francio()
    {
        SceneManager.LoadScene("Francio");
    }

    public void SettingsMenu()
    {
        SceneManager.LoadScene("SettingsMenu");
    }

    public void BackScreen()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void NameSelect()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void AchievementSelect()
    {
        SceneManager.LoadScene("Achievement");
    }
}
