using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
using Image = UnityEngine.UI.Image;

public class SeatScript : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    // string sceneName;
    public string rowString;
    public string columnString;
    
    private int r, c;
    private float x, y, z; 
    private int num;
    private miscLogicScript misclog;
    private Image disButton; 
    private TMP_Text rowColText;
    private simulateScript simScript;
    private GameObject[] removeObject;
    private SeatScript[] seatScript; 
    private bool clickedOn;

    void Start()
    {
        misclog = GameObject.FindGameObjectWithTag("miscLogic").GetComponent<miscLogicScript>();
        disButton = GameObject.FindGameObjectWithTag("displayButton").GetComponent<Image>();
        rowColText = GameObject.FindGameObjectWithTag("rowcoltext").GetComponent<TMP_Text>();
        simScript = GameObject.FindGameObjectWithTag("SimulateButton").GetComponent<simulateScript>();
        removeObject = GameObject.FindGameObjectsWithTag("Area");

        disButton.enabled = false;
        clickedOn = false;

        // Convert row and column to ints
        c = int.Parse(columnString);
        r = char.Parse(rowString) - 64; // r is 1 if row is A, 2 if B, ...

        // Seating position of seat A1
        x = -8.81f;
        y = 1.0f;
        z = 9.72f;
    }

    void Update()
    {
        // Clicked on
        if (clickedOn)
        {
            this.GetComponent<Image>().sprite = misclog.getUpdatedSprite();
            disButton.enabled = true;
            rowColText.text = miscLogicScript.Reverse(rowString + " " + columnString);

            // Clicked off
            if (Input.GetMouseButtonDown(0) && !simScript.getSimEntered())
            {
                clickedOn = false;
                this.GetComponent<UnityEngine.UI.Image>().sprite = misclog.getOriginalSprite();
                disButton.enabled = false;
                rowColText.text = "";
                simScript.unsimulate();
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        clickedOn = true; 
        simScript.simulate();
        findSeatPosition(true);
        TransferVarScript.reset = true; 
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.GetComponent<Image>().sprite = misclog.getUpdatedSprite();
        disButton.enabled = true;
        rowColText.text = miscLogicScript.Reverse(rowString + " " + columnString); 
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.GetComponent<Image>().sprite = misclog.getOriginalSprite();
        disButton.enabled = false;
        rowColText.text = "";
    }

    public void findSeatPosition(bool test)
    {
        float col = c; 
        float row = r;
 
        if (c >= 1 && c <=6) // LEFT
        {
            col = c - 1.0f;
            row = r - 1.0f;

            // Column adjustments 
            x += 0.49f * col;
            z -= 0.08f * col;

            // Row adjustments
            y += 0.2f * row;
            z -= 0.7514285714f * row;
        }
        else if (c >= 7 && c <= 26) //CENTER
        {
            x = -4.75f;
            y = 1.0f;
            z = 9.3f;

            col = c - 7.0f;
            row = r - 1.0f;

            // Column adjustments
            x += 0.50f * col;

            // Row adjustments
            y += 0.2f * row;
            z -= 0.7514285714f * row;
        }
        else if (c >= 27 && c <= 32) //RIGHT
        {
            x = 6.16f;
            y = 1.0f;
            z = 9.72f;

            col = c - 27.0f;
            row = r - 1.0f;

            // Column adjustments 
            x += 0.49f * col;
            z += 0.08f * col;

            // Row adjustments
            y += 0.2f * row;
            z -= 0.7514285714f * row;
        }
        else
        {
            Debug.Log("Number outside range");
        }

        if (test)
        {
            Debug.Log(x);
            Debug.Log(y);
            Debug.Log(z);
        }

        // Assign seat positions to static variables
        TransferVarScript.x_pos = x;
        TransferVarScript.y_pos = y;
        TransferVarScript.z_pos = z;

        x = -8.81f;
        y = 1.0f;
        z = 9.72f;

        col = c;
        row = r;
    }

    public void clickedOff()
    {
        clickedOn = false; 
    }
}

