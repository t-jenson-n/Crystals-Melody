using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class MusicController : MonoBehaviour
{
    public bool melodyCorrect = false;

    public GameObject[] barindx;
    public bool[] check;

    void Start()
    {
        check = new bool[4] { false, false, false, false };
        barindx = new GameObject[4] { GameObject.Find("CBar (0)"), GameObject.Find("CBar (1)"), GameObject.Find("GBar (2)"), GameObject.Find("GBar (3)") };
    }

    void Update()
    {
        melodyCorrect = wincheck();
        if (melodyCorrect == true)
        {
            gameObject.GetComponent<SceneChanger>().LoadGameEnd();
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
    void playsong()
    {
        for (int i = 0; i < check.Length; i++) {
            if (check[i] == true)
            {
                barindx[i].GetComponent<AudioSource>().Play();
            }
        }
    }

    void checkCorrect(GameObject obj)
    {
        int indx = Array.IndexOf(barindx, obj);
        check[indx] = true;
       /* for (int i = 0; i < 4; i++)
        {
            Debug.Log(i + ": " + check[i]);
        }*/
    }
    void checkFalse(GameObject obj)
    {
        int indx = Array.IndexOf(barindx, obj);
        check[indx] = false;
    }
}