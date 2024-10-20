using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputMechanism : MonoBehaviour
{
    [SerializeField] Camera mainCamera;

    [SerializeField] TMP_Dropdown modeDropdown;
    [SerializeField] TMP_Dropdown amount;

    public GameObject circle;

    [SerializeField] InputSelector inputSelector;

    public List<InputLocation> inputLocationList = new List<InputLocation>();

    public float interval;


    ////////////////////////////////////////////////////////////////////////
    private float inputTimerInterval = 0;

    private int inputTimerInt;

    private bool timerRunning = false;

    private bool isPassedInterval = false;
    // Update is called once per frame
    
    void Update()
    {
        int i = 0;

        while(i < Input.touchCount)
        {
            Touch T = Input.GetTouch(i);

            if (T.phase == TouchPhase.Began)
            {
                timerRunning = true;

                inputTimerInterval = 0;

                inputTimerInt = 0;

                inputLocationList.Add(new InputLocation(T.fingerId, CreateCircle(T)));

            }
            else if (T.phase == TouchPhase.Moved)
            {
                InputLocation thisInput = inputLocationList.Find(inputLocation => inputLocation.touchID == T.fingerId);

                thisInput.circles.transform.position = GetTouchPosition(T.position);
            }
            else if(T.phase == TouchPhase.Ended)
            {
                InputLocation thisInput = inputLocationList.Find(inputLocation => inputLocation.touchID == T.fingerId);
                
                Destroy(thisInput.circles);

                inputLocationList.RemoveAt(inputLocationList.IndexOf(thisInput));

                inputTimerInterval = 0;

                inputTimerInt = 0;
            }
            i++;
        }

        if(Input.touchCount == 0)
        {
            ClearCircle();
            ResetEverything();
        }

        if (timerRunning)
        {
            IntervalCounter();
        }


        if(inputTimerInt == interval && isPassedInterval == false)
        {
            isPassedInterval = true;
            StartChooseInput();
        }

        
    }

    private void IntervalCounter()
    {
        inputTimerInterval += Time.deltaTime;

        if(inputTimerInterval >= 1f)
        {
            inputTimerInterval = 0;

            inputTimerInt++;
        }
    }

    private void ResetEverything()
    {
        inputTimerInterval = 0;

        inputTimerInt = 0;

        timerRunning = false;

        isPassedInterval = false;
    }

    public void StartChooseInput()
    {
        if(GetGameMode() == 0)
        {
            inputSelector.SelectFinger(inputLocationList, amount.options[amount.value].text);

            Debug.Log("Game Mode " + modeDropdown.options[GetGameMode()].text);
        }
        if(GetGameMode() == 1)
        {
            inputSelector.DivideGroup(inputLocationList, amount.options[amount.value].text);
            Debug.Log("Game Mode " + modeDropdown.options[GetGameMode()].text);
        }
    }

    private int GetGameMode()
    {
        return modeDropdown.value;
    }

    private void ClearCircle()
    {
        foreach (var input in inputLocationList)
        {
            Destroy(input.circles);
        }
        inputLocationList.Clear();
    }

    GameObject CreateCircle(Touch touch)
    {
        GameObject newInputIndicator = Instantiate(circle) as GameObject;

        newInputIndicator.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value);

        newInputIndicator.name = "Touch " + touch.fingerId;

        newInputIndicator.transform.position = GetTouchPosition(touch.position);

        return newInputIndicator;
    }

    Vector2 GetTouchPosition(Vector2 location)
    {
        var pos = mainCamera.ScreenToWorldPoint(new Vector3(location.x,location.y, transform.position.z));

        return pos;
    }
}
