using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class dragdrop : MonoBehaviour
{
    public Vector3 startpos;
    //private Rigidbody rb;

    private Vector3 newpos;
    private GameObject hit_obj;
    private bool contact;
    private bool inBackpack = true;

    private void Start()
    {
        startpos = transform.position;
    }
    private void OnMouseEnter()
    {
        transform.localScale = new Vector3(transform.localScale.x+10f, transform.localScale.y, transform.localScale.z + 10f);

        //plays sound on hover but only in backpack
        if (inBackpack)
        {
            AudioSource sound = this.gameObject.GetComponent<AudioSource>();
            sound.Play();
        }
    }
    private void OnMouseExit()
    {
        transform.localScale = new Vector3(transform.localScale.x - 10f, transform.localScale.y, transform.localScale.z - 10f);
        
    }

    //plays sound on click
    //private void OnMouseDown()
    //{
    //    AudioSource sound = this.gameObject.GetComponent<AudioSource>();
    //    sound.Play();
    //}

    void OnMouseDrag()//drag object
    {
        Vector3 position = GetPos();
        transform.position = position;
        //rb.MovePosition(position);
    }

    private void OnTriggerEnter(Collider bar)//detect contact enter
    {
        if (bar.transform.parent.CompareTag("songbar") == true)
        {
            hit_obj = bar.gameObject;
            contact = true;
        }
    }

    private void OnTriggerExit(Collider bar)//detect contact exit
    {
        contact = false;
    }

    private void OnMouseUp()//return to starting position or new position
    {
        if (contact == true)
        {
            newpos = hit_obj.transform.position;
            inBackpack = false;
            AudioSource[] sounds = hit_obj.GetComponentsInParent<AudioSource>();
            if (hit_obj.CompareTag(this.gameObject.tag))
            {
                sounds[1].Play();
            }
            else
            {
                sounds[0].Play();
            }
        }
        else
        {
            newpos = startpos;
        }
        gameObject.transform.position = newpos;
    }

    private Vector3 GetPos()//get new position 
    {
        Vector3 mouse_adj = Input.mousePosition;
        mouse_adj.z = 880f;
        return Camera.main.ScreenToWorldPoint(mouse_adj);
    }
}