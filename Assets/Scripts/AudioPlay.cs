using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
//using UnityEngine.UIElements;

public class AudioPlay : MonoBehaviour
{
    public GameObject[] parentbars; //parent
    public Button playButton;
    private GameObject[] bars = new GameObject[24]; //child
    private GameObject[,] bars2 = new GameObject[4, 6];
    // Start is called before the first frame update
    void Start()
    {
        //playButton.onClick.AddListener(play);

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                //bars[(i*6)+j] = parentbars[i].transform.GetChild(j).gameObject;
                int val = (i * 6) + j;
                bars[val] = parentbars[i].transform.GetChild(j).gameObject;
                bars2[i, j] = parentbars[i].transform.GetChild(j).gameObject;
                // Debug.Log("val"+val+": "+parentbars[i].transform.GetChild(j).gameObject.name);
            }
        }

        for (int i = 0; i < 4; i++)
        {
            Debug.Log("0:" + bars2[i, 0].name + ", 1:" + bars2[i, 1].name + ", 2:" + bars2[i, 2].name + ", 3" + bars2[i, 3].name + ", 4" + bars2[i, 4].name + ", 5" + bars2[i, 5].name);
        }
    }

   /*
    void play()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (bars2[j, i].GetComponent<Collider>().isTrigger == true)
                {
                    Debug.Log(bars2[j, i].GetComponent<Collider>().gameObject.name);
                    
                    // Collider[] hitOBJ = Physics.OverlapBox(bars2[j, i].transform.position, Quaternion.identity)
                }
            }
        }
    }*/
}