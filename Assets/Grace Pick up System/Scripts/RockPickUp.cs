

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class RockPickUp : MonoBehaviour
{

    //GameObject.tag = "Rock";


    // void on trigger enter
    private void OnTriggerEnter(Collider collition)
    {
        //public GameObject popupUI;
        //private bool canPickup = false;

        //check tag = rocks
        
        /*
        if (collition.gameObject.CompareTag("Rock"))
        {
            Debug.Log("Rock can be picked up!");
        }

        */


        if (collition.tag == "Player")
        {
            Debug.Log("Rock can be picked up!");




        }




        //store rock
        //rock = collision.gameObject;
        //canPickup = true;

        //popupUI.SetActive(true);

    }


    private void OnTriggerExit(Collider collition)
    {
        /*

        //void on trigger exit  *******
        if(collition.gameObject.CompareTag("Rock") /= True)
        {
            //hide popup (E)  *********
        }

        */
    }


    /*

    private void OnTriggerExit(Collider collision)
    {
        /f (collision.gameObject.CompareTag("Rock"))
        {
            canPickup = false;
            pop up hidden
            popupUI.SetActive(false);
        }
    }

    */



    //  unhide popup (E) ******
    private void Update()
    {
        //set to true when 
        //myButton.gameObject.SetActive(false);

    }
    //  make ui popup




    //input (E) 




}











