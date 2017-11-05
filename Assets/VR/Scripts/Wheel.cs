using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour, Grabbable {

    private bool highlighted;
    private int triggersActive;
    private List<Hand> HandsTouching = new List<Hand>();
    private List<Hand> HandsHolding = new List<Hand>();
    private bool held;
    

    // Debug only
    public Material yellow;
    public Material red;
    public Material white;
    public GameObject WheelMesh;
    private Renderer rend;

   

	// Use this for initialization
	void Start () {



        // Debug only
        if (WheelMesh != null)
        rend = WheelMesh.GetComponent<Renderer>();
        rend.material = white;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CheckForGrabbing()
    {
        for (int i = 0; i < HandsTouching.Count; i++)
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {
            Hand incomingHand = other.gameObject.GetComponent<Hand>();
            if (!HandsTouching.Contains(incomingHand))
            {
                HandsTouching.Add(incomingHand);
            }

            incomingHand.SetGrabbableObject(gameObject);

            Debug.Log("Entered one of the wheel's triggers");
            triggersActive++;

            if (triggersActive > 0)
            {
                if (!highlighted)
                {
                    
                    Highlight();
                }
            }
        }
        
        
    }

    private void OnTriggerExit(Collider other)
    {
        Hand departingHand = other.gameObject.GetComponent<Hand>();

        if (HandsTouching.Contains(departingHand))
        {
            HandsTouching.Remove(departingHand);
        }

        if (other.CompareTag("Player"))
        {
            Debug.Log("Exited a wheel trigger");
            triggersActive--;

            if (triggersActive < 1)
            {
                if (highlighted)
                {
                    Dehighlight();
                }
            }
        }
    }

    void Highlight()
    {
        highlighted = true;
        rend.material = yellow;
    }

    void Dehighlight()
    {
        highlighted = false;
        rend.material = white;
    }

    public void GetGrabbed(Hand grabberHand)
    {
        if (highlighted && HandsTouching.Contains(grabberHand))
        {
            grabberHand.StartSteering(gameObject);
            HandsHolding.Add(grabberHand);
            grabberHand.transform.SetParent(transform.parent); //exp
            if (!held)
            {
                BecomeHeld();
            }
        }
    }

    public void GetDropped(Hand dropperHand)
    {
        Debug.Log("GettingDropped");
        dropperHand.StopSteering();
        HandsHolding.Remove(dropperHand);
        if (HandsHolding.Count == 0)
        {
            BecomeUnheld();
        }
    }

    public void AdjustAngleBy(float Adjustment)
    {
        transform.Rotate(0, 0, Adjustment);
    }

    private void BecomeHeld()
    {
        held = true;
        rend.material = red;
    }

    private void BecomeUnheld()
    {
        held = false;
        if (highlighted)
        {
            rend.material = yellow;
        } else
        {
            rend.material = white;
        }
    }

    
}
