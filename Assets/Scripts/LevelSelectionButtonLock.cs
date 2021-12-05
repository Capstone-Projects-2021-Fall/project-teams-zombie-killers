using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionButtonLock : MonoBehaviour
{
    private static bool TrackingCompletion = true;

    public enum difficultyTypes
    {
        NORMAL,
        HARD,
        EventSystem
    }

    public string PreviousSceneName;
    public difficultyTypes difficulty;

    // Start is called before the first frame update
    void Start()
    {
        if (!PersistentData.GetPlayerName().Equals("Demo"))
        {
            if (difficulty != difficultyTypes.EventSystem)
            {
                if (difficulty == difficultyTypes.NORMAL)
                {
                    //Previous level has not been completed on normal difficulty
                    if (TrackingCompletion && !LevelCompletion.getNormalLevelCompletionStatus(PreviousSceneName))
                    {
                        Button button = GetComponent<Button>();
                        button.interactable = false; //Player cannot press the button to advance to the next level
                        ColorBlock theColor = button.colors;
                        theColor.disabledColor = new Color(200.0f / 255.0f, 200.0f / 255.0f, 200.0f / 255.0f, 150.0f / 255.0f);
                        button.colors = theColor;
                    }
                }
                else if (difficulty == difficultyTypes.HARD)
                {
                    //Previous level has not been completed on hard difficulty
                    if (TrackingCompletion && !LevelCompletion.getHardLevelCompletionStatus(PreviousSceneName))
                    {
                        Button button = GetComponent<Button>();
                        button.interactable = false; //Player cannot press the button to advance to the next level
                        ColorBlock theColor = button.colors;
                        theColor.disabledColor = new Color(200.0f / 255.0f, 200.0f / 255.0f, 200.0f / 255.0f, 150.0f / 255.0f);
                        button.colors = theColor;
                    }
                }
            }
        }
    }

    private bool lastTrackingCompletion = true;
    // Update is called once per frame
    void Update()
    {
        if(lastTrackingCompletion != TrackingCompletion)
        {
            lastTrackingCompletion = TrackingCompletion;
            
            if (difficulty != difficultyTypes.EventSystem)
            {

                if (TrackingCompletion == false)
                {
                    Button button = GetComponent<Button>();
                    button.interactable = true; //Player can press the button to advance to the next level
                }
                else if (difficulty == difficultyTypes.NORMAL)
                {
                    //Previous level has not been completed on normal difficulty
                    if (TrackingCompletion && !LevelCompletion.getNormalLevelCompletionStatus(PreviousSceneName))
                    {
                        Button button = GetComponent<Button>();
                        button.interactable = false; //Player cannot press the button to advance to the next level
                    }
                }
                else if (difficulty == difficultyTypes.HARD)
                {
                    //Previous level has not been completed on hard difficulty
                    if (TrackingCompletion && !LevelCompletion.getHardLevelCompletionStatus(PreviousSceneName))
                    {
                        Button button = GetComponent<Button>();
                        button.interactable = false; //Player cannot press the button to advance to the next level
                    }
                }
            }
        }
    }


    //Only to be used in development.
    //Changes whether the game is allowing the player to enter a level based on their progress.
    public void switchProgressTracking()
    {
        TrackingCompletion = !TrackingCompletion;
    }
}
