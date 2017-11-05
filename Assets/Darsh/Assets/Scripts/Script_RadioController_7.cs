using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_RadioController_7 : MonoBehaviour {

    //AudioSource audioSource;
    public AudioClip[] radio;
    public int numberOfStations = 12; //change this to match the number of radio stations you have
    public int creepyStations = 4;
    List<float> radioPointsArray = new List<float>();
    //float[] radioPointsArray = new float[numberOfStations]; //Used to assign points to the radio stations
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
                radioPointsArray.Add(4);
            }
            else
            {
                radioPointsArray.Add(6);
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            playRadio();
        }
    }

    void playRadio()
    {
        if (audioIncrement < numberOfStations)//All music and talk
        {
            if (audioIncrement < numberOfStations - creepyStations) //Normal talk
            {
                Debug.Log("Array Index: " + audioIncrement);
                radioSource.clip = radio[audioIncrement];
                if (audioIncrement % 2 != 0)//talk radio is on odd numbers starting from 1, last array elements are creepy
                {
                    Debug.Log(Time.realtimeSinceStartup);
                    if (radioPointsArray[audioIncrement] > 0)
                    {
                        radioPointsArray[audioIncrement] = radioPointsArray[audioIncrement] - 1f;
                        Debug.Log("Talk Radio " + audioIncrement + " Effectiveness: " + radioPointsArray[audioIncrement]);
                    }
                    else
                    {
                        Debug.Log("Talk Radio " + audioIncrement + " is no longer Effective!");
                    }
                    if (Time.realtimeSinceStartup < radio[audioIncrement].length)
                    {
                        radioSource.time = Time.realtimeSinceStartup;
                        radioSource.Play();
                    }
                    else if (Time.realtimeSinceStartup >= radio[audioIncrement].length)
                    {
                        radioSource.Stop();

                    }
                }
                else //If not an even number, play normal music
                {
                    radioSource.time = 0.0f;
                    if (radioPointsArray[audioIncrement] > 0)
                    {
                        radioPointsArray[audioIncrement] = radioPointsArray[audioIncrement] - 1f;
                        Debug.Log("Music " + audioIncrement + " Effectiveness: " + radioPointsArray[audioIncrement]);
                    }
                    else
                    {
                        Debug.Log("Music " + audioIncrement + " is no longer Effective!");
                    }
                    radioSource.Play();
                }
            }
            else //Creepy Music modify here
            {
                Debug.Log("Array Index: " + audioIncrement);
                radioSource.clip = radio[audioIncrement];
                radioSource.time = 0.0f;
                if (radioPointsArray[audioIncrement] > 0)
                {
                    radioPointsArray[audioIncrement] = radioPointsArray[audioIncrement] - 1f;
                    Debug.Log("Creepy " + audioIncrement + " Effectiveness: " + radioPointsArray[audioIncrement]);
                }
                else
                {
                    Debug.Log("Creepy " + audioIncrement + " is no longer Effective!");
                }
                radioSource.Play();
            }
            audioIncrement++;
        }
        else
        {
            audioIncrement = 0;
        }
        
    } 

    private void OnTriggerEnter(Collider collider) //Change collision to also work with VR
    {
        Debug.Log("RAIDO TRIGGERED");
        playRadio();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("RAIDO COLLIDED");
        playRadio();
    }
}
