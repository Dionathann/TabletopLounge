using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScreenOrientation : MonoBehaviour
{
    private bool isPortrait = true;

    [ContextMenu("Orientation Toggle")]
    public void ToggleOrientation()
    {
        if (isPortrait)
        {
            SetLandscapeOrientation();
        }
        else
        {
            SetPortraitOrientation();
        }

        // Toggle the state
        isPortrait = !isPortrait;
    }

    void SetPortraitOrientation()
    {
        Screen.orientation = UnityEngine.ScreenOrientation.Portrait;
    }

    void SetLandscapeOrientation()
    {
        Screen.orientation = UnityEngine.ScreenOrientation.LandscapeLeft;
    }
}
