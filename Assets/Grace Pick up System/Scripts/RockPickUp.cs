

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;




public class RockPickUp : MonoBehaviour
{
    private GameController gameController;
    //for the pop up to click E
    public GameObject pickupUI;

    private bool playerInRange = false;

    public AudioSource note;
    public AudioSource twinkle;


    //GameObject.tag = "Rock";

    //On game start, turn off attached text
    void Start()
    {
        gameController = GetComponentInParent<GameController>();

        pickupUI.SetActive(false);
    }

    // void on trigger enter
    private void OnTriggerEnter(Collider collision)
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

        twinkle.Play();

        if (collision.CompareTag("Player"))
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

    private void OnTriggerStay(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {

            if (!pickupUI.activeSelf)
            {
                pickupUI.SetActive(true);

            }

            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {

        if (collision.CompareTag("Player"))
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
            note.Play();

            StartCoroutine(DelayDisable());
        }


    }

    private IEnumerator DelayDisable()
    {
        yield return new WaitForSeconds(0.9f);
        gameObject.SetActive(false);

        Debug.Log("******** Rock is picked up");
        pickupUI.SetActive(false);


        gameController.rocksCollected += 1;
        gameController.collectedCrystals.Add(this.gameObject);


        Debug.Log("-----------   Added a rock : " + gameController.rocksCollected);
    }



}











