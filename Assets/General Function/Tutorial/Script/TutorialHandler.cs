using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialHandler : MonoBehaviour
{
    public GameObject tutorialPanel;
    public GameObject nextButton;
    public GameObject prevButton;
    public GameObject tutorialText;

    public List<GameObject> tutorialPages = new List<GameObject>();
    private int pageIndex;

    private void OnEnable()
    {
        tutorialPages[pageIndex].SetActive(true);
        ResetIndex();
    }

    private void OnDisable()
    {
        foreach (GameObject page in tutorialPages)
        {
            page.SetActive(false);
        }
        ResetIndex();
    }

    public void ResetIndex()
    {
        pageIndex = 0;
    }

    public void ShowTutorial()
    {
        pageIndex = 0;
        tutorialPanel.SetActive(true);
        tutorialPages[pageIndex].SetActive(true);
        nextButton.SetActive(true);
        prevButton.SetActive(false);
    }

    public void NextButton()
    {
        pageIndex++;


        if (pageIndex >= tutorialPages.Count)
        {
            pageIndex = tutorialPages.Count - 1;
            tutorialText.SetActive(false);
        }

        nextButton.SetActive(pageIndex < tutorialPages.Count - 1);

        prevButton.SetActive(pageIndex > 0);

        ShowPages();
    }

    public void PreviousButton()
    {
        pageIndex--;

        if (pageIndex < 0)
        {
            pageIndex = 0;

        }

        nextButton.SetActive(pageIndex < tutorialPages.Count - 1);

        prevButton.SetActive(pageIndex > 0);

        ShowPages();

        tutorialText.SetActive(true);
    }

    public void ShowPages()
    {
        foreach (GameObject page in tutorialPages) 
        {
            page.SetActive(false);
        }

        tutorialPages[pageIndex].SetActive(true);
    }
}
