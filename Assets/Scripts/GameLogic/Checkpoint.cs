using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    public bool isGoal;
    public Checkpoint NextCheckpoint;

    private new Light light;
    private new Collider collider;

    void Start()
    {
        light = GetComponent<Light>();
        collider = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject car = other.transform.root.gameObject;

		CheckpointTracker tracker = car.GetComponent<CheckpointTracker>();

		if(tracker == null || !tracker.isNextCheckPoint(this)) return;

		tracker.SetNextCheckPoint(NextCheckpoint);

        LapCounter counter = car.GetComponent<LapCounter>();

        if (counter != null && isGoal)
        {
            counter.AddLap();
            Debug.Log($"{car.name} - Lap!");
        }

        if (car.tag != "Player") return;

        SetCheckpoint(false);

        NextCheckpoint?.ActivateCheckpoint();
    }

    public void ActivateCheckpoint() => SetCheckpoint(true);

    void SetCheckpoint(bool active)
    {
        if (light != null) light.enabled = active;
        // collider.enabled = active;
    }
}
