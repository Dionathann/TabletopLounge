using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class TotalPlayerHolder : MonoBehaviour
{

    private int maxPlayer = 8;
    private int minPlayer = 0;

    private int playerCount = 0;
    public int GetPlayerCount()
    {
        return playerCount;
    }

    public int GetMinPlayer()
    {
        return minPlayer; 
    }

    public int GetMaxPlayer()
    {
        return maxPlayer;
    }

    public void PlayerIncrement()
    {
        if(playerCount == maxPlayer)
        {
            Debug.Log("MaxPlayer Reached");
            return;
        }
        else
        {
            playerCount++;
        }
    }

    public void PlayerDecrement()
    {
        if(playerCount == minPlayer)
        {
            Debug.Log("MinPlayer Reached");
            return;
        }
        else
        {
            playerCount--;
        }
    }
}
