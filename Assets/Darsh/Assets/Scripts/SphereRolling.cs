using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereRolling : MonoBehaviour {

    // Use this for initialization
    public float speed;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;

    }

    // Update is called once per frame
    void Update () {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        speed = speed * -1;
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        Start();
    }
}
