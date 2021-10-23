using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceManager : MonoBehaviour
{
    public Resource resource;
    public TextMeshProUGUI resourceDisplay;
    private float displayCount;

    public static ResourceManager singleton;
    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        displayCount = resource.GetCount();
        StartCoroutine(RefreshDisplay());
    }

    private IEnumerator RefreshDisplay()
    {
        while (true)
        {
            if (displayCount != resource.GetCount())
            {
                displayCount = resource.GetCount();
                resourceDisplay.text = "Resources: " + displayCount;
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
}
