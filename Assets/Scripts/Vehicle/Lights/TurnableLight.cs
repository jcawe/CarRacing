using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LightFunction { Light, Brake, LeftBlinker, RightBlinker }

public struct LightTurnOnOffAction
{
    public bool Enabled { get; set; }
    public LightFunction LightFunction { get; set; }
}

[RequireComponent(typeof(Light))]
public class TurnableLight : MonoBehaviour
{
    public LightFunction LightFunction;

    protected Light _light;

    public void Awake()
    {
        _light = GetComponent<Light>();
    }

    public virtual void TurnOnOff(LightTurnOnOffAction onOff) => _light.enabled = LightFunction == onOff.LightFunction ? onOff.Enabled : _light.enabled;
}
