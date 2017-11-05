using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_ButtonTrigger_4 : MonoBehaviour {

    //AudioSource audioSource;
    public AudioClip[] radio;
    private AudioSource radioSource;
    int audioIncrement = 0;
    //float randomStartingTime;
    // Use this for initialization
    private void Awake()
    {
        radioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision) //Change collision to also work with VR
    {
        if (audioIncrement < 8) //change this number if you want to add more stations.
        {
            radioSource.clip = radio[audioIncrement];
            if (audioIncrement % 2 != 0)//talk radio is on odd numbers starting from 1, last array elements are creepy
            {
                Debug.Log(Time.realtimeSinceStartup);
                radioSource.time = Time.realtimeSinceStartup;
                radioSource.Play();
            }
            else //If not an odd number, play music
            {
                radioSource.Play();
            }
            audioIncrement++;
        }
        else
        {
            audioIncrement = 0;
            OnCollisionEnter(collision);
        }
    }
}
