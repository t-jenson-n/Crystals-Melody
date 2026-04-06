using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class SceneChanger : MonoBehaviour
{
    public string nextScene;

    public void LoadScene(string theScene)
    {
        SceneManager.LoadScene(theScene);
    }

    public void LoadOpener()
    {
        SceneManager.LoadScene("Opener");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadIntro()
    {
        SceneManager.LoadScene("Intro");
    }

    public void LoadCave1()
    {
        SceneManager.LoadScene("Cave1");
    }

    public void LoadCave2()
    {
        SceneManager.LoadScene("Cave2");
    }

    public void LoadMusicLevel1()
    {
        SceneManager.LoadScene("MusicLevel1");
    }

    public void LoadMusicLevel2()
    {
        SceneManager.LoadScene("MusicLevel2");
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

