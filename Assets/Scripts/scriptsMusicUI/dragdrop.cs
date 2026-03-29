using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.RestService;
using UnityEngine;
using UnityEngine.UIElements;


public class dragdrop : MonoBehaviour
{
    public Vector3 startpos;
    //private Rigidbody rb;

    private Vector3 newpos;
    private GameObject hit_obj;
    private bool contact;
    private bool played = false;
    private bool release = false;
    private bool hold = false;
    private void Start()
    {
       
        startpos = transform.position;
    }
  
    private void OnMouseEnter()
    {
        transform.localScale = new Vector3(transform.localScale.x+10f, transform.localScale.y, transform.localScale.z + 10f);
        //Debug.Log("over");

    }
    private void OnMouseExit()
    {
        played = false;
        transform.localScale = new Vector3(transform.localScale.x - 10f, transform.localScale.y, transform.localScale.z - 10f);
        
    }
    private void OnMouseOver()
    {
        if (played == false)
        {
            AudioSource sound = this.gameObject.GetComponent<AudioSource>();
            sound.Play();
            Debug.Log("sound play");
            played = true;
        }
    }
    private void OnMouseDown()
    {
        hold = true;
        release = false;
    }
    private void OnMouseUpAsButton()
    {
        release = true;
        hold = false;
    }
    void OnMouseDrag()//drag object
    {
        played = true;
        Vector3 position = GetPos();
        transform.position = position;
        //rb.MovePosition(position);
    }

    private void OnTriggerEnter(Collider bar)//detect contact enter
    {
        // Debug.Log("contact");
        if (bar.transform.parent.CompareTag("songbar") == true)
        {
            hit_obj = bar.gameObject;
            contact = true;
          //  Debug.Log("contact with:" + bar.gameObject.name);
        }
       
    }

    private void OnTriggerExit(Collider bar)//detect contact exit
    {
        contact = false;
       // Debug.Log("exited");
    }

    private void OnMouseUp()//return to starting position or new position
    {
        if (contact == true)
        {
            newpos = hit_obj.transform.position;
            AudioSource[] sounds = hit_obj.GetComponentsInParent<AudioSource>();
                sounds[1].Play();
            

        }
        else
        {
            newpos = startpos;
        }
        gameObject.transform.position = newpos;
        //rb.MovePosition(newpos);
    }

    private Vector3 GetPos()//get new position 
    {
        Vector3 mouse_adj = Input.mousePosition;
        mouse_adj.z = 880f;
        return Camera.main.ScreenToWorldPoint(mouse_adj);
    }
}