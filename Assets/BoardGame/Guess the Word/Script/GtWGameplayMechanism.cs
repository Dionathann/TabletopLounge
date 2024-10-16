using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GtWGameplayMechanism : MonoBehaviour
{
    [SerializeField] NameHolder nameHolder;

    private int currentIndexPlayer;

    public List<string> GetPlayerNameList()
    {
        return nameHolder.playerNameList;
    }

    public int GetRandomIndexPlayer()
    {
        currentIndexPlayer = Random.Range(0, nameHolder.playerNameList.Count);

        return currentIndexPlayer;
    }
}
