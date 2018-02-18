using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressLight : TurnableLight
{
	private bool _isPressed = false;

	public override void TurnOnOff(LightTurnOnOffAction onOff)
	{
		base.TurnOnOff(onOff);

		_isPressed = _light.enabled;
	}
	void LateUpdate()
	{
		if(!_isPressed) _light.enabled = false;
		else _isPressed = false;
	}
}
