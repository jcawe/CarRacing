using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour
{
	public Text MinutesCount;
	public Text SecondsCount;
	public Text MilisecondsCount;
	
	private float miliseconds = 0f;
	private int seconds = 0;
	private int minutes = 0;

    public void SetTime(float miliseconds)
	{
		seconds = Mathf.RoundToInt(miliseconds / 1000) % 60;
        minutes = Mathf.RoundToInt(miliseconds / 1000) / 60;

        MinutesCount.text = minutes.ToString("00");
        SecondsCount.text = seconds.ToString("00");
        MilisecondsCount.text = (miliseconds % 1000).ToString("000");
	}
}
