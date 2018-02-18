using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private bool pause = true;
    private float miliseconds = 0f;
    public TimerDisplay display;

    public float Miliseconds => miliseconds;

    // Update is called once per frame
    void Update()
    {
        if(pause) return;
        
        miliseconds += Time.deltaTime * 1000;
        display?.SetTime(miliseconds);
    }

    public void StartTimer() => pause = false;

    public void StopTimer() => pause = true;

    public float Reset()
    {
        var time = miliseconds;
        
        miliseconds = 0f;
        display?.SetTime(miliseconds);

        return time;
    }
}
