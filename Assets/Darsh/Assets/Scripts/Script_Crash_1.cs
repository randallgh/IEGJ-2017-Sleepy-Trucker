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
    private void OnCollisionEnter(Collision collision)
    {
        crashSource.clip = crashClip;
        crashSource.Play();
    }
}
