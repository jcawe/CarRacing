using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

[RequireComponent(typeof(Engine))]
[RequireComponent(typeof(SteerWheel))]
public class CarController : MonoBehaviour
{
    private Engine _engine;
    private SteerWheel _steerWheel;

    // Use this for initialization
    void Start()
    {
        _engine = GetComponent<Engine>();
        _steerWheel = GetComponent<SteerWheel>();
    }

    private void ApplyAxisToComponent(string axisName, Action<float> functionSetter) => functionSetter(Input.GetAxis(axisName));

    // Update is called once per frame
    void Update()
    {
        ApplyAxisToComponent("Horizontal", _steerWheel.SetSteerAxis);
        ApplyAxisToComponent("Vertical", _engine.SetTorqueAxis);

        if(Input.GetKeyDown("l")) BroadcastMessage("Lights", SendMessageOptions.DontRequireReceiver);
        else if(Input.GetKeyDown("q")) BroadcastMessage("LeftBlinker", SendMessageOptions.DontRequireReceiver);
        else if(Input.GetKeyDown("e")) BroadcastMessage("RightBlinker", SendMessageOptions.DontRequireReceiver);
    }
}
