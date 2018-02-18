using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Engine))]
public class SpeedDisplay : MonoBehaviour
{
	public Text Display;
	private Engine _engine;

	private int velocity;

	void Start()
	{
		_engine = GetComponent<Engine>();
	}
	void OnGUI()
	{
		Display.text = velocity.ToString();
	}

	void FixedUpdate()
	{
		if(!_engine.enabled) return;
		velocity = Mathf.RoundToInt(_engine.CurrentSpeed);
	}
}
