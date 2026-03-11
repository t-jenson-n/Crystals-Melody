using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class AudioPlay : MonoBehaviour
{

    public GameObject[] parentbars; //parent
    public Button playButton;
    private GameObject[,] bars = new GameObject[4, 6];
    public bool[,] contact;
    // Start is called before the first frame update
    void Start()
    {

        contact = new bool[4, 6];
        playButton.onClick.AddListener(play);

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
/*
        for (int i = 0; i < 4; i++)
        {
            Debug.Log("0:" + bars[i, 0].name + ", 1:" + bars[i, 1].name + ", 2:" + bars[i, 2].name + ", 3" + bars[i, 3].name + ", 4" + bars[i, 4].name + ", 5" + bars[i, 5].name);
        }*/
    }
    private void Update()
    {
        for (int i = 0; i < 4; i++) {
            if (this.gameObject.transform.GetChild(i).gameObject.GetComponent<Collider>().isTrigger == true)
            {

            }
        }
    }

    bool compare()
    {
        bool compare=false;
        return compare;
    }
    void play()
    {
        /*
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (bars[j, i].GetComponent<Collider>().isTrigger == true)
                {
                   
                }
            }
        }*/
    }

  /*  void ContactEnter(GameObject item)
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                if (item.CompareTag(bars[i, j].tag))
                {
                   
                }
            }
        }
    }*/
}