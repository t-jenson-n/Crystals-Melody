using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject howToPlayMenu;

    public Slider volumeSlider;
    public AudioSource caveSoundTwo;

    public GameObject menu;
    public GameObject menuBtn;
    
    void Start()
    {
        volumeSlider.value = 0.250f;
    }

    
    void Update()
    {
        caveSoundTwo.volume = volumeSlider.value;
    }




    public void GoToHowToPlay()
    {

        howToPlayMenu.SetActive(true);
        mainMenu.SetActive(false);

    }


    public void GoToMainMenu()
    {

        howToPlayMenu.SetActive(false);
        mainMenu.SetActive(true);

    }


    //public void CloseMenu()
    //{
        //menu.SetActive(false);
    //}


    public void MenuInteraction( bool x )
    {
        menu.SetActive(x);
        menuBtn.SetActive(!x);
    }



    public bool MenuStatus()
    {
        return menu.activeSelf;
    }
    

}
  