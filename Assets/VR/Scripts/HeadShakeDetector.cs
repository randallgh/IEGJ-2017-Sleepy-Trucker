using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadShakeDetector : MonoBehaviour {
    public float cooldownDuration = 1;
    public float samplesPerSecond = 20;
    public float rotationThreshold = 2.2f;
    public int amountOfSamples = 20;
    public List<float> RotationSamples;

    private float nextSamplingTime = 0.0f;
    private bool cooldown;
    private float cooldownEndTime;

    

	// Use this for initialization
	void Start () {

        if (amountOfSamples < 2)
        {
            Debug.LogError("HeadShakeDetector needs more than one sample");
        } else
        {
            ResetRotationSamples();
        }
        
        Debug.Log(RotationSamples.Count);
        ReadSamples();
      
	}
	
	// Update is called once per frame
	void Update () {

        if (cooldown)
        {
            if (Time.time > cooldownEndTime)
            {
                EndCooldown();
            }
        } else
        {
            if (Time.time > nextSamplingTime)
            {

                TakeSample();
                nextSamplingTime += 1 / samplesPerSecond;

                if (DetermineSampleRange() >= rotationThreshold)
                {
                    Debug.Log("SHAKING");
                    StartCooldown();
                }
            }
        }
        

		if(Input.GetKeyDown("space"))
        {
            ReadSamples();
            Debug.Log(DetermineSampleRange());
        }
	}

    void ResetRotationSamples()
    {
        RotationSamples = new List<float>();

        for (int i = 0; i < amountOfSamples; i++)
        {
            RotationSamples.Add(0);
        }
    }

    float DetermineSampleRange()
    {
        float totalDifference = 0;
        for (int i = 1; i < RotationSamples.Count; i++)
        {
            totalDifference += Mathf.Abs(RotationSamples[i] - RotationSamples[i - 1]);
        }

        return (totalDifference);
    }

    void TakeSample()
    {
        
        for (int i = 0; i < RotationSamples.Count - 1; i++)
        {
            RotationSamples[i] = RotationSamples[i + 1];
        }

        RotationSamples[RotationSamples.Count - 1] = transform.rotation.y;


    }

    void StartCooldown()
    {
        cooldown = true;
        cooldownEndTime = Time.time + cooldownDuration;
        
    }

    void EndCooldown()
    {
        ResetRotationSamples();
        cooldown = false;
    }

    void ReadSamples()
    {
        string result = "Samples [";

        for (int i = 0; i < RotationSamples.Count; i++)
        {
            result += " " + RotationSamples[i];

            if (i != RotationSamples.Count -1)
            {
                result += ",";
            }
            
        }
        result += " ]";

        Debug.Log(result);
    }


    // Just for Debugging
    public bool GetCooldown()
    {
        return cooldown;
    }


}
