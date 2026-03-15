using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public static class GlobalVariables
{
    public struct index2D
    {
        public static int indexY;
        public static int indexX;

        public index2D(int indxY, int indxX)
        {
            indexY = indxY;
            indexX = indxX;
        }
    }

    public static GameObject[,] bars = new GameObject[4, 6];
    public static bool[,] contact = new bool[4,6];
    public static GameObject[] parentbars;
    
    public static void get_contacts()
        

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
   
    public static index2D get_index(GameObject[,] arr, GameObject item)
    {
        index2D indx = new index2D(-1,-1);
        for (int i=0;i<4; i++)
        {
            for(int j = 0; j < 6; j++)
            {
                if (item.CompareTag(arr[i, j].tag))
                {
                   indx = new index2D(i, j);
                }
            }
        }
        return indx;

    }
}
*/
