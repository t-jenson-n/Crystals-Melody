using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
//using UnityEditor;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Unity.VisualScripting.Member;


public class MusicController : MonoBehaviour
{

    public string nextScene;
    public AudioSource playingnow;
    int playback = 0;

    public GameObject[] barindx;

    public bool[] check;
    //public TextMeshProUGUI musicWin_Text;

    //public List<GameObject> collectedCrystals;
    public List<GameObject> rocks;

    public bool melodyCorrect = false;

    void Start()
    {
        check = new bool[5] { true, true, true, true, true };
        set_check();

        //musicWin_Text.GetComponent<StatusChange>().Hide();

        //collectedCrystals = GetComponent<GameController>().collectedCrystals;
    }

    void Update()
    {
        melodyCorrect = wincheck();
        if (melodyCorrect == true)
        {
            
            playback++;
            if (playback == 1)
            {
                //musicWin_Text.GetComponent<StatusChange>().Show();
                StartCoroutine(playsong());

            }
            else
            {
                playback = 2;
            }
        }

    }
    void set_check()
    {
        for (int i = 0; i < barindx.Length; i++)
        {
            check[i] = false;
        }
    }
    bool wincheck()
    {
        bool win = true;
        for (int i = 0; i < check.Length; i++)
        {
            if (check[i] == false)
            {
                win = false;
            }
        }
        return win;
    }

    void checkCorrect(GameObject obj)
    {
        //Debug.Log(obj.name);
        int indx = Array.IndexOf(barindx, obj);
        //Debug.Log("index: "+indx);
        if(indx != -1)
        {
            check[indx] = true;
        }
       /* for (int i = 0; i < 4; i++)
        {
            Debug.Log(i + ": " + check[i]);
        }*/
}
void checkFalse(GameObject obj)
    {
        int indx = Array.IndexOf(barindx, obj);
        if (indx != -1)
        {
            check[indx] = false;
        }
    }


    private IEnumerator playsong()
    {

        //yield return null;
        //runes.GetComponent<Runes>().PlayAnimation();

        //for (int i = 0; i < ; i++)

        //{
        //    yield return new WaitForSeconds(runeSprites.Length);

        //    while (playingnow.isPlaying)
        //    {
        //        yield return null;
        //    }
        //}
        //this.gameObject.GetComponent<SceneChanger>().getNext(next.name);

        yield return StartCoroutine(GetComponent<RuneMelody>().PlayAnimation());

        SceneManager.LoadScene(GetComponent<SceneChanger>().nextScene);
    }
}