using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IcognitoVotingechaism : MonoBehaviour
{
    [SerializeField] IcognitoRoleMechanism icognitoRoleMechanism;
    [SerializeField] GameObject nameDisplayer;
    [SerializeField] Transform contentHolder;

    [Header("UI References")]
    [SerializeField] GameObject voteScreen;
    [SerializeField] GameObject resultScreen;

    [Header("Icognito Voted Screen")]
    [SerializeField] GameObject icognitoVotedScreen;
    [SerializeField] TextMeshProUGUI icognitoVotedText;
    [SerializeField] Image icognitoVotedImage;
    [SerializeField] Sprite icognitoIcon;

    [Header("Icognito Voted Screen")]
    [SerializeField] GameObject icognitoNotVotedScreen;
    [SerializeField] TextMeshProUGUI icognitoNotVotedText;
    [SerializeField] Image icognitoNotVotedImage;
    private Sprite currentIcon;

    private List<GameObject> voteDisplayers = new List<GameObject>();

    [ContextMenu("Initialize Vote Screen")]
    public void InizializeVoteScreen()
    {
        foreach (GameObject obj in voteDisplayers)
        {
            Destroy(obj);
        }

        voteDisplayers.Clear();

        for (int i = 0; i < icognitoRoleMechanism.playerName.Count; i++)
        {
            DisplayName(icognitoRoleMechanism.playerName[i], i);
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

    private void OnButtonClick(int index)
    {
        voteScreen.SetActive(false);

        resultScreen.SetActive(true);

        bool icognito = icognitoRoleMechanism.playerData[index].isIcognito;

        if (icognito)
        {
            IcognitoVoted(index);
        }
        else
        {
            IcognitoNotVoted(index);
        }
    }

    private void IcognitoVoted(int i)
    {
        icognitoVotedScreen.SetActive(true);

        icognitoVotedText.text = "Yes, " + icognitoRoleMechanism.playerData[i].name + " is an Icognito!";

        icognitoVotedImage.sprite = icognitoIcon;
    }

    private void IcognitoNotVoted(int i)
    {
        icognitoNotVotedScreen.SetActive(true);

        icognitoNotVotedText.text = "No, " + icognitoRoleMechanism.playerData[i].name + " is not an Icognito!";

        icognitoNotVotedImage.sprite = icognitoRoleMechanism.IcognitoIcon();
    }

    public void ShowIcognito()
    {
        for (int i = 0; i < icognitoRoleMechanism.playerName.Count; i++)
        {
            if (icognitoRoleMechanism.playerData[i].isIcognito)
            {
                icognitoVotedScreen.SetActive(true);

                icognitoVotedText.text = icognitoRoleMechanism.playerData[i].name + " is an Icognito!";

                icognitoVotedImage.sprite = icognitoIcon;
            }
        }

    }
}
