using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightLimit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Light>().enabled = false;
    }

    private void OnTriggerEnter(Collider other) //when something collides with the collider,
    {
        //Check if collision is player
        if (other.tag == "Player")
        {
            //Turn on light
            gameObject.GetComponent<Light>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other) //when something leaves collider
    {
        //Check if collision is player
        if (other.tag == "Player")
        {
            //Turn on camera
            gameObject.GetComponent<Light>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
