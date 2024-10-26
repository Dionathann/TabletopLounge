using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AltruisticRoleMechanism : MonoBehaviour
{
    [SerializeField] TotalPlayerHolder totalPlayerHolder;
    [SerializeField] NameHolder nameHolder;
    [SerializeField] TMP_Dropdown gameMode;
    [System.Serializable]
    public class AltruisticPlayerData
    {
        public string name;
        public bool isMaster;
        public bool isAltruistic;
        public bool isOrdinary;
        public bool isSupport;

        public AltruisticPlayerData(string name, bool master, bool altruistic, bool ordinary, bool support)
        {
            this.name = name;
            this.isMaster = master;
            this.isAltruistic = altruistic;
            this.isOrdinary = ordinary;
            this.isSupport = support;
        }
    }

    public List<string> playerName = new List<string>();
    public List<AltruisticPlayerData> characters = new List<AltruisticPlayerData>();

    /*public void InitializeGame()
    {
        PassListName();
        GetGameMode();
    }*/

    public void PassListName()
    {
        playerName.Clear();

        for (int i = 0; i < nameHolder.playerNameList.Count; i++)
        {
            playerName.Add(nameHolder.playerNameList[i]);
        }
    }

    [ContextMenu("Test 3 Player Mode")]
    public void ThreePlayerMode()
    {
        if (totalPlayerHolder.GetPlayerCount() != 3)
            return;

        characters.Clear();
        int masterIndex = Random.Range(0, playerName.Count);

        for (int i = 0; i < playerName.Count; i++)
        {
            //Assign role
            bool isMaster = (i == masterIndex);
            bool isOrdinary = !isMaster;

            characters.Add(new AltruisticPlayerData(playerName[i], isMaster, false, isOrdinary, false));
        }
    }

    [ContextMenu("TestRoleAssigner")]
    public void NormalMode()
    {
        characters.Clear();

        int masterIndex = Random.Range(0, playerName.Count);
        int altruisticIndex;

        do
        {
            altruisticIndex = Random.Range(0, playerName.Count);
        } while (altruisticIndex == masterIndex);


        for(int i = 0; i < playerName.Count; i++) 
        {
            //Assign role
            bool isMaster = (i == masterIndex);
            bool isAltruistic = (i == altruisticIndex);
            bool isOrdinary = !isMaster && !isAltruistic;

            characters.Add(new AltruisticPlayerData(playerName[i], isMaster, isAltruistic, isOrdinary, false));
        }
    }

    public void AdditionalRole()
    {
        characters.Clear();

        int masterIndex = Random.Range(0, playerName.Count);
        int altruisticIndex, supportIndex;

        do
        {
            altruisticIndex = Random.Range(0, playerName.Count);
        }while (altruisticIndex == masterIndex);

        do
        {
            supportIndex = Random.Range(0, playerName.Count);
        }while( supportIndex == masterIndex && supportIndex == altruisticIndex);

        for (int i = 0; i < playerName.Count; i++)
        {
            //Assign role
            bool isMaster = (i == masterIndex);
            bool isAltruistic = (i == altruisticIndex);
            bool isSupport = (i == supportIndex);
            bool isOrdinary = !isMaster && !isAltruistic && !isSupport;

            characters.Add(new AltruisticPlayerData(playerName[i], isMaster, isAltruistic, isOrdinary, isSupport));
        }
    }

    public void MasterPickUp(int newIndex)
    {
        int altruisticIndex = Random.Range(0, playerName.Count);

        do
        {
            altruisticIndex = Random.Range(0, playerName.Count);
        } while (altruisticIndex == newIndex);

        for (int i = 0; i < playerName.Count; i++)
        {
            if (i != newIndex)
            {
                bool isAltruistic = (i == altruisticIndex);
                bool isOrdinary = !isAltruistic;
                characters.Add(new AltruisticPlayerData(playerName[i], false, isAltruistic, isOrdinary, false));
            }
        }
    }



    [ContextMenu("Display Role")]
    private void DisplayRoles()
    {
        foreach (AltruisticPlayerData character in characters)
        {
            //Debug.Log(character.name + " is " + (character.isAltruistic ? "Altrustic" : "Ordinary"));
            if (character.isAltruistic)
            {
                Debug.Log(character.name + " is " + " Altruistic");
            }
            if (character.isMaster)
            {
                Debug.Log(character.name + " is " + " Master");
            }
            if (character.isOrdinary)
            {
                Debug.Log(character.name + " is " + "Ordinary");
            }
        }
    }

    public bool PlayerCheck()
    {
        if(playerName.Count == 0)
        {
            Debug.Log("You Need To Assign Name First");
            return false;
        }
        
        return true;
        
    }

    public TMP_Dropdown GetDropDown()
    {
        return gameMode;
    }

}

