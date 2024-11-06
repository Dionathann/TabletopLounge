using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TheAgentGameplayMechanism : MonoBehaviour
{
    [SerializeField] TheAgentRoleMechanism agentRoleMechanism;

    [SerializeField] InizializeLocation inizializeLocation;

    [SerializeField] GameObject imagePrefab;

    [SerializeField] Transform gridTransform;

    [SerializeField] TheAgentVoteMechanism theAgentVoteMechanism;

    [SerializeField] TimerMechanism timerMechanism;

    [SerializeField] GameObject gameplayScreen;

    private List<GameObject> locationDisplayerList = new List<GameObject>();

    public void Inizialize()
    {
        timerMechanism.StartTimer();
        TheAgentVoteMechanism.isGameOver = false;
    }

    public void DisplayLocation()
    {
        foreach (GameObject obj in locationDisplayerList)
        {
            Destroy(obj);
        }

        locationDisplayerList.Clear();

        agentRoleMechanism.GetShuffledLocation();

        for (int i = 0; i < agentRoleMechanism.GetMaxLocation(); i++)
        {
            GameObject newImage = Instantiate(imagePrefab, gridTransform);

            newImage.GetComponent<Image>().sprite = agentRoleMechanism.GetShuffledLocation()[i];

            GridIndex imageIndex = newImage.AddComponent<GridIndex>();

            imageIndex.index = i;

            Button button = newImage.GetComponent<Button>();

            if (button != null)
            {
                button.onClick.AddListener(() => OnButtonClick(imageIndex.index));

                button.interactable = false;
            }

            locationDisplayerList.Add(newImage);
        }
    }

    private void OnButtonClick(int i)
    {
        bool isCorrectLocation = agentRoleMechanism.GetCurrentLocationIndex(i);

        Debug.Log(isCorrectLocation);

        if (isCorrectLocation)
        {
            theAgentVoteMechanism.AgentChooseLocation(isCorrectLocation);
        }
        else
        {
            theAgentVoteMechanism.AgentChooseLocation(isCorrectLocation);
        }

        gameplayScreen.SetActive(false);
    }
    
    public void AgentReveal()
    {
        timerMechanism.PauseTimer();

        foreach (GameObject obj in locationDisplayerList)
        {
            obj.GetComponent<Button>().interactable = true;
        }
    }

    public bool IsGameOver()
    {
        return timerMechanism.GetGameOver();
    }
}

[System.Serializable]
public class GridIndex : MonoBehaviour
{
    public int index;
}
