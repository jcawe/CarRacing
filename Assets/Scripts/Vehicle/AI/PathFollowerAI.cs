using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SteerWheel))]
public class PathFollowerAI : MonoBehaviour
{
    public Path Path;
    public float MinNodeDistance;
    
    [Range(0, 100)]
    public float SteerSpeed;

    private Queue<Vector3> _path;
    private SteerWheel _steerWheel;
    private bool _avoiding = false;
    private bool _stucked;

    public void SetAvoiding(bool avoiding) => _avoiding = avoiding;
    public void SetStucked(bool stucked) => _stucked = stucked;

    private float SteerAxis
    {
        get
        {
            var relative = transform.InverseTransformPoint(CurrentNode);
            return relative.x / relative.magnitude;
        }
    }

    private float NodeDistance => (transform.position - CurrentNode).magnitude;

    private Vector3 CurrentNode => _path.Peek();

    private void CheckNodeDistance()
    {
        if(NodeDistance > MinNodeDistance) return;

        var node = _path.Dequeue();
        if(Path.Loop) _path.Enqueue(node);
    }

    void Start()
    {
        _steerWheel = GetComponent<SteerWheel>();
        _path = Path.Nodes;
    }

    void FixedUpdate()
    {
        CheckNodeDistance();

        if(_avoiding || _stucked)
        {
            _avoiding = false;
            return;
        }

        _steerWheel.SetSteerAxis(Mathf.Lerp(_steerWheel.SteerAxis, SteerAxis, Time.deltaTime*SteerSpeed));
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(255, 150, 0, 0.2f);
        Gizmos.DrawWireSphere(transform.position, MinNodeDistance);
    }
}