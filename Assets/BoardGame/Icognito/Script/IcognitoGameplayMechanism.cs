using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IcognitoGameplayMechanism : MonoBehaviour
{
    [SerializeField] IcognitoImageData icognitoImageData;
    //[SerializeField] TimerMechanism timerMechanism;

    [SerializeField] GameObject icognitoGameplayScreen;
    [SerializeField] Image categoryImage;

    private void Update()
    {
        
    }


    [ContextMenu("Start Game")]
    public void StartGame()
    {
        icognitoGameplayScreen.SetActive(true);

        //timerMechanism.StartTimer();

        int i = Random.Range(0, icognitoImageData.categoryList.Count);

        categoryImage.sprite = icognitoImageData.categoryList[i];
    }



    public void ResumeGame()
    {
        //timerMechanism.ResumeTimer();
    }

    public void PauseGame()
    {
        //timerMechanism.PauseTimer();
    }

    public void StopGame()
    {

    }
}
