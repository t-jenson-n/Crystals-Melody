using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SceneChanger : MonoBehaviour
{

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }



    public void LoadCaveLevel1()
    {
        SceneManager.LoadScene("CaveLevel1");
    }

    public void LoadMusicLevel1()
    {
        SceneManager.LoadScene("MusicLevel1");
    }


    public void LoadGameEnd()
    {
        SceneManager.LoadScene("GameEnd");

    }

    public void Quit()
    {
        Application.Quit();

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#endif
    }
}

