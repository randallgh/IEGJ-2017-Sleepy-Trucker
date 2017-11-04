using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckController : MonoBehaviour {

    new Rigidbody rigidbody;

    float rotation = 0;
    public float rotationSpeed = 100;

    public float maxSpeed = 600;

    public float speed = 10;
    public float velocityMagnitude = 0;

    KeyCode accelerate = KeyCode.W;
    KeyCode decelerate = KeyCode.S;

    KeyCode turnRight = KeyCode.D;
    KeyCode turnLeft = KeyCode.A;

    bool isAlive = true;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        if (!isAlive)
        {
            //gameObject.SetActive(false);
            rigidbody.velocity = new Vector3(0, 0, 0);
            return;
        }

        if (Input.GetKey(turnRight))
        {
            //transform.Rotate(new Vector3(0, rotationSpeed));
            rotation += rotationSpeed;
        }
        else if (Input.GetKey(turnLeft))
        {
            // transform.Rotate(new Vector3(0, -rotationSpeed));
            rotation -= rotationSpeed;
        }

        transform.eulerAngles = new Vector3(0, rotation, 0);

        if (Input.GetKey(accelerate))
        {
            velocityMagnitude += speed;
        }
        else if (Input.GetKey(decelerate))
        {
            velocityMagnitude -= speed;
        }

        velocityMagnitude = Mathf.Clamp(velocityMagnitude, -maxSpeed, maxSpeed);

        Vector2 velocity = MathG.DegreeToVector(transform.rotation.eulerAngles.y, 1) * velocityMagnitude * Time.deltaTime;
        rigidbody.velocity = new Vector3(velocity.x, 0, -velocity.y);
        //rigidbody.AddForce(new Vector3(velocity.x, 0, velocity.y));
        //velocityMagnitude = 0;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            isAlive = false;
        }
    }
}
