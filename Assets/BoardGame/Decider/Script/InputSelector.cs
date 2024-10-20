using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSelector : MonoBehaviour
{
    public List<Color> colors = new List<Color>();

    public void SelectFinger(List<InputLocation> list, string amount)
    {
        int selectedAmount = int.Parse(amount);

        List<InputLocation> tempList = RandomList(list);

        List<InputLocation> secondList = RandomList(tempList);

        for(int i = 0; i < secondList.Count; i++)
        {
            if(i > selectedAmount - 1)
            {
                secondList[i].circles.SetActive(false);
            }
        }
    }
    public void DivideGroup(List<InputLocation> list, string group)
    {
        List<InputLocation> tempList = RandomList(list);

        int playerInGroup = tempList.Count / int.Parse(group);

        int currentColor = 0;

        for (int i = 0; i < tempList.Count; i += playerInGroup)
        {
            int groupEnd = Mathf.Min(i + playerInGroup, tempList.Count);
            for (int j = i; j < groupEnd; j++)
            {
                GameObject newObj = tempList[j].circles;

                newObj.GetComponent<SpriteRenderer>().color = colors[currentColor];
            }
            currentColor++;
        }

        if(tempList.Count % int.Parse(group) != 0)
        {
            int extraPlayer = playerInGroup * int.Parse(group);

            int extraColor = 0;

            for(int i = extraPlayer; i < tempList.Count; i++)
            {
                GameObject newObj = tempList[i].circles;

                newObj.GetComponent<SpriteRenderer>().color = colors[extraColor];

                extraColor++;
            }
        }
    }

    private List<InputLocation> RandomList(List<InputLocation> list)
    {
        List<InputLocation> shuffledList = new List<InputLocation>(list);

        for(int i = 0 ; i < shuffledList.Count ; i++)
        {
            int tempID = shuffledList[i].touchID;
            GameObject obj = shuffledList[i].circles;

            int randomize = Random.Range(i, shuffledList.Count);

            shuffledList[i].touchID = shuffledList[randomize].touchID;
            shuffledList[i].circles = shuffledList[randomize].circles;

            shuffledList[randomize].touchID = tempID;
            shuffledList[randomize].circles = obj;
        }

        return shuffledList;
    }
}
