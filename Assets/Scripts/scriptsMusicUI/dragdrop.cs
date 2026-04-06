using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.UIElements;


public class dragdrop : MonoBehaviour
{
    public Vector3 startpos;
   // private Rigidbody rb;
    private Vector3 newpos;
    //public int w = Screen.width;
    //public int h = Screen.height;
    //public Vector3 mpos;

    private GameObject hit_obj;
    private bool contact;
    public bool inBackpack = true;

    private void Start()
    {
        startpos = transform.position;
    }

    private void Update()
    {
        if (transform.position == startpos) {
            inBackpack = true;
        }
        else
        {
            inBackpack = false;
        }
    }
    private void OnMouseEnter()
    {
        //transform.localScale = new Vector3(transform.localScale.x+10f, transform.localScale.y, transform.localScale.z + 10f);

        //plays sound on hover but only in backpack
        if (inBackpack)
        {
   
                AudioSource sound = this.gameObject.GetComponent<AudioSource>();
                sound.Play();
            
        }
    }
    private void OnMouseExit()
    {
        //transform.localScale = new Vector3(transform.localScale.x - 10f, transform.localScale.y, transform.localScale.z - 10f);
        
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
        
       // rb.MovePosition(position);
    }
    private void OnTriggerEnter(Collider bar)//detect contact enter
    {
       /* if (bar.transform.CompareTag("backpack") == true)
        {
            inBackpack = true;
            Debug.Log("inbag");
        }*/

        if (bar.transform.parent.CompareTag("songbar") == true)
        {
            hit_obj = bar.gameObject;
            contact = true;
        }
    }

    private void OnTriggerExit(Collider bar)//detect contact exit
    {
        if (bar.transform.parent.CompareTag("songbar") == true) {
            contact = false;
        }
       /* if (bar.transform.CompareTag("backpack") == true)
        {
            inBackpack = false;
            Debug.Log("out of bag");
        }*/
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

    public void ResetPos()
    {
        transform.position = startpos;
    }
}