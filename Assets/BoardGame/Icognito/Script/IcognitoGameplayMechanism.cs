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

    private List<Sprite> tempCategoryList = new List<Sprite>();
    [ContextMenu("Start Game")]
    public void StartGame()
    {
        tempCategoryList?.Clear();

        tempCategoryList = new List<Sprite>(icognitoImageData.categoryList);

        for (int i = 0; i < tempCategoryList.Count; i++)
        {
            Sprite temp = tempCategoryList[i];

            int index = Random.Range(0, tempCategoryList.Count);

            tempCategoryList[i] = tempCategoryList[index];

            tempCategoryList[index] = temp;
        }

        icognitoGameplayScreen.SetActive(true);

        int randomizer = Random.Range(0, tempCategoryList.Count);

        categoryImage.sprite = icognitoImageData.categoryList[randomizer];
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
