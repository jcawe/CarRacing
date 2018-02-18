using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RacePlace : MonoBehaviour
{
    public Text Display;
    Timer _timer = new Timer();
    public int Place { get; set; }

    public float GetTime() => _timer.Miliseconds;

    void OnGUI()
    {
        if(Display != null) Display.text = Place == 0 ? "-" : Place.ToString();
    }
}
