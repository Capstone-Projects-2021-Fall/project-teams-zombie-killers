using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    [Header("Dialogue Options")]
    public GameObject dialogueBox;
    public TextMeshProUGUI tutorialText;
    public GameObject clickAdvanceText;
    public string[] lines;
    public float textSpeed;
    private int index;

    [Header("Highlight Panels")]
    public GameObject defenderSelectionPanelHighlight;
    public GameObject coinsPanelHighlight;
    public GameObject livesPanelHighlight;
    public GameObject progressBarHighlight;
    public GameObject screenLeftHighlight;
    public GameObject screenRightHighlight;
    public GameObject noHighlight;

    [Header("Defender Selection Buttons")]
    [SerializeField] private Button horsemanButton;
    [SerializeField] private Button trophyButton;

    private PauseScreen pauseComponent;

    private void Start()
    {
        horsemanButton.onClick.AddListener(DefenderNextLine);
        trophyButton.onClick.AddListener(DefenderNextLine);
        pauseComponent = gameObject.GetComponent<PauseScreen>();
        tutorialText.text = string.Empty;
        StartTutorial();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (tutorialText.text == lines[index] && index != 2)
            {
                NextLine();
            }
            else
            {
                StopCoroutine(TypeLine());
                tutorialText.text = lines[index];
            }
        }
    }

    void StartTutorial()
    {
        dialogueBox.SetActive(true);
        index = 0;
        tutorialText.text = lines[index];
        StartCoroutine(PauseUnpause());
        //StartCoroutine(TypeLine());
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            tutorialText.text = lines[index];
            //tutorialText.text = string.Empty;
            //StartCoroutine(TypeLine());
            HighlightCheck().SetActive(true);
            StartCoroutine(DeactivateHighlight(HighlightCheck()));
        }
        else
        {
            //dialogueBox.SetActive(false);
            StopAllCoroutines();
            gameObject.SetActive(false);
        }
    }

    IEnumerator PauseUnpause()
    {
        pauseComponent.enabled = false;
        while (index < 2)
        {
            yield return new WaitForSeconds(0);
        }
        pauseComponent.enabled = !pauseComponent.enabled;
    }

    public void DefenderNextLine()
    {
        NextLine();
        horsemanButton.onClick.RemoveListener(DefenderNextLine);
        trophyButton.onClick.RemoveListener(DefenderNextLine);
    }

    IEnumerator DeactivateHighlight(GameObject highlight)
    {
        int nextLine = index + 1;
        while (index != nextLine)
        {
            yield return new WaitForSeconds(0);
        }
        highlight.SetActive(false);
    }

    GameObject HighlightCheck()
    {
        switch (index)
        {
            case 2:
                return defenderSelectionPanelHighlight;
            case 3:
            case 5:
                return screenLeftHighlight;
            case 4:
                return screenRightHighlight;
            case 7:
                return livesPanelHighlight;
            case 8:
                return progressBarHighlight;
            case 10:
                return coinsPanelHighlight;
            default:
                return noHighlight;
        }
    }

    // CURRENTLY NOT BEING USED
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            tutorialText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
}