using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Header("Level timer in seconds")]
    [SerializeField] float levelTime = 70;
    bool triggeredLevelFinished = false;
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggeredLevelFinished)
        {
            return;
        }

        slider.value = Time.timeSinceLevelLoad / levelTime;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if (timerFinished)
        {
            ProgressController.singleton.LevelFinished();
            triggeredLevelFinished = true;
        }
    }
}
