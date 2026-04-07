using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class skip : MonoBehaviour
{
    public Button skipbutton;

    // Start is called before the first frame update
    void Start()
    {
        skipbutton.onClick.AddListener(clickskip);
    }

  void clickskip()
    {
       // Debug.Log("click");
        //this.gameObject.GetComponent<MusicController>().melodyCorrect = true;
        for(int i =0; i<4; i++)
        {
            this.gameObject.GetComponent<MusicController>().check[i] = true;

        }
        
  
    }
}
