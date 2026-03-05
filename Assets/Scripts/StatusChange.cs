using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusChange : MonoBehaviour
{
   
    void Start()
    {

    }

    void Update()
    {

    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}