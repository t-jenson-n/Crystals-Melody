using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class hover_effect : MonoBehaviour
{
    public GameObject note;
    private Renderer barRenderer;
    // Start is called before the first frame update
    void Start()
    {
        barRenderer = GetComponent<Renderer>();
    }
    void OnTriggerEnter(Collider collision)
    {
        //EditorUtility.DisplayDialog("working?", "working", "ok", "cancel");
        Debug.Log("contact");
        if (collision.transform.parent.gameObject == note)
        {
            barRenderer.material.color = collision.GetComponent<Renderer>().material.color ;
        }
    }
    private void OnTriggerStay(Collider collision)
    {
        if (collision.transform.parent.gameObject == note)
        {
            barRenderer.material.color = collision.GetComponent<Renderer>().material.color;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        barRenderer.material.color = Color.black;
    }
}
