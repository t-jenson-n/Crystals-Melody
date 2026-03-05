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

    public Button backpackButton;

    public TextMeshProUGUI rocksCounter_Text;

    public bool melodyCorrect = false;

    void Start()
    {
        backpackButton.GetComponent<StatusChange>().Hide();

    }

    void Update()
    {
        rocksCounter_Text.text = "ROCKS COLLECTED: " + rocksCollected;

        if (rocksCollected >= 4)
        {
            backpackButton.GetComponent<StatusChange>().Show();
        }

        if (melodyCorrect == true)
        {
            gameObject.GetComponent<SceneChanger>().LoadGameEnd();
        }

    }
}
