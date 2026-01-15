using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour, IPointerClickHandler
{
    public string sceneName;

    private bool exitmode; 

    private int num;

    void Start()
    {
        exitmode = false;

        if (sceneName == "mainMenu")
        {
            num = 0;
        }
        else if (sceneName == "theaterMenu")
        {
            num = 1;
        }
        else if (sceneName == "theater")
        {
            num = 2;
        }
        else if (sceneName == "arenaMenu")
        {
            num = 3; 
        }
        else if (sceneName == "seatsArena")
        {
            num = 4;
        }
        else if (sceneName == "arena")
        {
            num = 5; 
        }
        else if (sceneName == "exit")
        {
            exitmode = true; 
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(num);

        if (exitmode)
        {
            Application.Quit(); 
        }
    }
}
