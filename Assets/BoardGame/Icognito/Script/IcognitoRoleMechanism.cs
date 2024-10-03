using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IcognitoRoleMechanism : MonoBehaviour
{
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
    }

    [ContextMenu("Display Roles")]
    public void DisplayRoles()
    {
        foreach (IcognitoPlayerData character in playerData)
        {
            //Debug.Log(character.name + " is " + (character.isAltruistic ? "Altrustic" : "Ordinary"));
            if (character.isIcognito)
            {
                Debug.Log(character.name + " is " + " Icognito");
            }
            else
            {
                Debug.Log(character.name + " is " + " Ordinary");
            }
        }
    }
}
