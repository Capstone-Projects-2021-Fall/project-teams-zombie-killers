using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialText;
    public GameObject tutorialPanel;

    public GameObject defenderSelectionPanelHighlight;
    public GameObject coinsPanelHighlight;
    public GameObject livesPanelHighlight;
    public GameObject progressBarHighlight;
    public GameObject screenLeftHighlight;
    public GameObject screenRightHighlight;

    private bool clickedToAdvance;

    private void Start()
    {
        clickedToAdvance = false;
        StartCoroutine(TutorialAdvancer());
    }

    IEnumerator TutorialAdvancer()
    {
        while (!clickedToAdvance)
        {
            yield return new WaitForSeconds(0f);
        }
        clickedToAdvance = true;
    }
}
