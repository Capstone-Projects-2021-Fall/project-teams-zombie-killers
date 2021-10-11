using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenLoad : MonoBehaviour
{

    [SerializeField] int wait = 3;
    int currentSceneIndex;

    // Use this for initialization
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitingTime());
        }
    }

    IEnumerator WaitingTime()
    {
        yield return new WaitForSeconds(wait);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    // Update is called once per frame
    void Update()
    {

    }
}