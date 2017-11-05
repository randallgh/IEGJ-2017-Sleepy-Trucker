using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_RadioController_5 : MonoBehaviour {

    //AudioSource audioSource;
    public AudioClip[] radio;
    public static int numberOfStations = 12; //change this to match the number of radio stations you have
    float[] radioPointsArray = new float[numberOfStations]; //Used to assign points to the radio stations
    private AudioSource radioSource;
    int audioIncrement = 0;
    //int radioIncrement = 0; //Used to increment to assign values to array boxes;
    //float randomStartingTime;
    // Use this for initialization
    private void Awake()
    {
        radioSource = GetComponent<AudioSource>();
        for(int i = 0; i< numberOfStations; i++)
        {
            if(i % 2 != 0)
            {
                radioPointsArray[i] = 4;
            }
            else
            {
                radioPointsArray[i] = 6;
            }
        }
    }
    private void OnCollisionEnter(Collision collision) //Change collision to also work with VR
    {
        if (audioIncrement < numberOfStations) //change this number if you want to add more stations.
        {
            radioSource.clip = radio[audioIncrement];
            if (audioIncrement % 2 != 0)//talk radio is on odd numbers starting from 1, last array elements are creepy
            {
                Debug.Log(Time.realtimeSinceStartup);
                radioPointsArray[audioIncrement] = radioPointsArray[audioIncrement] - .6f;
                Debug.Log("Talk Effectiveness: " + radioPointsArray[audioIncrement]);
                if (Time.realtimeSinceStartup < radio[audioIncrement].length)
                {
                    radioSource.time = Time.realtimeSinceStartup;
                    radioSource.Play();
                }
                else
                {
                    radioSource.Stop();
                }
            }
            else //If not an odd number, play music
            {
                radioSource.time = 0.0f;
                radioPointsArray[audioIncrement] = radioPointsArray[audioIncrement] - .6f;
                Debug.Log("Music Effectiveness: " + radioPointsArray[audioIncrement]);
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
