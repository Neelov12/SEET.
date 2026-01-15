using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class simulateScript : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler     
{
    private ColorBlock c;
    private ColorBlock ogColor;
    private Color ogTextColor;
    private bool simulated;
    private bool simEntered; 
    private Button b; 

    void Start()
    {
        c = GetComponent<Button>().colors;
        ogColor = c;
        b = GetComponent<Button>();

        ogTextColor = this.GetComponentInChildren<TMP_Text>().color;
        simulated = false;
        simEntered = false; 
    }

    public void simulate()
    {
        // Background color 
        c.highlightedColor = new Color(255.0f, 255.0f, 255.0f, 0.1f);
        c.normalColor = new Color(255.0f, 255.0f, 255.0f, 0.2f);
        c.pressedColor = new Color(255.0f, 255.0f, 255.0f, 0.1f);

        b.colors = c;
        // Text color 
        this.GetComponentInChildren<TMP_Text>().color = new Color(204.0f, 211.0f, 226.0f, 255.0f);
        simulated = true; 
    }

    public void unsimulate()
    {
        // Background color 
        c.highlightedColor = ogColor.highlightedColor;
        c.normalColor = ogColor.normalColor;
        c.pressedColor = ogColor.pressedColor; 

        b.colors = c;

        // Text color 
        this.GetComponentInChildren<TMP_Text>().color = ogTextColor;
        simulated = false; 
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (simulated)
        {
            if (transform.tag == "SimulateButton")
            {
                SceneManager.LoadScene(2);
            }
            else if (transform.tag == "arenaSimulateButton")
            {
                SceneManager.LoadScene(5);
            }
        }
    }


    public void setSimulate(bool status)
    {
        simulated = status; 
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        simEntered = true; 
    }

    public bool getSimEntered()
    {
        return simEntered; 
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        simEntered = false; 
    }
}
