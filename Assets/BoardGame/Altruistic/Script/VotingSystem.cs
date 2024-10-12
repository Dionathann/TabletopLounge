using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VotingSystem : MonoBehaviour
{
    [SerializeField] AltruisticRoleMechanism altruisticRoleMechanism;
    [SerializeField] GameObject nameDisplayer;

    [SerializeField] Transform contentHolder;
    public GameObject resultScreen;

    [Header("Altrusistic Vote Screen")]
    [SerializeField] GameObject altruisticVotedScreen;
    [SerializeField] TextMeshProUGUI altruisticVotedText;
    [SerializeField] Image altruisticVotedImage;

    [Header("Not Altrusistic Vote Screen")]
    [SerializeField] GameObject notAltruisticVotedScreen;
    [SerializeField] TextMeshProUGUI notAltruisticVotedText;
    [SerializeField] Image notAltruisticVotedImage;

    [Header("Asset Image")]
    public Sprite altruisticCard;
    public Sprite ordinaryCard;
    public Sprite supportCard;

    [ContextMenu("Initial Vote System")]
    public void InitialVoteSystem()
    {
        for (int i = 0; i < altruisticRoleMechanism.playerName.Count; i++)
        {
            if (!altruisticRoleMechanism.characters[i].isMaster)
            {
                DisplayName(altruisticRoleMechanism.playerName[i], i);
            }
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
    }

    public void OnButtonClick(int index)
    {
        Debug.Log("Player " + index + " clicked");

        ShowEverything(index);

        Debug.Log("Test");
    }

    private void ShowEverything(int index)
    {
        Debug.Log("Show Everything");

        resultScreen.SetActive(true);

        bool altruistic = altruisticRoleMechanism.characters[index].isAltruistic;

        Debug.Log(altruistic);

        if (altruistic)
        {
            AltruisticVoted(index);
        }
        else
        {
            AltruisticNotVoted(index);
        }

    }

    public void AltruisticVoted(int i)
    {
        altruisticVotedScreen.SetActive(true);

        altruisticVotedText.text = "Yes, " + altruisticRoleMechanism.characters[i].name + " Is an Altruistic!";

        altruisticVotedImage.sprite = altruisticCard;
    }

    private void AltruisticNotVoted(int i)
    {
        if (altruisticRoleMechanism.characters[i].isOrdinary)
        {
            notAltruisticVotedScreen.SetActive(true);

            notAltruisticVotedText.text = "No, " + altruisticRoleMechanism.characters[i].name + " Is an Ordinary!";

            notAltruisticVotedImage.sprite = ordinaryCard;
        }
        if (altruisticRoleMechanism.characters[i].isSupport)
        {
            notAltruisticVotedScreen.SetActive(true);

            notAltruisticVotedText.text = "No, " + altruisticRoleMechanism.characters[i].name + " Is an Support!";

            notAltruisticVotedImage.sprite = supportCard;
        }
    }

    public void ShowAltruistic()
    {
        for (int i = 0; i < altruisticRoleMechanism.playerName.Count; i++)
        {
            if (altruisticRoleMechanism.characters[i].isAltruistic)
            {
                altruisticVotedScreen.SetActive(true);

                altruisticVotedText.text = altruisticRoleMechanism.characters[i].name + " Is an Altruistic!";

                altruisticVotedImage.sprite = altruisticCard;
            }
        }
    }
}

[System.Serializable]
public class GameObjectIndex : MonoBehaviour
{
    public int index;
}
