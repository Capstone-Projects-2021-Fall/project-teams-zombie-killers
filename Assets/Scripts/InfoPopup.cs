using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoPopup : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.active == true)
            Time.timeScale = 0;
    }

    public void ResumeTime()
    {
        Time.timeScale = 1;
        transform.parent.parent.gameObject.SetActive(false);
    }
}
