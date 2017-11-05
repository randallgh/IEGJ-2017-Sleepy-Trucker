using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_TalkRadio_1 : MonoBehaviour {

    public AudioClip talkRadio;
    protected AudioSource talkSource;
    public bool muted;

	// Use this for initialization
	void Awake () {
        talkSource = GetComponent<AudioSource>();
        talkSource.clip = talkRadio;
        talkSource.Play();
        muted = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (!muted)
            {
                talkSource.volume = 0.0f;
                muted = true;
                
            }
            else
            {
                talkSource.volume = 100f;
                muted = false;
                

            }
        }

	}
}
