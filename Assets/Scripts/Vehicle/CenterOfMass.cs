using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CenterOfMass : MonoBehaviour
{
	public float Height;
	public Color Color;
	public float Radius;

	new Rigidbody rigidbody;

    // Use this for initialization
    void Awake()
    {
		
    }

    void OnDrawGizmosSelected()
	{
		rigidbody = GetComponent<Rigidbody>();
		//rigidbody.centerOfMass = rigidbody.centerOfMass - new Vector3(0, Height, 0);

		Gizmos.color = Color;
		Gizmos.DrawWireSphere(transform.TransformPoint(rigidbody.centerOfMass), Radius);
	}
}
