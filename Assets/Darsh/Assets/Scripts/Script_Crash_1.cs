using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Crash_1 : MonoBehaviour {
    public AudioClip crashClip;
    private AudioSource crashSource;


	// Use this for initialization
	void Start () {
        crashSource = GetComponent<AudioSource>();
	}

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            crashSource.clip = crashClip;
            crashSource.Play();

            Debug.Log("Game Over");
            //Game over here
        }
    }
}
