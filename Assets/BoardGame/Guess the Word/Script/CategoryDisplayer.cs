using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CategoryDisplayer : MonoBehaviour
{
    [SerializeField] List<CategoryData> categoryDataList;

    [SerializeField] GtWPreparation preparation;
    //[SerializeField] GtWGameplayMechanism gameplayMechanism;

    public GameObject categoryHolderPrefab;
    public Transform categoryContentHolder;

    public int selectedIndex;

    [Header("Category Displayer UI")]
    public GameObject categoryDisplayerUI;
    public GameObject gameplayScreen;

    [Header("Confirmation UI")]
    public GameObject confirmationUI;

    private List<GameObject> tempCategoryList = new List<GameObject>();

    private void Start()
    {
        for(int i = 0; i < categoryDataList.Count; i++)
        {
            categoryDataList[i].wordList.Clear();
        }
        //categoryDataList.Clear();
    }

    [ContextMenu("Display Category List")]
    public void Displaydata()
    {
        foreach(GameObject obj in tempCategoryList)
        {
            Destroy(obj);
        }

        tempCategoryList.Clear();

        for(int i = 0; i < categoryDataList.Count; i++)
        {
            int currentindex = i;

            GameObject newobj = Instantiate(categoryHolderPrefab, categoryContentHolder);
            
            newobj.GetComponentInChildren<TextMeshProUGUI>().text = categoryDataList[i].categoryName;

            newobj.GetComponent<Button>().onClick.AddListener(() => ShowConfirmation(currentindex));

            tempCategoryList.Add(newobj);
        }
    }

    public void ShowConfirmation(int index)
    {
        confirmationUI.SetActive(true);

        TextMeshProUGUI[] newText = confirmationUI.GetComponentsInChildren<TextMeshProUGUI>();

        foreach(TextMeshProUGUI text in newText)
        {
            if(text.name == "Category Name")
            {
                text.text = categoryDataList[index].categoryName;
            }
            if(text.name == "Description Text")
            {
                text.text = categoryDataList[index].description;
            }
        }

        SetSelectedCategoryIndex(index);

        Button[] button = confirmationUI.GetComponentsInChildren<Button>();

        foreach(Button btn in button)
        {
            if (btn.name == "Play Button")
            {
                btn.onClick.RemoveAllListeners();

                btn.onClick.AddListener(() => SetupGameplay(index));

                /*btn.onClick.RemoveAllListeners();
                playButtonListener = () => SetupGameplay(currentIndex);
                btn.onClick.AddListener(playButtonListener.Invoke);*/
            }
            if(btn.name == "Close Button")
            {
                btn.onClick.RemoveAllListeners();

                btn.onClick.AddListener(() => HideConfirmation(index));

                /*btn.onClick.RemoveAllListeners();
                btn.onClick.AddListener(() => RemovePlayButtonListener(button));
                //btn.onClick.AddListener(() => HideConfirmation(currentIndex));*/
            }
        }
    }

    private void SetSelectedCategoryIndex(int index)
    {
        selectedIndex = index;
    }

    public int GetSelectedIndex()
    {
        return selectedIndex;
    }

    public void HideConfirmation(int index)
    {
        confirmationUI.SetActive(false);
    }

    public CategoryData GetPlayableCategoryList()
    {
        if (selectedIndex >= 0 && selectedIndex < categoryDataList.Count)
        {
            Debug.Log("GetPlayableCategoryList");
            return categoryDataList[selectedIndex];
        }
        return null;
    }

    public void SetupGameplay(int index)
    {
        categoryDataList[index].SetupWord(index);

        categoryDisplayerUI.SetActive(false);

        if (preparation.countdownCoroutine != null)
        {
            StopCoroutine(preparation.countdownCoroutine);
        }

        preparation.countdownCoroutine = preparation.StartCoroutine(preparation.StartCountdown());
    }

    /*private void RemovePlayButtonListener(Button[] buttons)
    {
        foreach (Button btn in buttons)
        {
            if (btn.name == "Play Button")
            {
                btn.onClick.RemoveListener(playButtonListener.Invoke); // Remove the stored listener
                break;
            }
        }
    }*/
}
