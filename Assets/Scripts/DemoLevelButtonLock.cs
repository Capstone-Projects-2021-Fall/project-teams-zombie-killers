using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemoLevelButtonLock : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        
        if (!PersistentData.GetPlayerName().Equals("Demo"))
        {
            //GetComponent<CanvasRenderer>().SetAlpha(0);
            gameObject.SetActive(false);
            GetComponent<Button>().enabled = false;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
