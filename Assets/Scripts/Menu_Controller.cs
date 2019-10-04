using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Controller : MonoBehaviour
{
    public GameObject Panel_Menu;
    public GameObject PlayButton;
    public GameObject QuitButton;

    public void Awake()
    {
        Panel_Menu = GameObject.Find("Panel_Menu");
        Panel_Menu.SetActive(true);

        PlayButton = GameObject.Find("PlayButton");
        QuitButton = GameObject.Find("QuitButton");
    }

    public void playButtonClicked()
    {
        UI_Controller.Instance.PlayGame(); 
    }

    public void quitButtonClicked()
    {
        UI_Controller.Instance.QuitGame();
    }
}
