using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour
{
    private bool _lights = false;
    private bool _leftBlinker = false;
    private bool _rightBlinker = false;

    private LightTurnOnOffAction CreateTurnOffAction(bool enabled, LightFunction function) => new LightTurnOnOffAction { Enabled = enabled, LightFunction = function };
    public void Lights()
    {
        _lights = !_lights;
        BroadcastMessage("TurnOnOff", CreateTurnOffAction(_lights, LightFunction.Light), SendMessageOptions.DontRequireReceiver);
    }

    public void BrakeLight() => BroadcastMessage("TurnOnOff", CreateTurnOffAction(true, LightFunction.Brake), SendMessageOptions.DontRequireReceiver);
    public void LeftBlinker()
    {   
        if(_rightBlinker) RightBlinker();
        _leftBlinker = !_leftBlinker;

        BroadcastMessage("TurnOnOff", CreateTurnOffAction(_leftBlinker, LightFunction.LeftBlinker), SendMessageOptions.DontRequireReceiver);
    }

    public void RightBlinker()
    {
        if(_leftBlinker) LeftBlinker();
        _rightBlinker = !_rightBlinker;

        BroadcastMessage("TurnOnOff", CreateTurnOffAction(_rightBlinker, LightFunction.RightBlinker), SendMessageOptions.DontRequireReceiver);
    }
}
