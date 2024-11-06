using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGameMech : MonoBehaviour
{
    [SerializeField] GameObject gameConfigPanel;
    [SerializeField] GameObject resultScreenPanel;

    [SerializeField] GameObject votedScreen;
    [SerializeField] GameObject notVotedScreen;
    [SerializeField] GameObject timesUpScreen;

    public List<GameObject> activatedGameObjects = new List<GameObject>();
    public List<GameObject> nonActivateGameObjects = new List<GameObject>();

    public void RestartSameGameConfig()
    {
        foreach (GameObject obj in nonActivateGameObjects)
        {
            obj.SetActive(false);
        }
/*
        gameObject.SetActive(false);
        resultScreenPanel.SetActive(false);
        votedScreen.SetActive(false);
        notVotedScreen.SetActive(false);
        timesUpScreen.SetActive(false);*/
        
    }

    public void RestartDifferentGameConfig()
    {
        foreach (GameObject obj in nonActivateGameObjects)
        {
            obj.SetActive(false);
        }

        foreach (GameObject obj in activatedGameObjects)
        {
            obj.SetActive(true);
        }
/*
        resultScreenPanel.SetActive(false);
        gameObject.SetActive(false);
        gameConfigPanel.SetActive(true);
        votedScreen.SetActive(false);
        notVotedScreen.SetActive(false);
        timesUpScreen.SetActive(false);*/
    }
}
