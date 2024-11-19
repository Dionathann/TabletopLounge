using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class TheAgentRoleDisplay : MonoBehaviour
{
    private int currentIndexPlayer;

    [Header("Script Reference")]
    [SerializeField] TheAgentRoleMechanism agentRoleMechanism;
    [SerializeField] NameHolder nameHolder;
    [SerializeField] WarningDisplay warningDisplay;
    [SerializeField] TheAgentRoleCardFlipper agentRoleCardFlipper;

    [Header("Image Asset")]
    public Sprite backCard;
    [SerializeField] Sprite agentRoleCard;

    [Header("UI Reference")]
    [SerializeField] GameObject gameConfigurationCanvasPrefab;
    [SerializeField] GameObject roleDisplayAgentPrefab;
    [SerializeField] Image roleCardImage;
    public Button nextButton;
    [SerializeField] GameObject confirmationScreen;
    [SerializeField] GameObject confirmationPanel;
    [SerializeField] TextMeshProUGUI confirmationPlayerName;
    [SerializeField] TextMeshProUGUI topTextPlayer;

    [Header("Agent Role Display")]
    public GameObject agentImageCard;

    [Header("Location Display")]
    public GameObject locationHolder;
    [SerializeField] Image middleIcon;
    public TextMeshProUGUI imageLocationName;

    private bool gameModeCheck;
    private List<Sprite> copySprite = new List<Sprite>();

    public void Inizialize()
    {
        agentRoleMechanism.PassListName();

        bool isPassed = agentRoleMechanism.PlayerCheck();

        if (isPassed == false)
        {
            warningDisplay.SetWarningMessage("You Need To Assign Name First!");
            return;
        }

        Debug.Log("Passed!");

        PlayerAmountCheck();

        if(gameModeCheck == false)
        {
            return;
        }

        gameConfigurationCanvasPrefab.SetActive(false);

        roleDisplayAgentPrefab.SetActive(true);

        agentRoleMechanism.RoleAssign();

        currentIndexPlayer = 0;

        topTextPlayer.text = agentRoleMechanism.playerRole[currentIndexPlayer].playerName;

        agentRoleCardFlipper.ForceFaceDownCard();

        roleCardImage.sprite = backCard;

        agentImageCard.SetActive(false);

        nextButton.interactable = false;

        ShowPlayerConfirmation();

    }

    public void ShowPlayerConfirmation()
    {
        confirmationPlayerName.text = agentRoleMechanism.playerRole[currentIndexPlayer].playerName;

        confirmationPanel.SetActive(true);
    }

    public void HidePlayerConfirmation()
    {
        confirmationPanel.SetActive(false);
    }

    public void NextPlayerButton()
    {
        if (currentIndexPlayer >= agentRoleMechanism.playerRole.Count - 1)
        {
            Debug.Log("Role Finish");
            roleDisplayAgentPrefab.SetActive(false);
            confirmationScreen.SetActive(true);
            return;
        }

        currentIndexPlayer++;

        agentRoleCardFlipper.ForceFaceDownCard();

        nextButton.interactable = false;

        topTextPlayer.text = agentRoleMechanism.playerRole[currentIndexPlayer].playerName;

        roleCardImage.sprite = backCard;

        agentImageCard.SetActive(false);
        
        ShowPlayerConfirmation();
    }

    public void GetPlayerRole(int index)
    {
        if (agentRoleMechanism.playerRole[index].isAgent)
        {
            DisableMiddleIcon();
            agentImageCard.SetActive(true);
            locationHolder.SetActive(false);
            agentImageCard.GetComponent<Image>().sprite = agentRoleCard;
        }
        else
        {
            EnableMiddleIcon();
            agentImageCard.SetActive(false);
            locationHolder.SetActive(true);
            //roleCardImage.sprite = null;
            middleIcon.sprite = agentRoleMechanism.GetShuffledLocation()[agentRoleMechanism.currentLocationIndex];
            imageLocationName.text = agentRoleMechanism.GetCurrentLocationName();
            imageLocationName.gameObject.SetActive(true);
        }

    }

    private void PlayerAmountCheck()
    {
        gameModeCheck = false;

        if (nameHolder.playerNameList.Count < 3)
        {
            warningDisplay.SetWarningMessage("Player Must More Than 3");
            return;
        }

        gameModeCheck = true;
    }



    public int GetCurrentIndexPlayer()
    {
        return currentIndexPlayer;
    }
    public void DisableMiddleIcon()
    {
        middleIcon.gameObject.SetActive(false);
    }

    public void EnableMiddleIcon()
    {
        middleIcon.gameObject.SetActive(true);
    }

    public string GetCurrentLocationName()
    {
        return agentRoleMechanism.GetCurrentLocationName();
    }
}
