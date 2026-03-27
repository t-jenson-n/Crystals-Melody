using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;


public class GameController : MonoBehaviour
{
    //storage arrays
    public int[] gemCollect = { 1, 2, 3, 4 };
    public bool[] gemHas = { false, false, false, false };

    public int rocksCollected = 0;
    public int rocksTotal;

    public Button backpackButton;

    public TextMeshProUGUI rocksCounter_Text;


    void Start()
    {
        backpackButton.GetComponent<StatusChange>().Hide();

    }

    void Update()
    {
        rocksCounter_Text.text = "ROCKS COLLECTED: " + rocksCollected;

        if (rocksCollected >= rocksTotal)
        {
            backpackButton.GetComponent<StatusChange>().Show();

            Debug.Log("?????????   Added a rock : " + rocksCollected);
        }



    }

}
