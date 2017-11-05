using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private float wakefulness;

    public float maxWakefulness;
    public float maxWakefulnessToSet = 100;
    public float decreasePerSecond;
    public float startingWakefulness;
    public bool discreteDecrease;
    private float nextDecreaseTime;

    public void IncreaseWakefullness(float increase)
    {
        wakefulness = Mathf.Clamp(wakefulness + increase, 0, maxWakefulness);
    }

    public void DecreaseWakefulness(float decrease)
    {
        wakefulness = Mathf.Clamp(wakefulness - decrease, 0, maxWakefulness);
    }

    public float GetWakefulness()
    {
        return wakefulness;
    }

    private void Awake()
    {
        wakefulness = startingWakefulness;
        maxWakefulness = maxWakefulnessToSet;
        Debug.Log("Starting wakefulness " + wakefulness);
    }

    // Use this for initialization
    void Start () {
        if (discreteDecrease)
        {
            nextDecreaseTime = Time.time + 1;
        }
        
        

    }
	
	// Update is called once per frame
	void Update () {

        if (discreteDecrease)
        {
            if (Time.time > nextDecreaseTime)
            {

                DecreaseWakefulness(decreasePerSecond);
                //Debug.Log("wakefulness decreased");
                nextDecreaseTime = Time.time + 1;
                //Debug.Log("Current Wakefullness after decrease " + wakefulness);
            }
        } else
        {
            DecreaseWakefulness(decreasePerSecond * Time.deltaTime);
            //Debug.Log("Current Wakefullness after decrease " + wakefulness);
        }
        
        
        


    }
}
