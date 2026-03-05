using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraSwitch : MonoBehaviour
{
    /*
    public string[] TriggerKey = { "CamSwitch1", "CamSwitch2" };
    public bool[] boolTrigger = { true, true };
    //First method Camera Storage: Used
    public Camera[] CamVal = { };
    public Camera[] CamVal2 = { };
    //Second method Camera Storage: Unused
    public Camera[] CamValTrue = {};
    public Camera[] CamValFalse = {};
    public Camera currentCamera;
    */
    //third method Camera Storage: Best
    public Camera CamValOff;
    public Camera CamValOn;
    public GameObject imageHolder;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Renderer>().enabled = false;
        imageHolder.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) //when something collides with the collider,
    {
        //Check if collision is player
        if (other.tag == "Player")
        {
            CamValOff.tag = "camOFF"; //make sure the Camera thats turned off is considered off
            CamValOff.enabled = false; //disable camera
            CamValOn.enabled = true; //enable camera
            CamValOn.tag = "MainCamera"; //set this camera to be the main camera, 
        }
        //Secret stuff hehehehehe
        if (this.name == "SpecialSwitch")
        {
            imageHolder.SetActive(true);
        }
        if (this.name == "SpecialSwitch2")
        {
            imageHolder.SetActive(false);
        }
    }

    /*
    //This is part of the old method, ignore this existence
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
            }
        }
    }
    */

    // Update is called once per frame
    void Update()
    {
        
    }
}
