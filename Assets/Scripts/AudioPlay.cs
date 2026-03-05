using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    public GameObject[] parentbars; //parent
    private GameObject[] bars = new GameObject[24]; //child
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            for(int j=0; j < 6; j++)
            {
                //bars[(i*6)+j] = parentbars[i].transform.GetChild(j).gameObject;
                int val = (i * 6) + j;
                bars[val] = parentbars[i].transform.GetChild(j).gameObject;
                //Debug.Log("val"+val+": "+parentbars[i].transform.GetChild(j).gameObject.name);
            }
        }
        
       /* for(int i = 0;i < bars.Length; i++)
        {
            Debug.Log(i+": "+bars[i].name+", ");
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
