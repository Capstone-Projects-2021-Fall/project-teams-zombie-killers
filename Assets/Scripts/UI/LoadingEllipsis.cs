using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadingEllipsis : MonoBehaviour
{
    void Awake()
    {
        GetComponent<TextMeshProUGUI>().text = "Loading";
        StartCoroutine(EllipsisMove());
    }

    IEnumerator EllipsisMove()
    {
        int periodCounter = 0;
        while (true)
        {
            yield return new WaitForSeconds(0.75f);
            if (periodCounter < 3)
            {
                GetComponent<TMPro.TextMeshProUGUI>().text += ".";
                periodCounter++;
            }
            else
            {
                GetComponent<TMPro.TextMeshProUGUI>().text = "Loading";
                periodCounter = 0;
            }
        }

    }
}
