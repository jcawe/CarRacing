using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapDisplay : MonoBehaviour
{
	int _laps;
    int _maxLaps;
	public Text LapCounterDisplay;
	public Text MaxLapDisplay;

	void OnGUI()
	{
		LapCounterDisplay.text = _laps.ToString();
		MaxLapDisplay.text = _maxLaps.ToString();
	}

    public void SetMaxLaps(int maxLaps)
    {
        _maxLaps = maxLaps;
    }

    public void SetLaps(int laps)
    {
        _laps = laps;
    }
}