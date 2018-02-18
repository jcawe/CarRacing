using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Path : MonoBehaviour
{
    public Queue<Vector3> Nodes => new Queue<Vector3>(GetComponentsInChildren<Transform>().Where(t => t != transform).Select(t => t.position));
    public bool Loop;
}