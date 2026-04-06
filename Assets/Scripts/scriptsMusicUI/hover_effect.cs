using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class hover_effect : MonoBehaviour
{  
    private AudioSource[] sounds;
    public GameObject note;
    private Renderer barRenderer;
   // public GameObject[] barindx;


    // Start is called before the first frame update
    void Start()
    {   note = GameObject.Find("Notes");
        sounds = GetComponentsInParent<AudioSource>();
        barRenderer = GetComponent<Renderer>();

    }
    void OnTriggerEnter(Collider collision)
    {
        //EditorUtility.DisplayDialog("working?", "working", "ok", "cancel");
        if (collision.transform.parent.gameObject == note)
        {
            barRenderer.material.color = collision.GetComponent<Renderer>().material.color;
           
        }
    }
    void OnTriggerStay(Collider collision)
    {
        if (collision.transform.parent.gameObject == note)
        {
            //gameObject.SendMessageUpwards("enter_contact", this.gameObject);
            barRenderer.material.color = collision.GetComponent<Renderer>().material.color;
            if (collision.CompareTag(this.gameObject.tag))
            {
                gameObject.SendMessageUpwards("checkCorrect", this.gameObject);
               
                
            }
         
        }
   
    }
    private void OnTriggerExit(Collider collision)
    {
   
        barRenderer.material.color = Color.black;
       // gameObject.SendMessageUpwards("exit_contact", this.gameObject);
        if (collision.CompareTag(this.gameObject.tag))
         {
            gameObject.SendMessageUpwards("checkFalse", this.gameObject);
         }
    }
}
