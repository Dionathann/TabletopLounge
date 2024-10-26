using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AltruisticGameManager : MonoBehaviour
{
    public string mainMenuSceneName;
    public void BacktoMainMenu()
    {
        if (mainMenuSceneName != null)
        {
            SceneManager.LoadScene(mainMenuSceneName);
        }
    }
}
