using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_ButtonTrigger_3 : MonoBehaviour {

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
    void Start () {
       //radioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision) //Change collision to also work with VR
    {
        if (GameObject.FindGameObjectWithTag("RadioButton").GetComponent<Script_TalkRadio_1>().muted)
        {
            if (audioIncrement < 8) //change this number if you want to add more than 4 stations.
            {
                radioSource.clip = radio[audioIncrement];
                //randomStartingTime = Random.Range(0, radio[audioIncrement].length); //change max range for shortest track on the list
                //radioSource.time = randomStartingTime;
                radioSource.volume = 100;
                Debug.Log(audioIncrement);
                radioSource.Play();
                audioIncrement++;
            }
            else
            {
                audioIncrement = 0;
                OnCollisionEnter(collision);
            }
        }
        else
        {
            radioSource.volume = 0.0f;
        }
    }
}
