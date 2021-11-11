using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DefenderCost : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = this.GetComponentInParent<DefenderButton>().defenderPrefab.GetComponent<Defender>().GetStarCost().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
