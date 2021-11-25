using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletion
{

    //Marks the level as completed on Normal difficulty
    public static void NormalLevelCompleted(string SceneName)
    {
        PersistentData.SetInt(SceneName + " Normal Level Completion Tracker", 1);
    }

    //Marks the level as not completed on Normal difficulty
    //Not likely to be needed in final release of the game but could be useful in development.
    public static void NormalLevelResetCompletion(string SceneName)
    {
        PersistentData.SetInt(SceneName + " Normal Level Completion Tracker", 0);
    }

    //Returns true if the level has been completed on Normal difficulty
    public static bool getNormalLevelCompletionStatus(string SceneName)
    {
        return PersistentData.GetInt(SceneName + " Normal Level Completion Tracker", 0) == 1;
    }



    //Marks the level as completed on Hard difficulty
    public static void HardLevelCompleted(string SceneName)
    {
        PersistentData.SetInt(SceneName + " Hard Level Completion Tracker", 1);
    }

    //Marks the level as not completed on Hard difficulty
    //Not likely to be needed in final release of the game but could be useful in development.
    public static void HardLevelResetCompletion(string SceneName)
    {
        PersistentData.SetInt(SceneName + " Hard Level Completion Tracker", 0);
    }

    //Returns true if the level has been completed on Hard difficulty
    public static bool getHardLevelCompletionStatus(string SceneName)
    {
        return PersistentData.GetInt(SceneName + " Hard Level Completion Tracker", 0) == 1;
    }
}
