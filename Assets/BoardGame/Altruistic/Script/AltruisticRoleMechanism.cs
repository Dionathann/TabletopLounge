using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltruisticRoleMechanism : MonoBehaviour
{
    [SerializeField] TotalPlayerHolder totalPlayerHolder;
    public class AltruisticPlayerData
    {
        public string name;
        public bool isMaster;
        public bool isAltruistic;
        public bool isOrdinary;

        public AltruisticPlayerData(string name, bool master, bool altruistic, bool ordinary)
        {
            this.name = name;
            this.isMaster = master;
            this.isAltruistic = altruistic;
            this.isOrdinary = ordinary;
        }
    }

    public List<string> playerName = new List<string>();
    public List<AltruisticPlayerData> characters = new List<AltruisticPlayerData>();

    [ContextMenu("Test 3 Player Mode")]
    private void ThreePlayerOnly()
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

            characters.Add(new AltruisticPlayerData(playerName[i], isMaster, false, isOrdinary));
        }
    }

    [ContextMenu("TestRoleAssigner")]
    private void NormalMode()
    {
        int currentplayer = totalPlayerHolder.GetPlayerCount();
        int minplayer = totalPlayerHolder.GetMinPlayer();
        int maxplayer = totalPlayerHolder.GetMaxPlayer();

        if (currentplayer <= minplayer || currentplayer >= maxplayer)
        return;

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

            characters.Add(new AltruisticPlayerData(playerName[i], isMaster, isAltruistic, isOrdinary));
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
}

