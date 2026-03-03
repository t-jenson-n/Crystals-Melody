using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class dragdrop : MonoBehaviour
{
    public Vector3 startpos;
    private Rigidbody rb;

    private Vector3 newpos;
    private GameObject hit_obj;
    private bool contact;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();//set rigidbody
    }
    void OnMouseDrag()//drag object
    {
        Vector3 position = GetPos();
        transform.position = position;
        rb.MovePosition(position);
    }

    private void OnTriggerEnter(Collider bar)//detect contact enter
    {
        if(bar.CompareTag("songbar") == true)
        {
            hit_obj = bar.gameObject;
            contact = true;
            Debug.Log("contact with:" + bar.gameObject.name);
        }
    }

    private void OnTriggerExit(Collider bar)//detect contact exit
    {
        contact = false;
        Debug.Log("exited");
    }

    private void OnMouseUp()//return to starting position or new position
    {
        if(contact == true)
        {
            newpos = hit_obj.transform.position;
        }
        else
        {
            newpos = startpos;
        }
            gameObject.transform.position = newpos;
            rb.MovePosition(newpos);
    }

    private Vector3 GetPos()//get new position 
    {
        Vector3 mouse_adj = Input.mousePosition;
        mouse_adj.z = 880f;
        return Camera.main.ScreenToWorldPoint(mouse_adj);
    }
}
