using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///   <para>`PersistentData` is a class that extends the functionality of PlayerPrefs and stores Player preferences between game sessions. It can store string, float and integer values into the user’s platform registry. These values are stored dependant on what the player's name is set to.</para>
/// </summary>
public class PersistentData : PlayerPrefs
{

    #region name
    private static string name = PlayerPrefs.GetString("name", "none");
    private static string storedKeys = PersistentData.GetString("All_Stored_Keys_For_This_Name");

    /// <summary>
    ///   <para>Sets the name of the Player name to uniquely generate and retrive keys for each player name.</para>
    /// </summary>
    /// <param name="newName"></param>
    public static void SetPlayerName(string newName)
    {
        PlayerPrefs.SetString("name", newName);
        name = newName;
        storedKeys = PlayerPrefs.GetString(name + "_All_Stored_Preferences_For_This_Name");
    }


    /// <summary>
	///   <para>Returns the Player name that is being used to uniquely generate and retrive keys.</para>
	/// </summary>
    public static string GetPlayerName()
    {
        return name;
    }
    #endregion



    #region Store Keys
    private static void StoreKey(string key)
    {
        if (!HasKey(key))
        {
            storedKeys += ";" + key;
            SetString("All_Stored_Keys_For_This_Name", storedKeys);
        }
    }

    public static string[] getKeys()
    {
        return storedKeys.Split(';');
    }

    public static void DeleteAllForPlayer()
    {
        string[] keys = getKeys();
        foreach (string key in keys)
        {
            DeleteKey(key);
        }
        storedKeys = "";
        SetString("All_Stored_Keys_For_This_Name", storedKeys);
    }
    #endregion



    #region String Functions
    /// <summary>
    ///   <para>Sets a single string value for the preference identified by the given key. You can use PersistentData.GetString to retrieve this value.</para>
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    new public static void SetString(string key, string value)
    {
        if (key.Equals("name"))
        {
            SetPlayerName(value);
        }
        else
        {
            StoreKey(key);
            PlayerPrefs.SetString(name + "_" + key, value);
        }
    }

    /// <summary>
	///   <para>Returns the value corresponding to key in the preference file if it exists.</para>
	/// </summary>
	/// <param name="key"></param>
	/// <param name="defaultValue"></param>
    new public static string GetString(string key)
    {
        if (key.Equals("name"))
            return name;
        else
            return PlayerPrefs.GetString(name + "_" + key);
    }

    /// <summary>
	///   <para>Returns the value corresponding to key in the preference file if it exists.</para>
	/// </summary>
	/// <param name="key"></param>
	/// <param name="defaultValue"></param>
    new public static string GetString(string key, string defaultValue)
    {
        if (key.Equals("name"))
            return name;
        else
            return PlayerPrefs.GetString(name + "_" + key, defaultValue);
    }
    #endregion



    #region Int Functions
    /// <summary>
    ///   <para>Sets a single integer value for the preference identified by the given key. You can use PersistentData.GetInt to retrieve this value.</para>
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    new public static void SetInt(string key, int value)
    {
        StoreKey(key);
        PlayerPrefs.SetInt(name + "_" + key, value);
    }

    /// <summary>
	///   <para>Returns the value corresponding to key in the preference file if it exists.</para>
	/// </summary>
	/// <param name="key"></param>
	/// <param name="defaultValue"></param>
    new public static int GetInt(string key)
    {
        return PlayerPrefs.GetInt(name + "_" + key);
    }

    /// <summary>
	///   <para>Returns the value corresponding to key in the preference file if it exists.</para>
	/// </summary>
	/// <param name="key"></param>
	/// <param name="defaultValue"></param>
    new public static int GetInt(string key, int defaultValue)
    {
        return PlayerPrefs.GetInt(name + "_" + key, defaultValue);
    }
    #endregion



    #region Float Functions
    /// <summary>
    ///   <para>Sets the float value of the preference identified by the given key. You can use PersistentData.GetFloat to retrieve this value.</para>
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    new public static void SetFloat(string key, float value)
    {
        StoreKey(key);
        PlayerPrefs.SetFloat(name + "_" + key, value);
    }

    /// <summary>
	///   <para>Returns the value corresponding to key in the preference file if it exists.</para>
	/// </summary>
	/// <param name="key"></param>
	/// <param name="defaultValue"></param>
    new public static float GetFloat(string key)
    {
        return PlayerPrefs.GetFloat(name + "_" + key);
    }

    /// <summary>
	///   <para>Returns the value corresponding to key in the preference file if it exists.</para>
	/// </summary>
	/// <param name="key"></param>
	/// <param name="defaultValue"></param>
    new public static float GetFloat(string key, float defaultValue)
    {
        return PlayerPrefs.GetFloat(name + "_" + key, defaultValue);
    }
    #endregion



    #region Other Function Overrides
    /// <summary>
    ///   <para>Returns true if the given key exists in PersistentData, otherwise returns false.</para>
    /// </summary>
    /// <param name="key"></param>
    new public static bool HasKey(string key)
    {
        return PlayerPrefs.HasKey(name + "_" + key);
    }

    /// <summary>
    ///   <para>Removes the given key from the PersistentData. If the key does not exist, DeleteKey has no impact.</para>
    /// </summary>
    /// <param name="key"></param>
    new public static void DeleteKey(string key)
    {
        PlayerPrefs.DeleteKey(name + "_" + key);

        //If the key was storing a value for a player then this will find the index of where it was stored
        string[] keys = getKeys();
        int indexToRemove = -1;
        for (int i = 0; i < keys.Length; i++)
        {
            if (keys[i].Equals(key))
            {
                indexToRemove = i;
                break;
            }
        }

        //True if the key was previously used
        if (indexToRemove != -1)
        {
            string newStoredKeys = "";
            for (int i = 0; i < keys.Length; i++)
            {
                if (i != indexToRemove)
                {
                    newStoredKeys += keys[i];
                    if (i != keys.Length - 1)
                        newStoredKeys += ";";
                }
            }
            storedKeys = newStoredKeys;
            PersistentData.SetString("All_Stored_Keys_For_This_Name", storedKeys);
        }
    }
    #endregion



}
