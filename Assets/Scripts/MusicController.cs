using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Unity.VisualScripting.Member;


public class MusicController : MonoBehaviour
{
    //public bool[,] contact = new bool[4, 6];
    //public GameObject[] parentbars;
    // public GameObject[,] bars = new GameObject[4, 6];
    /*
       public struct index2D
    {
        public int indexY;
        public int indexX;

        public index2D(int indxX, int indxY)
        {
            indexY = indxY;
            indexX = indxX;
        }
    }*/

    public AudioSource playingnow;
    int playback = 0;

    public GameObject[] barindx;
    public bool[] check;
 
    public bool melodyCorrect = false;
    void Start()
    {
        check = new bool[4] { false, false, false, false };
        //barindx = new GameObject[4] { GameObject.Find("CBar (0)"), GameObject.Find("CBar (1)"), GameObject.Find("GBar (2)"), GameObject.Find("GBar (3)") };
        //parentbars = new GameObject[4] { GameObject.Find("GBar"), GameObject.Find("Fbar"), GameObject.Find("CBar"), GameObject.Find("ABar") };
        //get_contacts();
        //get_song();
        //print_bars();
    }

    void Update()
    {
        melodyCorrect = wincheck();
        if (melodyCorrect == true)
        {
            
            playback++;
            if (playback == 1)
            {
                StartCoroutine(playsong());
                
            }
            else
            {
                playback = 2;
            }
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


    IEnumerator playsong()
    {

        yield return null;
        
        for (int i = 0; i < 4; i++)
        {
            AudioSource[] source = barindx[i].transform.GetComponentsInParent<AudioSource>();
            playingnow.clip = source[1].clip;
            playingnow.Play();
            //Debug.Log(playingnow.clip.name);

            
            while (playingnow.isPlaying)
            {
                yield return null; 
           }
        }
        this.gameObject.GetComponent<SceneChanger>().LoadGameEnd();

    }




    /*
   index2D get_index(GameObject[,] arr, GameObject item)
    {
        index2D indx = new index2D(-1, -1);
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                if (item.name == arr[i, j].name)
                {
                    indx = new index2D(i, j);
                }
            }
        }
        return indx;

    } 


    void get_contacts()// initialize contact/bars/audioclips
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                //bars[(i*6)+j] = parentbars[i].transform.GetChild(j).gameObject;
                //int val = (i * 6) + j;

                bars[i, j] = parentbars[i].transform.GetChild(j).gameObject;
                // Debug.Log("val"+val+": "+parentbars[i].transform.GetChild(j).gameObject.name);
                contact[i, j] = false;
            }
        }
    }
    void print_bars()
    {
        for (int i = 0; i < 4; i++)
        {
            Debug.Log("0:" + bars[i, 0].name + ", 1:" + bars[i, 1].name + ", 2:" + bars[i, 2].name + ", 3:" + bars[i, 3].name + ", 4:" + bars[i, 4].name + ", 5:" + bars[i, 5].name);
        }
    }

    void print_ContactTable()
    {
        for (int i = 0; i < 4; i++)
        {
            Debug.Log(bars[i, 0].name+": " + contact[i,0] +"--"+bars[i, 1].name + ": " + contact[i, 1] + "--" + bars[i, 2].name + ": " + contact[i, 2] + "--" + bars[i, 3].name + ": " + contact[i, 3] + "--" + bars[i, 4].name + ": " + contact[i, 4] + "--" + bars[i, 5].name+ ": " + contact[i, 5] + "--");
        }
    }

    void enter_contact(GameObject obj)
    {
        index2D indx = get_index(bars, obj);
        contact[indx.indexX, indx.indexY] = true;
       // print_ContactTable();
    }

    void exit_contact(GameObject obj)
    {
        index2D indx = get_index(bars, obj);
        contact[indx.indexX, indx.indexY] = false;
        //print_ContactTable();
    }
    */
}