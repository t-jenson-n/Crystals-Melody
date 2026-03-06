using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;


public class MusicController : MonoBehaviour
{

    public bool melodyCorrect = false;

    void Start()
    {

    }

    void Update()
    {
      
        if (melodyCorrect == true)
        {
            gameObject.GetComponent<SceneChanger>().LoadGameEnd();
        }

    }

}