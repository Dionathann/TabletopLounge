using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheAgentRoleMechanism : MonoBehaviour
{
    public class TheAgentPlayerData
    {
        public string playerName;
        public bool isAgent;

        public TheAgentPlayerData(string playerName,bool agent)
        {
            this.playerName = playerName;
            this.isAgent = agent;
        }
    }

    public List<string> playerName = new List<string>();
    public List<TheAgentPlayerData> playerRole = new List<TheAgentPlayerData>();

    [ContextMenu("TestRoleAssigner")]
    public void RoleAssign()
    {
        playerRole.Clear();

        int icognitoIndex = Random.Range(0, playerName.Count);

        for (int i = 0; i < playerName.Count; i++)
        {
            //Assign role
            bool isAgent = (i == icognitoIndex);

            playerRole.Add(new TheAgentPlayerData(playerName[i], isAgent));
        }
    }

    [ContextMenu("Display Roles")]
    public void DisplayRoles()
    {
        foreach (TheAgentPlayerData character in playerRole)
        {
            //Debug.Log(character.name + " is " + (character.isAltruistic ? "Altrustic" : "Ordinary"));
            if (character.isAgent)
            {
                Debug.Log(character.playerName + " is The Agent");
            }
            else
            {
                Debug.Log(character.playerName + " is Police ");
            }
        }
    }
}
