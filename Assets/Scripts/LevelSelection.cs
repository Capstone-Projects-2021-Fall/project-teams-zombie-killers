using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public void Level1()
    {
        SceneManager.LoadScene("Level 1-HighRes");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void Level3()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void Level4()
    {
        SceneManager.LoadScene("Level 4");
    }

    public void Level5()
    {
        SceneManager.LoadScene("Level 5");
    }

    public void Level6()
    {
        SceneManager.LoadScene("Level 6");
    }

    public void Level7()
    {
        SceneManager.LoadScene("Level 7");
    }

    public void Level8()
    {
        SceneManager.LoadScene("Level 8");
    }

    public void Level9()
    {
        SceneManager.LoadScene("Level 9");
    }

    public void Level10()
    {
        SceneManager.LoadScene("Level 10");
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

    public void StartScreen()
    {
        SceneManager.LoadScene("StartScreen");
    }


    public void StartScreenDeletePlayerPrefs()
    {
        
        SceneManager.LoadScene("StartScreen");
    }
    

    public void AchievementSelect()
    {
        SceneManager.LoadScene("Achievement");
    }

    public void LevelSelectionScreen()
    {
        SceneManager.LoadScene("LevelSelection");
    }
}
