using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayerName : MonoBehaviour
{
    /// <summary>
    /// !!!DO NOT USE!!! - Access player name with PersistentData class instead
    /// </summary>
    /// <remarks>
    /// Player Name should be accessed by using PersistentData.SetPlayerName(string newName) and PersistentData.GetPlayerName()
    ///
    /// Examples:
    /// Replace:
    /// string x = GetPlayerName.playerName;
    /// With:
    /// string x = PersistentData.GetPlayerName();
    ///
    /// Replace:
    /// GetPlayerName.playerName = "New Player Name";
    /// With:
    /// PersistentData.SetPlayerName("New Player Name");
    ///
    /// If you have any questions reach out to Marcus
    /// </remarks>
    public static string playerName;
    

}
