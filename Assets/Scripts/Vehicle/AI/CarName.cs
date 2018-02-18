using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarName : MonoBehaviour
{
	private static int CarId = 1;
	public string Name;

    // Use this for initialization
    void Start()
    {
		gameObject.name = $"{Name}{CarId++}";
    }
}
