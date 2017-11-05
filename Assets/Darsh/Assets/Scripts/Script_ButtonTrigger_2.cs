using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_ButtonTrigger_2 : MonoBehaviour {

    //AudioSource audioSource;
    public AudioClip[] radio;
    private AudioSource radioSource;
    int audioIncrement = 0;

    // Use this for initialization
    void Start () {
       radioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (audioIncrement < 4) //change this number if you want to add more than 4 stations.
        {

            radioSource.clip = radio[audioIncrement];
            radioSource.Play();
            audioIncrement++;
        }
        else
        {
            audioIncrement = 0;
            OnCollisionEnter(collision);
        }
    }
}
