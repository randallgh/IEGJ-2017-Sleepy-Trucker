using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_ButtonTrigger_1 : MonoBehaviour {

    public AudioSource[] audioSource;
    int audioIncrement = 0;

    // Use this for initialization
    void Start () {
        audioSource[0] = GetComponent<AudioSource>();
        audioSource[1] = GetComponent<AudioSource>();
        audioSource[2] = GetComponent<AudioSource>();
        audioSource[3] = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    //void Update () {
    //       Touch myTouch = Input.GetTouch(0);

    //}
    private void OnCollisionEnter(Collision collision)
    {
        if (audioIncrement <= 4)
        {
            audioSource[audioIncrement].Play();
            audioIncrement++;
        }
        else
        {
            audioIncrement = 0;
            OnCollisionEnter(collision);
        }
    }
}
