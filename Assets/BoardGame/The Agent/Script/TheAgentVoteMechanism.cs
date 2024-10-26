using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class TheAgentVoteMechanism : MonoBehaviour
{
    [SerializeField] TheAgentRoleMechanism agentRoleMechanism;
    [SerializeField] GameObject nameDisplayer;

    [SerializeField] Transform contentHolder;
    public GameObject resultScreen;
    public GameObject voteScreen;

    [Header("The Agent Vote Screen")]
    [SerializeField] GameObject agentVotedScreen;
    [SerializeField] TextMeshProUGUI agentVotedText;
    [SerializeField] Image agentVotedImage;

    [Header("Not The Agent Vote Screen")]
    [SerializeField] GameObject notagentVotedScreen;
    [SerializeField] TextMeshProUGUI notagentVotedText;
    [SerializeField] Image notagentVotedImage;

    [Header("Asset Icons")]
    public Sprite theAgentIcon;

    private List<GameObject> voteDisplayers = new List<GameObject>();

    [ContextMenu("Initial Vote System")]
    public void InitialVoteSystem()
    {
        foreach (GameObject obj in voteDisplayers)
        {
            Destroy(obj);
        }

        voteDisplayers.Clear();

        for (int i = 0; i < agentRoleMechanism.playerName.Count; i++)
        {
            DisplayName(agentRoleMechanism.playerName[i], i);
        }
    }
    private void DisplayName(string name, int index)
    {
        var newGameObject = Instantiate(nameDisplayer, contentHolder);

        TextMeshProUGUI textInside = newGameObject.GetComponentInChildren<TextMeshProUGUI>();

        if (textInside != null)
        {
            textInside.text = name;
        }
        Button button = newGameObject.GetComponentInChildren<Button>();
        if (button != null)
        {
            button.onClick.AddListener(() => OnButtonClick(index));
        }
        GameObjectIndex indexComponent = newGameObject.AddComponent<GameObjectIndex>();
        indexComponent.index = index;

        voteDisplayers.Add(newGameObject);
    }

    public void OnButtonClick(int index)
    {
        resultScreen.SetActive(true);
        voteScreen.SetActive(false);

        bool isAgent = agentRoleMechanism.playerRole[index].isAgent;

        if (isAgent)
        {
            AgentVoted(index);
        }
        else
        {
            AgentNotVoted(index);
        }
    }

    public void AgentVoted(int i)
    {
        agentVotedScreen.SetActive(true);

        agentVotedText.text = "Yes, " + agentRoleMechanism.playerRole[i].playerName + " is The Agent!";

        agentVotedImage.sprite = theAgentIcon;
    }

    private void AgentNotVoted(int i)
    {
        if (!agentRoleMechanism.playerRole[i].isAgent)
        {
            notagentVotedScreen.SetActive(true);

            notagentVotedText.text = "No, " + agentRoleMechanism.playerRole[i].playerName + " is The Police!";

            notagentVotedImage.sprite = agentRoleMechanism.GetCurrentLocation();
        }
    }

    public void ShowTheAgent()
    {
        for (int i = 0; i < agentRoleMechanism.playerName.Count; i++)
        {
            if (agentRoleMechanism.playerRole[i].isAgent)
            {
                agentVotedScreen.SetActive(true);

                agentVotedText.text = agentRoleMechanism.playerRole[i].playerName + " Is The Agent!";

                agentVotedImage.sprite = theAgentIcon;
            }
        }
    }
}
