using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataChecker : MonoBehaviour
{
    //[SerializeField] GameObject usePreviousPanel;
    public void OnEnable()
    {
        if(PlayerNameData.playerNameList.Count == 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
