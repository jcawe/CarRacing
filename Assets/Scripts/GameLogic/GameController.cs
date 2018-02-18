using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public float CheckpointWeight = 1;
    public int MaxLaps = 3;
    public LapDisplay LapDisplay;
    [SerializeField] public GameObject[] Cars;
    public event Action OnStartGame;
    public event Action OnEndGame;
    StartCounter StartCounter;
    public GameObject EndDisplay;
    public GameObject EndCamera;

    // Use this for initialization
    void Start()
    {
        var counters = Cars.Select(x => x.GetComponent<LapCounter>()).Where(x => x != null);
        var timers = Cars.Select(x => x.GetComponent<Timer>()).Where(x => x != null);
        var engines = Cars.Select(x => x.GetComponent<Engine>()).Where(x => x != null);

        foreach (var counter in counters) counter.OnLapComplete += CheckGoal;
        foreach (var timer in timers) OnStartGame += () => timer.StartTimer();
        foreach (var engine in engines)
        {
            engine.FixedBrake();
            engine.enabled = false;
            OnStartGame += () => engine.enabled = true;
        }

        LapDisplay?.SetMaxLaps(MaxLaps);

        StartCounter = GetComponent<StartCounter>();
        if (StartCounter != null && StartCounter.enabled) StartCounter.OnFinish += () => OnStartGame();
        else StartCoroutine(StartGame());

        OnEndGame += () => EndDisplay.SetActive(true);
        if (EndCamera != null) OnEndGame += () => EndCamera.SetActive(true);
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Starting game!!");
        OnStartGame();
    }

    public void CheckGoal(int laps)
    {
        if (laps >= MaxLaps) OnEndGame?.Invoke();
    }

    void Update()
    {
        CheckRacePlaces();

        if(Input.GetButton("Cancel"))
        {
            Debug.Log("QUIT!!!");
            Application.Quit();
        }
    }

    private void CheckRacePlaces()
    {
        Dictionary<GameObject, float> places = new Dictionary<GameObject, float>();
        foreach (var car in Cars.Where(x => x.GetComponent<CheckpointTracker>() != null))
        {
            var tracker = car.GetComponent<CheckpointTracker>();
            places.Add(car, tracker.Checkpoints * CheckpointWeight + tracker.DistanceLastCheckpoint);
        }
        int place = 1;
        places.OrderByDescending(x => x.Value).Select(x => x.Key).ToList().ForEach(x =>
        {
            var racePlace = x.GetComponent<RacePlace>();
            racePlace.Place = place++;
        });
    }
}
