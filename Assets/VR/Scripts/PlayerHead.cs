using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHead : MonoBehaviour {

    public Transform TrackingAnchor;

	// Use this for initialization
	void Start () {
		if (TrackingAnchor == null)
        {
            Debug.LogError("PlayerHead has no TrackingAnchor reference");
        }
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = TrackingAnchor.position;
        transform.rotation = TrackingAnchor.rotation;
	}
}
