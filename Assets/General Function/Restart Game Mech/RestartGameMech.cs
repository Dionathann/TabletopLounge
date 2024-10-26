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
    public void RestartSameGameConfig()
    {
        gameObject.SetActive(false);
        resultScreenPanel.SetActive(false);
        votedScreen.SetActive(false);
        notVotedScreen.SetActive(false);
        timesUpScreen.SetActive(false);
        
    }

    public void RestartDifferentGameConfig()
    {
        resultScreenPanel.SetActive(false);
        gameObject.SetActive(false);
        gameConfigPanel.SetActive(true);
        votedScreen.SetActive(false);
        notVotedScreen.SetActive(false);
        timesUpScreen.SetActive(false);
    }
}
