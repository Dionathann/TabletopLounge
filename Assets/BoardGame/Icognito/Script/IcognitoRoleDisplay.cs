using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IcognitoRoleDisplay : MonoBehaviour
{
    private int currentIndexPlayer = 0;
    [SerializeField] IcognitoRoleMechanism icognitoRoleMechanism;
    [SerializeField] IcognitoRoleCardFlipper icognitoRoleCardFlipper;
    [SerializeField] NameHolder nameHolder;
    [SerializeField] WarningDisplay warningDisplay;

    [Header("UI References")]
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] Image roleCardImage;
    [SerializeField] GameObject gameConfigurationCanvasPrefab;
    [SerializeField] GameObject roleDisplayIcognitoPrefab;
    public Button nextButton;
    [SerializeField] GameObject confirmationPanel;
    [SerializeField] TextMeshProUGUI confirmationPlayerName;
    [SerializeField] GameObject confirmationScreen;

    [Header("Image Asset")]
    public Sprite backCard;
    [SerializeField] Sprite icognitoCardRole;

    private bool gameModeCheck;



    public void IcognitoInizialize()
    {

        icognitoRoleMechanism.PassListName();

        bool isPassed = icognitoRoleMechanism.PlayerCheck();

        Debug.Log(isPassed);

        if (isPassed == false)
        {
            Debug.Log("Fail Inizialize");
            warningDisplay.SetWarningMessage("You Need To Assign Name First!");
            return;
        }

        ///////////////////////////////////////////////////////////////////////////////
        
        PlayerAmountCheck();

        if(gameModeCheck == false)
        {
            return;
        }

        ///////////////////////////////////////////////////////////////////////////////

        gameConfigurationCanvasPrefab.SetActive(false);
        roleDisplayIcognitoPrefab.SetActive(true);

        icognitoRoleMechanism.PassListName();

        icognitoRoleMechanism.RoleAssign();

        roleCardImage.sprite = backCard;

        icognitoRoleCardFlipper.ForceFaceDownCard();

        currentIndexPlayer = 0;

        ShowPlayerConfirmation();

    }
    public void ShowPlayerConfirmation()
    {
        confirmationPlayerName.text = icognitoRoleMechanism.playerData[currentIndexPlayer].name;

        confirmationPanel.SetActive(true);
    }

    public void HidePlayerConfirmation()
    {
        confirmationPanel.SetActive(false);
    }

    public void NextPlayerButton()
    {
        if (currentIndexPlayer >= icognitoRoleMechanism.playerData.Count - 1)
        {
            Debug.Log("Role Finish");
            roleDisplayIcognitoPrefab.SetActive(false);
            confirmationScreen.SetActive(true);
            return;
        }

        currentIndexPlayer++;

        Debug.Log("show Role");

        icognitoRoleCardFlipper.ForceFaceDownCard();

        nextButton.interactable = false;

        roleCardImage.sprite = backCard;

        nameText.text = icognitoRoleMechanism.playerData[currentIndexPlayer].name;

        ShowPlayerConfirmation();

    }
    public void GetPlayerRole(int index)
    {
        if (icognitoRoleMechanism.playerData[index].isIcognito)
        {
            roleCardImage.sprite = icognitoCardRole;
            Debug.Log(icognitoRoleMechanism.playerData[index].name);
        }
        else
        {
            roleCardImage.sprite = icognitoRoleMechanism.IcognitoIcon();
        }
    }
    private void PlayerAmountCheck()
    {
        gameModeCheck = false;

        if(nameHolder.playerNameList.Count < 3)
        {
            warningDisplay.SetWarningMessage("Player Must More Than 3");
            return;
        }

        gameModeCheck = true;
    }

    public int GetCurrentPlayerIndex()
    {
        return currentIndexPlayer;
    }
}
