using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BoardGameSelection : MonoBehaviour
{
    [SerializeField] List<BoardGameData> boardgameData = new List<BoardGameData>();

    [SerializeField] GameObject boardgameDisplayer;
    [SerializeField] Transform boardgameDisplayerParent;

    private List<GameObject> boardgameDisplayerList = new List<GameObject>();

    public AudioSource sfxSound;

    public AudioClip sfxClip;
    public void DisplayBoardGame()
    {
        foreach (GameObject obj in boardgameDisplayerList)
        {
            Destroy(obj);
        }

        boardgameDisplayerList.Clear();

        for (int i = 0; i < boardgameData.Count; i++)
        {
            GameObject newBoardgame = Instantiate(boardgameDisplayer, boardgameDisplayerParent);

            newBoardgame.GetComponent<BoardGameDataDisplayer>().Display(boardgameData[i]);

            Button button = newBoardgame.GetComponent<Button>();

            if(button != null)
            {
                button.onClick.RemoveAllListeners();

                string scene = boardgameData[i].nameScene;

                button.onClick.AddListener(() => LoadScene(scene));

                button.onClick.AddListener(() => PlaySound(sfxClip));
            }
            boardgameDisplayerList.Add(newBoardgame);
        }
    }

    public void PlaySound(AudioClip sound)
    {
        sfxSound.PlayOneShot(sound);
    }

    public void LoadScene(string namescene)
    {
        SceneManager.LoadScene(namescene);
    }

}
