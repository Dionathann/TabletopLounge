using System.Collections.Generic;
using UnityEngine;

public class TheAgentRoleMechanism : MonoBehaviour
{
    [SerializeField] NameHolder nameHolder;

    [SerializeField] TotalPlayerHolder totalPlayerHolder;

    [SerializeField] InizializeLocation inizializeLocation;

    private int maxLocation = 15;

    [System.Serializable]
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

    public int currentLocationIndex;


    [ContextMenu("test pass Name")]
    public void PassListName()
    {
        playerName.Clear();

        foreach(string name in nameHolder.playerNameList)
        {
            playerName.Add(name);
        }
    }

    [ContextMenu("TestRoleAssigner")]
    public void RoleAssign()
    {
        playerRole.Clear();

        int agentIndex = Random.Range(0, playerName.Count);

        for (int i = 0; i < playerName.Count; i++)
        {
            //Assign role
            bool isAgent = (i == agentIndex);

            playerRole.Add(new TheAgentPlayerData(playerName[i], isAgent));
        }

        currentLocationIndex = RandomLocation();

        inizializeLocation.RandomizerLocation();
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

    public bool PlayerCheck()
    {
        if (playerName.Count == 0)
        {
            Debug.Log("You Need To Assign Name First!");
            return false;
        }

        return true;
        
    }

    public int GetMaxLocation()
    {
        return maxLocation;
    }

    public int RandomLocation()
    {
        return Random.Range(0, maxLocation);
    }

    public List<Sprite> GetShuffledLocation()
    {
        return inizializeLocation.shuffledLocationList;
    }

    public string GetCurrentLocationName()
    {
        return inizializeLocation.shuffledLocationNames[currentLocationIndex];
    }

    public Sprite GetCurrentLocation()
    {
        return inizializeLocation.shuffledLocationList[currentLocationIndex];
    }

    public bool GetCurrentLocationIndex(int i)
    {
        if(currentLocationIndex == i)
        {
            return true;
        }

        return false;
    }
}
