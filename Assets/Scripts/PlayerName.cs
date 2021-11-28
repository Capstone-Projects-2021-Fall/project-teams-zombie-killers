using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerName : MonoBehaviour
{
    //[SerializeField] public static string nameOfPlayer;
    //[SerializeField] public string saveName;

    public Text inputText;
    public Text loadedName;



    // Start is called before the first frame update
    void Start()
    {
        string nameOfPlayer = PersistentData.GetPlayerName();
        if (nameOfPlayer.Equals(""))
        {
            loadedName.gameObject.SetActive(false);
        }
        else
        {
            loadedName.text = "Hello, " + nameOfPlayer + "!";
        }
    }


    /// <summary>
    /// This function is being called by the save button in the PlayerName scene.
    /// If the player has inputted a valid name then all attributes pertaining to that name are updated.
    /// </summary>
    public void SetName()
    {
        string newNameOfPlayer = inputText.text;
        if (!newNameOfPlayer.Equals(""))
        {
            PersistentData.SetPlayerName(newNameOfPlayer);
            loadedName.gameObject.SetActive(true);
            loadedName.text = "Hello, " + newNameOfPlayer + "!";

            //The following line is old code. Player name should be retreaved by other game components using PersistentData.GetPlayerName().
            //While this should be redundant I am keeping it for the time being since I am unsure of all of the gameObjects that use it.
            //TODO : Remove all refrences to the GetPlayerName C# script and remove this line.
            GetPlayerName.playerName = newNameOfPlayer;
        }
    }


    /// <summary>
    /// This function is being called by the confirm button in the PlayerName scene.
    /// If the player has inputted a valid name then they are taken to the main screen.
    /// </summary>
    public void ConfirmName()
    {
        if (!PersistentData.GetPlayerName().Equals(""))
        {
            SceneManager.LoadScene("StartScreen");
        }
    }
}
