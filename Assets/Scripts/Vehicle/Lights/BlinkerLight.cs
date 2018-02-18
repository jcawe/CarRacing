using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkerLight : TurnableLight
{
	public float TimeBlink;
	private bool _isTurnOn;
	private float _timer = 0f;

	public override void TurnOnOff(LightTurnOnOffAction onOff)
	{
		base.TurnOnOff(onOff);

		_isTurnOn = LightFunction == onOff.LightFunction ? _light.enabled : _isTurnOn;
		_timer = LightFunction == onOff.LightFunction ? 0f : _timer;
	}

    // Update is called once per frame
    void FixedUpdate()
    {
		if(!_isTurnOn) return;

		_timer += Time.deltaTime;

		if(_timer < TimeBlink) return;

		_light.enabled = !_light.enabled;
		_timer = 0f;
    }
}
