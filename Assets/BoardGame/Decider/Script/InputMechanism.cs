using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMechanism : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    public GameObject circle;
    public List<InputLocation> inputLocationList = new List<InputLocation>();

    // Update is called once per frame
    void Update()
    {
        int i = 0;

        while(i < Input.touchCount)
        {
            Touch T = Input.GetTouch(i);

            if (T.phase == TouchPhase.Began)
            {
                inputLocationList.Add(new InputLocation(T.fingerId, CreateCircle(T)));
                Debug.Log("Touched");

            }
            else if (T.phase == TouchPhase.Moved)
            {
                //Debug.Log("Moved");

                InputLocation thisInput = inputLocationList.Find(inputLocation => inputLocation.touchID == T.fingerId);

                thisInput.circles.transform.position = GetTouchPosition(T.position);
            }
            else if(T.phase == TouchPhase.Ended)
            {
                InputLocation thisInput = inputLocationList.Find(inputLocation => inputLocation.touchID == T.fingerId);
                
                Destroy(thisInput.circles);

                inputLocationList.RemoveAt(inputLocationList.IndexOf(thisInput));
                //Debug.Log("Ended");
            }
            i++;
        }

    }

    GameObject CreateCircle(Touch t)
    {
        GameObject newInputIndicator = Instantiate(circle) as GameObject;

        newInputIndicator.name = "Touch " + t.fingerId;

        newInputIndicator.transform.position = GetTouchPosition(t.position);

        return newInputIndicator;
    }

    Vector2 GetTouchPosition(Vector2 location)
    {
        var pos = mainCamera.ScreenToWorldPoint(new Vector3(location.x,location.y, transform.position.z));

        return pos;
    }
}
