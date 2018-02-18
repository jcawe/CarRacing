using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartCounter : MonoBehaviour
{
	public event Action OnFinish;
	public Text CounterDisplay;
	public int TimeToStart = 3;

    // Use this for initialization
    void Start()
    {
		StartCoroutine(CountStart());
    }

    IEnumerator CountStart()
    {
		yield return Count("READY");
		for(int i = TimeToStart; i > 0; i--) yield return Count(i.ToString());
		yield return Count("GO!");

		OnFinish?.Invoke();
    }

	IEnumerator Count(string text)
	{
		yield return new WaitForSeconds(0.5f);
		CounterDisplay.text = text;
		CounterDisplay.gameObject.SetActive(true);
		yield return new WaitForSeconds(1f);
		CounterDisplay.gameObject.SetActive(false);
	}
}
