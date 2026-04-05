

using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class RockPickUp : MonoBehaviour
{
    private GameController gameController;
    
    //for the pop up to click E
    public GameObject pickupUI;


    //changing text in ui 
    public TMP_Text pickupText;



    private bool playerInRange = false;


    // counter for num times E has been clicked 
    private int ePressCount = 0;
    //num of times E needs to be clicked before pressing Q
    public int requiredPress = 4;

    //for inspector rocks
    public GameObject[] outerRocks;




    public AudioSource note;
    public AudioSource twinkle;

    // ******* ADD ROCK MINEING SOUND
    




    //GameObject.tag = "Rock";

    //On game start, turn off attached text
    void Start()
    {
        gameController = GetComponentInParent<GameController>();

        //hides ui at beggining
        pickupUI.SetActive(false);

        //first text for UI
        UpdatePickupUI();
    }



    // void on trigger enter
    private void OnTriggerEnter(Collider collision)
    {
        

        twinkle.Play();

        if (collision.CompareTag("Player"))
        {
            Debug.Log("******* Rock can be picked up!");

            playerInRange = true;
            //show UI
            pickupUI.SetActive(true);


            //updating the text on enter
            UpdatePickupUI();


        }



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

            //update text again
            UpdatePickupUI();

        }
    }




    private void OnTriggerExit(Collider collision)
    {

        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            //hide ui out of range
            pickupUI.SetActive(false);

            Debug.Log("you are out of range ========");

            //reset counter pickup to 0 for other rocks
            //ePressCount = 0;


            //pickupUI.GetComponent<Renderer>().enable = false;
        }

    }




    private void Update()
    {

        //so Q isnt getting check same frame as E
        if (!playerInRange)
        {
            return;
        }



        //press E 6 --> (now 4) times and add to counter
        if (Input.GetKeyDown(KeyCode.E) && ePressCount < requiredPress)
        {

            ePressCount++;

            Debug.Log("777777777 you pressed EEEEE " + ePressCount + "times");


            //if (note != null)
            //{
                //Change one you have the MINEING SOUND   ************
                //note.Play();
            //}
            
            UpdatePickupUI();

            //adding the droping rocks here
            FallOutRocks();

        }


        // E clicked 4 times now click Q to pickup 
        if (ePressCount >= requiredPress && Input.GetKeyDown(KeyCode.Q))
            {

                Debug.Log("111111111111111111 you pressed Q");
                StartCoroutine(DelayDisable());

            }


    }

   


    private void UpdatePickupUI()
    {
        

        if (pickupText == null)
        {
            Debug.LogError("pickupText is null on " + gameObject.name);

            return; 
        }

        if(ePressCount < requiredPress)
        {
            pickupText.text = " PRESS [E] " + ePressCount + " / " + requiredPress + " TO MINE";
        }

        else
        {
            pickupText.text = " PRESS [Q] TO PICK UP";
        }  

    }



    private IEnumerator DelayDisable()
    {
        yield return new WaitForSeconds(0.3f);
        gameObject.SetActive(false);

        Debug.Log("******** Rock is picked up");
        pickupUI.SetActive(false);


        gameController.rocksCollected += 1;
        gameController.collectedCrystals.Add(this.gameObject);


        Debug.Log("-----------   Added a rock : " + gameController.rocksCollected);
    }



    //making the rocks around the crystal to drop as youre clicking E (mining) 
    private void FallOutRocks()
    {
        int rockInd = ePressCount - 1;

        if( outerRocks == null ||  rockInd < 0 || rockInd >= outerRocks.Length)
        {
            return;

        }


        GameObject rockDrop = outerRocks[rockInd];

        if( rockDrop == null)
        {
            return ;
        }


        //try dopping??? (gravity off - Kinimatics on for rocks) 
        Debug.Log("Try dropping PLEASSSEEEEEEEEE " + rockDrop.name);


        //Physics to get the rocks to drop around the crystal
        Rigidbody rb = rockDrop.GetComponent<Rigidbody>();

        if ( rb != null)
        {
            rb.isKinematic = false;
            rb.useGravity = true;

            //making it fall cooler 
            rb.AddForce(Vector3.down * 2f, ForceMode.Impulse);


        }

        else
        {
            Debug.LogWarning("no rigidbody --> " + rockDrop.name);
        }

    }




}




