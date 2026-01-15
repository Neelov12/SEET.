using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ArenaSeatScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Sprite orignalSprite;
    public Sprite enabledSprite;
    public Sprite selectedSprite;

    private string seatCategory;

    private bool interactable, butEnabled, in_seat_col_set, clickedOn;

    private Image thisImageComponent;

    private simulateScript simScript; 

    public void OnPointerClick(PointerEventData eventData)
    {
        if (interactable)
        {
            // Sets image to selected
            clickedOn = true; 
            simScript.simulate(); 
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(interactable)
        {
            // Sets image to selected
            thisImageComponent.sprite = selectedSprite; 
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (interactable)
        {
            // Sets image to enabled 
            thisImageComponent.sprite = enabledSprite;
        }
    }

    private void initializeSeatCategory()
    {
        string temp_se_cat = "";
        Transform in_map_b_row = transform.parent;
        Transform in_map_side = in_map_b_row.parent;
        Transform number = in_map_side.parent;       // Section Name Number "....1"
        Transform x_side = number.parent;            // Section Horizontal Side "...C."
        Transform y_side = x_side.parent;            // Section Vertical Side "..T.."
        Transform row = y_side.parent;               // Section Row "R3..."

        // Row Name
        temp_se_cat += row.name.Substring(0, 1);
        temp_se_cat += row.name.Substring(4);

        // Vertical Side Name
        temp_se_cat += y_side.name.Substring(0, 1);

        // Horizontal Side Name
        temp_se_cat += x_side.name.Substring(0, 1);

        // Section Number
        temp_se_cat += number.name.Substring(0, 1);

        seatCategory = temp_se_cat; 
    }

    private void disableSimBut()
    {
            // Clicked off
            if (Input.GetMouseButtonDown(0) && !simScript.getSimEntered())
            {
                clickedOn = false;
                thisImageComponent.sprite = enabledSprite;
                //disButton.enabled = false;
                //rowColText.text = "";
                simScript.unsimulate();
            }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initializations 
        interactable = false;
        butEnabled = false;
        in_seat_col_set = false;
        clickedOn = false; 
        initializeSeatCategory();
        thisImageComponent = this.GetComponent<Image>();
        simScript = GameObject.FindGameObjectWithTag("arenaSimulateButton").GetComponent<simulateScript>();
    }

    // Update is called once per frame
    void Update()
    {
        bool sectionSelected = (seatCategory == arenaTransferScript.section); 

        if (sectionSelected)
        {
            // Enables Button
            interactable = true;
            butEnabled = true;

            // Repositions Seat Map
            // Complete Code

            // Changes image to enabled
            if (!in_seat_col_set)
            {
                thisImageComponent.sprite = enabledSprite;
                in_seat_col_set = true; 
            }

            // Disenables simulate button if anything else is selected 
            if (clickedOn)
            {
                thisImageComponent.sprite = selectedSprite;
                disableSimBut();
            }
        }

        // Reset 
        else if(!sectionSelected && butEnabled) 
        {
            interactable = false;
            butEnabled = false;
            in_seat_col_set = false; 
            thisImageComponent.sprite = orignalSprite; 
        }
    }
}
