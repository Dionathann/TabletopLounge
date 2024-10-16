using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InputLocation
{
    public int touchID;
    public GameObject circles;

    public InputLocation(int TouchID, GameObject Circles)
    {
        touchID = TouchID;
        circles = Circles;
    }
}
