using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Default Resource", menuName = "Resource", order = 1)]

[System.Serializable]
public class Resource : ScriptableObject
{ 
    [SerializeField] private float count; //The current balance of this resource
    [SerializeField] private float generatedPerInterval; //The amount awarded every interval (amount/second for example)
    [SerializeField] private float multiplier = 1; //The value to multiply into the interval amount

    public Resource(string newName, float newCount = 0, float newPerInterval = 0, float newMultiplier = 1.0f)
    {
        name = newName;
        count = newCount;
        generatedPerInterval = newPerInterval;
        multiplier = newMultiplier;

    }

    #region Getters
    public float GetCount() { return count; }
    public float GetGeneratedPerInterval() { return generatedPerInterval; }
    public float GetMultiplier() { return multiplier; }

    #endregion

    #region Setters
    public void SetCount(float number)
    {
        count = number;
    }

    public void SetGeneratedPerInterval(float number)
    {
        generatedPerInterval = number;
    }

    public void SetMultiplier(float number)
    {
        multiplier = number;
    }
    #endregion

    #region Alters
    /// <summary>
    /// Adds the value to the amount of the resource. Use negetive to subtract
    /// </summary>
    /// <param name="number">The amount to be added</param>
    public void AlterCount(float number)
    {
        count += number;
    }

    /// <summary>
    /// Adds the value passed to the amountGeneratedPerInterval. Use negetive to subtract
    /// </summary>
    /// <param name="number"></param>
    public void AlterGeneratedPerInterval(float number)
    {
        generatedPerInterval += number;
    }

    /// <summary>
    /// Adds the value passed to the multiplier. Use negetive to subtract
    /// </summary>
    /// <param name="number"></param>
    public void AlterMultiplier(float number)
    {
        multiplier += number;
    }

    public void IncrementResource()
    {
        AlterCount(generatedPerInterval * multiplier);
    }
    #endregion

}
