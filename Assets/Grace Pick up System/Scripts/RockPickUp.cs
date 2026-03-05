

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;




public class RockPickUp : MonoBehaviour
{

    //for the pop up to click E
    public GameObject pickupUI;

    private bool playerInRange = false;

    //GameObject.tag = "Rock";

    //On game start, turn off attached text
    void Start()
    {
        pickupUI.SetActive(false);
    }

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
            Debug.Log("******* Rock can be picked up!");

            playerInRange = true;
            //show UI
            pickupUI.SetActive(true);
            



        }




        //store rock
        //rock = collision.gameObject;
        //canPickup = true;

        //popupUI.SetActive(true);

    }


    private void OnTriggerExit(Collider collition)
    {

        if (collition.tag == "Player")
        {
            playerInRange = false;
            pickupUI.SetActive(false);
            Debug.Log("you are out of range ========");


            //pickupUI.GetComponent<Renderer>().enable = false;
        }





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


        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("******** Rock is picked up");
            pickupUI.SetActive(false);
            //just dissable rock for now
            gameObject.SetActive(false);





            /* was tyring to 
            if ((KeyCode.E)) == true) 
            {

                if (gemCollect == 1)
                {
                    gemHas[0] = true;
                }
                else if (gemCollect == 2)
                {
                    gemHas[1] = true;
                }
                else if (gemCollect == 3)
                {
                    gemHas[2] = true;
                }
                else if (gemCollect == 3)
                {
                    gemHas[3] = true;
                }
                else
                {
                    Break;
                }
            }
            */




        }


    }


}











