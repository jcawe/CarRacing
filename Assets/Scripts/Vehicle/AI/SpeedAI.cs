using UnityEngine;

[RequireComponent(typeof(Engine))]
public class SpeedAI : MonoBehaviour
{
    public float MaxSpeed;

    private Engine _engine;
    private bool _stucked;

    public void SetStucked(bool stucked) => _stucked = stucked;

    void Start()
    {
        _engine = GetComponent<Engine>();
    }

    void FixedUpdate()
    {
        if (!_engine.enabled || _stucked) return;

        _engine.SetTorqueAxis(_engine.CurrentSpeed < MaxSpeed ? 1f : 0f);
    }
}