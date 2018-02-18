using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StableCamera : MonoBehaviour {
	public GameObject player;       //Public variable to store a reference to the player game object

    private float inclination;

    void Start()
    {
        inclination = transform.eulerAngles.x;
    }
    void Update () 
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.eulerAngles = new Vector3(
            inclination, 
            player.transform.eulerAngles.y, 
            0f);
    }
}
