using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScreenOrientation : MonoBehaviour
{
    private bool isPortrait = true; // Start in portrait mode
    /*private static UnityEngine.ScreenOrientation Portrait;
    private static UnityEngine.ScreenOrientation LandscapeRight;*/

    void Start()
    {
        // Set initial orientation to portrait
        //SetPortraitOrientation();
    }

    // This method will be called when the button is pressed
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
