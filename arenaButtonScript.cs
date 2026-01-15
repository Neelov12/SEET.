using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class arenaButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public string sectionName;
        // Ex: "R3BL1" = Row 3, Bottom Left, Section 1

    private Vector3 originalScale, multipleScale, newScale, thisPosition;

    //private Image image;

    private TMP_Text rowColText;

    private GameObject toFrontObject;

    // private Sprite thisSprite;
    private Transform myTransform, newParent; 

    public void OnPointerClick(PointerEventData eventData)
    {
        arenaTransferScript.section = sectionName;
        SceneManager.LoadScene(4); 
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.transform.localScale = newScale;
        this.transform.SetParent(newParent); 
        Debug.Log(myTransform.name);
        rowColText.text = miscLogicScript.Reverse(sectionName);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.transform.SetParent(myTransform);
        this.transform.localScale = originalScale; 
    }

    // Start is called before the first frame update
    void Start()
    {
        originalScale = this.transform.localScale;
        if(sectionName == "000000")
            { multipleScale = new Vector3(1.1f, 1.1f, 1f); }
        else
            { multipleScale = new Vector3(1.275f, 1.275f, 1f); }
       
        newScale = Vector3.Scale(originalScale, multipleScale);
        /*thisPosition = this.transform.position;
        thisSprite = this.GetComponent<Image>().sprite; */

        rowColText = GameObject.FindGameObjectWithTag("ArenaDisplayButton").GetComponent<TMP_Text>();

        toFrontObject = GameObject.FindGameObjectWithTag("movedToFront");

        // Set this object parent and set to front parent
        myTransform = this.transform.parent; 
        newParent = toFrontObject.transform; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
