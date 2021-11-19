using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DefenderCost : MonoBehaviour
{
    public GameObject defenderPfab;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = defenderPfab.GetComponent<Defender>().GetStarCost().ToString();
    }
}
