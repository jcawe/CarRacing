using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapCounter : MonoBehaviour
{
	public LapDisplay LapDisplay;

	public TimerDisplay BestTimeDisplay;

	public event Action<int> OnLapComplete;
	private Timer _timer;
	private float bestTime;
	
	int _laps;

	void Start()
	{
		_timer = GetComponent<Timer>();
		LapDisplay?.SetLaps(_laps);
	}

    public int Laps => _laps;

    public void AddLap()
	{
		_laps++;
		LapDisplay?.SetLaps(_laps);
		OnLapComplete?.Invoke(_laps);
		Debug.Log($"{gameObject.name} - AddLap: {_laps}");
		var time = _timer?.Reset();

		if(!time.HasValue) return;

		bestTime = bestTime == 0 || time.Value < bestTime ? time.Value : bestTime;

		BestTimeDisplay?.SetTime(bestTime);
	}
}
