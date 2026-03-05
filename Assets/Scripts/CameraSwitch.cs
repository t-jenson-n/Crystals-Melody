using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraSwitch : MonoBehaviour
{

    public string[] TriggerKey = { "CamSwitch1", "CamSwitch2" };
    public bool[] boolTrigger = { true, true };
    //First method Camera Storage: Used
    public Camera[] CamVal = { };
    public Camera[] CamVal2 = { };
    //Second method Camera Storage: Unused
    public Camera[] CamValTrue = {};
    public Camera[] CamValFalse = {};
    public Camera currentCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player"); //Check if collision is player
        string triggerName = this.name; //Store Name of the current trigger
        for (int i = 0; i < TriggerKey.Length; i++) //loop through the keys to find a trigger name match
        {
            if (TriggerKey[i] == triggerName) //if match found
            {
                CamVal[i].tag = "camOFF";
                CamVal[i].enabled = false;
                CamVal2[i].enabled = true;
                //stores the Y axis of the camera
                currentCamera = CamVal2[i];
                currentCamera.tag = "MainCamera"; //set the current camera to be looked for by the character controller
                break;
                /*
                if (boolTrigger[i]) 
                {
                    CamValFalse[i].enabled = false;
                    CamValTrue[i].enabled = true;
                    boolTrigger[i] = false;
                }
                else
                {
                    CamValTrue[i].enabled = false;
                    CamValFalse[i].enabled = true;
                    boolTrigger[i] = true;
                }
                */
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
