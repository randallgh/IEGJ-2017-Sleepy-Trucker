using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slapper : MonoBehaviour {

    public Player player;

    public float cooldownDuration = 1;
    public float samplesPerSecond = 50;
    public float velocityThreshold = 0.4f;
    public int amountOfSamples = 10;
    public List<float> DistanceSamples;
    public float proximityThreshold = 0.3f;

    private float nextSamplingTime = 0.0f;
    private bool cooldown;
    private float cooldownEndTime;


    public Transform TrackingAnchor;
    private float distanceToAnchor;

	// Use this for initialization
	void Start () {
        if (amountOfSamples < 2)
        {
            Debug.LogError("HeadShakeDetector needs more than one sample");
        }
        else
        {
            ResetDistanceSamples();
        }

        Debug.Log(DistanceSamples.Count);
        ReadSamples();
    }

    

    // Update is called once per frame
    void Update () {
        distanceToAnchor = Vector3.Distance(transform.position, TrackingAnchor.position);

        if (cooldown)
        {
            if (Time.time > cooldownEndTime)
            {
                EndCooldown();
            }
        }
        else
        {
            if (Time.time > nextSamplingTime)
            {

                TakeSample();
                nextSamplingTime += 1 / samplesPerSecond;
                
            }

            if (distanceToAnchor < proximityThreshold)
            {
                if (CheckVelocity())
                {
                    player.IncreaseWakefullness(10);
                    Debug.Log("SLAP!");
                    StartCooldown();
                }
            }
        }

        //Debug.Log(distanceToAnchor);
	}

    bool CheckVelocity()
    {
        if (DetermineVelocity() >= velocityThreshold)
        {
            return true;
            //Debug.Log("FAST");
            
        } else
        {
            return false;
        }
    }

    void EndCooldown()
    {
        ResetDistanceSamples();
        cooldown = false;
    }

    float DetermineVelocity()
    {
        float totalDistanceCovered = 0;

        float min = DistanceSamples[0];
        float max = DistanceSamples[0];

        for (int i = 1; i < DistanceSamples.Count; i++)
        {
            if (DistanceSamples[i] < min)
            {
                min = DistanceSamples[i];
            }

            if (DistanceSamples[i] > max)
            {
                max = DistanceSamples[i];
            }
        }

        totalDistanceCovered = max - min;

        //Debug.Log(totalDistanceCovered);
        return (totalDistanceCovered);
    }

    void StartCooldown()
    {
        cooldown = true;
        cooldownEndTime = Time.time + cooldownDuration;
    }

    void TakeSample()
    {

        for (int i = 0; i < DistanceSamples.Count - 1; i++)
        {
            DistanceSamples[i] = DistanceSamples[i + 1];
        }

        DistanceSamples[DistanceSamples.Count - 1] = distanceToAnchor;


    }

    void ReadSamples()
    {
        string result = "Samples [";

        for (int i = 0; i < DistanceSamples.Count; i++)
        {
            result += " " + DistanceSamples[i];

            if (i != DistanceSamples.Count - 1)
            {
                result += ",";
            }

        }
        result += " ]";

        Debug.Log(result);
    }

    void ResetDistanceSamples()
    {
        DistanceSamples = new List<float>();

        for (int i = 0; i < amountOfSamples; i++)
        {
            DistanceSamples.Add(0);
        }
    }
}
