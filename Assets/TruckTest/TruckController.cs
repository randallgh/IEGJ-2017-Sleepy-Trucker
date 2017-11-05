using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckController : MonoBehaviour {

    new Rigidbody rigidbody;

    public GameObject steeringWheel;
    

    public float sideSpeed;

    public Hand leftHand;
    public Hand rightHand;

    KeyCode turnRight = KeyCode.D;
    KeyCode turnLeft = KeyCode.A;

    bool isAlive = true;

    private float wheelAngle;
    private float lastAngle;


    private Wheel wheel;
    // Use this for initialization
    void Start ()
    {
        wheel = steeringWheel.GetComponent<Wheel>();
        rigidbody = GetComponent<Rigidbody>();
        wheelAngle = 0;
        lastAngle = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(turnRight))
        {

        }
        else if (Input.GetKey(turnLeft))
        {

        }
        //else
        //{
        //    rigidbody.velocity = new Vector3(0, 0, 0);
        //}
        //Debug.Log(steeringWheel.transform.rotation.z);

        if(wheel.GetSteered())
        {
            wheelAngle = wheel.GetSteeringInput();
            //wheelAngle = rightHand.GetLastAngleAdjustment();
        }
        else
        {
            wheelAngle = 0;
        }

        //rigidbody.velocity = new Vector3(steeringWheel.transform.rotation.z * -10, 0, 0);
        //rigidbody.velocity = new Vector3(wheelAngle * 0.5f, 0, 0);
        Vector3 newPosition = transform.position + new Vector3((wheelAngle * 0.5f) * Time.deltaTime, 0, 0);

        transform.position = new Vector3(Mathf.Clamp(newPosition.x, -10, 10), newPosition.y, newPosition.z);
        //transform.position += new Vector3((wheelAngle * 0.5f) * Time.deltaTime, 0, 0);
    }
}
