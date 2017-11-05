using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Grabbable
{
    void GetGrabbed(Hand grabberHand);
    void GetDropped(Hand dropperHand);
}

public enum PlayerHand
{
    left, right
}

public class Hand : MonoBehaviour {
    
    public PlayerHand thisHand;
    public Transform TrackingAnchor;
    private OVRInput.Controller relevantController;
    private bool clenched;
    private Transform originalParent; //exp

    private bool steering; // When steering, the movement is restricted to a radius
    private GameObject SteeredWheel;

    private Grabbable GrabbableObject;
    private Grabbable HeldObject;

    public Transform WheelSpace;
    //Debug only
    public GameObject HandCube;
    public Material green;
    public Material red;
    private Renderer rend;

    public Transform GhostCube; // For Debugging the controllerPositions


    private float wheelAngleAtSteeringStart;



    public void SetGrabbableObject(GameObject NewGrabbableGO)
    {
        GrabbableObject = NewGrabbableGO.GetComponent<Grabbable>();
    }

    public void RemoveGrabbableObject()
    {
        GrabbableObject = null;
    }
    

	// Use this for initialization
	void Start () {
		if (TrackingAnchor == null)
        {
            Debug.LogError("Hand needs a trackingAnchor reference");
        }

        originalParent = transform.parent; //exp

        if (thisHand == PlayerHand.left)
        {
            relevantController = OVRInput.Controller.LTouch;
        } else if (thisHand == PlayerHand.right) {
            relevantController = OVRInput.Controller.RTouch;
        }

        // Debug only
        rend = HandCube.GetComponent<Renderer>();
        rend.material = green;
	}
	
	// Update is called once per frame
	void Update () {

        //GhostCube.position = TrackingAnchor.position;
        //GhostCube.rotation = TrackingAnchor.rotation;


        if (!steering)
        {
            transform.position = TrackingAnchor.position;
            transform.rotation = TrackingAnchor.rotation;
        } else
        {
            ProcessSteering();
        }
        

        if (!clenched)
        {
            if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, relevantController))
            {
                Clench();
                Debug.Log("CLENCHING " + thisHand);
            }

        } else {

            if (!OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, relevantController))
            {
                Unclench();
            }
        }
       
	}

    void ProcessSteering()
    {
        Vector3 handPos = TrackingAnchor.position;
        Vector3 flattenedPos = new Vector3(handPos.x, handPos.y, SteeredWheel.transform.position.z);
        Vector3 directionVector = flattenedPos - SteeredWheel.transform.position;

        float angle = Vector3.Angle(directionVector, transform.parent.up);
        float otherAngle = Vector3.Angle(directionVector, Vector3.up);

        Debug.Log("Angle is " + angle + " and other angle is " + otherAngle);
        if (handPos.x < SteeredWheel.transform.position.x)
        {
            angle = 360 - angle;
        }

        Debug.Log(" " + angle + " which means we move by " + (angle - wheelAngleAtSteeringStart));

        float angleAdjustment = angle - wheelAngleAtSteeringStart;

        //SteeredWheel.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angle);

        //WheelSpace.transform.rotation = Quaternion.Euler(WheelSpace.transform.rotation.x, WheelSpace.transform.rotation.y, -(angle - wheelAngleAtSteeringStart));

        SteeredWheel.transform.rotation = Quaternion.Euler(SteeredWheel.transform.rotation.x, 0, - angleAdjustment);

        

        //GhostCube.position = directionVector.normalized * .5f;
    }

    void Clench()
    {
        clenched = true;

        if (GrabbableObject != null)
        {
            HeldObject = GrabbableObject;
            GrabbableObject.GetGrabbed(this);

        }

        // Debug only
        rend.material = red;
    }

    void Unclench()
    {
        clenched = false;
        if (HeldObject != null)
        {
            HeldObject.GetDropped(this);
            HeldObject = null;
        }
        // Debug only
        rend.material = green;
    }

    public void StartSteering(GameObject WheelGO)
    {
        //transform.SetParent(WheelGO.transform);
        HandCube.transform.SetParent(WheelGO.transform);
        steering = true;
        SteeredWheel = WheelGO;

        Vector3 handPos = TrackingAnchor.position;
        Vector3 flattenedPos = new Vector3(handPos.x, handPos.y, SteeredWheel.transform.position.z);
        Vector3 directionVector = flattenedPos - SteeredWheel.transform.position;

        wheelAngleAtSteeringStart = Vector3.Angle(directionVector, transform.parent.up); // This relies on the hand being child to wheelSpace atm
        if (handPos.x < SteeredWheel.transform.position.x)
        {
            wheelAngleAtSteeringStart = 360 - wheelAngleAtSteeringStart;
        }
    }

    public void StopSteering()
    {
        HandCube.transform.position = transform.position;
        HandCube.transform.rotation = transform.rotation;
        HandCube.transform.SetParent(transform); //exp
        steering = false;
        SteeredWheel = null;
    }
}
