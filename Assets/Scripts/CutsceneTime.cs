using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTime : MonoBehaviour
{
    public string sceneName;
    public float cutsceneTime;
    private float AnimTimer;
    public GameObject SceneScript;

    // Start is called before the first frame update
    void Start()
    {
        AnimTimer = cutsceneTime;
    }

    // Update is called once per frame
    void Update()
    {
        AnimTimer -= Time.deltaTime;
        if (AnimTimer <= 0)
        {
            SceneScript.GetComponent<SceneChanger>().LoadScene(sceneName);
        }
    }
}
