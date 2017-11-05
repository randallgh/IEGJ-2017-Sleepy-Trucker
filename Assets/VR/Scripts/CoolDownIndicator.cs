using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolDownIndicator : MonoBehaviour {
    public HeadShakeDetector shakeDetector;
    public Material green;
    public Material red;

    private Renderer rend;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (shakeDetector.GetCooldown())
        {
            rend.material = red;
        } else
        {
            rend.material = green;
        }
	}
}
