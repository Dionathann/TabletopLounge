using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcognitoRoleMechanism : MonoBehaviour
{
    [SerializeField] NameHolder nameHolder;
    [SerializeField] TotalPlayerHolder totalPlayerHolder;
    [SerializeField] IcognitoImageData icognitoImageData;

    public int iconIndex;

    [System.Serializable]
    public class IcognitoPlayerData
    {
        public string name;
        public bool isIcognito;

        public IcognitoPlayerData(string name, bool icognito)
        {
            this.name = name;
            this.isIcognito = icognito;
        }
    }

    public List<string> playerName = new List<string>();
    public List<IcognitoPlayerData> playerData = new List<IcognitoPlayerData>();

    public void PassListName()
    {
        playerName.Clear();

        for (int i = 0; i < nameHolder.playerNameList.Count; i++)
        {
            playerName.Add(nameHolder.playerNameList[i]);
        }
    }

    [ContextMenu("TestRoleAssigner")]
    public void RoleAssign()
    {
        playerData.Clear();

        int icognitoIndex = Random.Range(0, playerName.Count);

        for (int i = 0; i < playerName.Count; i++)
        {
            //Assign role
            bool isIcognito = (i == icognitoIndex);

            playerData.Add(new IcognitoPlayerData(playerName[i], isIcognito));
        }

        iconIndex = Random.Range(0, icognitoImageData.iconList.Count);
    }

    [ContextMenu("Display Roles")]
    public void DisplayRoles()
    {
        foreach (IcognitoPlayerData character in playerData)
        {
            if (character.isIcognito)
            {
                Debug.Log(character.name + " is " + " Icognito");
            }
            else
            {
                Debug.Log(character.name + " is " + " not Icognito");
            }
        }
    }

    public Sprite IcognitoIcon()
    {
        return icognitoImageData.iconList[iconIndex];
    }

    public bool PlayerCheck()
    {
        if (playerName.Count != totalPlayerHolder.GetPlayerCount())
        {
            Debug.Log("Player Doesnt Same");
            return false;
        }
        else
        {
            Debug.Log("OK!");
            return true;
        }
    }
}
