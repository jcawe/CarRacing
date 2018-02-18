using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Path))]
public class PathDrawing : MonoBehaviour
{
    public Color Color;
    public float NodeRadius;

    private void DrawPath(Queue<Vector3> path, bool isLoop)
    {
        Vector3? firstNode = null;
        Vector3 currentNode;
        Vector3? lastNode = null;

        while (path.Count > 0)
        {
            currentNode = path.Dequeue();
            Gizmos.DrawWireSphere(currentNode, NodeRadius);

            if (isLoop) firstNode = firstNode ?? currentNode;

            if (lastNode.HasValue) Gizmos.DrawLine(lastNode.GetValueOrDefault(), currentNode);

            lastNode = currentNode;
        }

        if (isLoop && lastNode.HasValue) Gizmos.DrawLine(lastNode.GetValueOrDefault(), firstNode.GetValueOrDefault());
    }

    void OnDrawGizmos()
    {
        var _path = GetComponent<Path>();
        Gizmos.color = Color;
        DrawPath(_path.Nodes, _path.Loop);
    }
}
