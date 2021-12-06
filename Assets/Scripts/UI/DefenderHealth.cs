using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DefenderHealth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = GetComponentInParent<Defender>().GetHealth().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
