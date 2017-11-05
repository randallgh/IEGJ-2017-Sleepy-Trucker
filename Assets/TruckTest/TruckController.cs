using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckController : MonoBehaviour {

    new Rigidbody rigidbody;

    public float sideSpeed;

    KeyCode turnRight = KeyCode.D;
    KeyCode turnLeft = KeyCode.A;

    bool isAlive = true;

	// Use this for initialization
	void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(turnRight))
        {
            rigidbody.velocity = new Vector3(sideSpeed, 0, 0);
        }
        else if (Input.GetKey(turnLeft))
        {
            rigidbody.velocity = -new Vector3(sideSpeed, 0, 0);
        }
        else
        {
            rigidbody.velocity = new Vector3(0, 0, 0);
        }

    }
}
