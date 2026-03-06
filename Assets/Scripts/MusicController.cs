using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;


public class MusicController : MonoBehaviour
{
    public bool melodyCorrect = false;

    public bool[] check;

    void Start()
    {
        check = new bool[4] { false, false, false, false };
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

    void checkCorrect(int indx)
    {
        check[indx] = true;
       /* for (int i = 0; i < 4; i++)
        {
            Debug.Log(i + ": " + check[i]);
        }*/
    }
    void checkFalse(int indx)
    {
        check[indx] = false;
    }
}