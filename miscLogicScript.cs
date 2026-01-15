using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class miscLogicScript : MonoBehaviour
{
    public Sprite seatOriginalImg;
    public Sprite seatUpdatedImg;
    private GameObject previousSeat;

    void Start()
    {
        previousSeat = null;
    }

    public Sprite getOriginalSprite()
    {
        return seatOriginalImg;
    }
    public Sprite getUpdatedSprite()
    {
        return seatUpdatedImg;
    }
    public static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
    public GameObject getArenaSeatMap()
    {
        return GameObject.FindGameObjectWithTag("arenaSeatMap");
    }
}
