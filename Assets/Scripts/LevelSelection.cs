using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{

	public void Level2() {  
        SceneManager.LoadScene("Level2");  
    }

    public void SettingsMenu()
    {
        SceneManager.LoadScene("SettingsMenu");
    }
}
