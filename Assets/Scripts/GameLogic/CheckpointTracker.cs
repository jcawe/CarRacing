using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RacePlace))]
public class CheckpointTracker : MonoBehaviour
{
    Checkpoint _nextCheckpoint;
	Vector3 _lastCheckpointPosition;

    public int Checkpoints { get; private set; }
	public float DistanceLastCheckpoint => (transform.root.position - _lastCheckpointPosition).magnitude;

	public void SetNextCheckPoint(Checkpoint checkpoint)
    {
		_lastCheckpointPosition = _nextCheckpoint?.transform?.position ?? transform.root.position;
        _nextCheckpoint = checkpoint;
        
		Checkpoints++;

    }
    public bool isNextCheckPoint(Checkpoint checkpoint) => (_nextCheckpoint == null && !checkpoint.isGoal) || (_nextCheckpoint != null && _nextCheckpoint.Equals(checkpoint));
}
