using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour {

    public float worldSpeed = 1;

    public GameObject currentObstacle;
    public GameObject[] roadTiles = new GameObject[27];

    // Use this for initialization
    void Start ()
    {
		for (int i = 0; i < roadTiles.Length; i++)
        {
            roadTiles = GameObject.FindGameObjectsWithTag("Road");
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        for (int i = 0; i < roadTiles.Length; i++)
        {
            roadTiles[i].transform.position += new Vector3(0,0, -worldSpeed);
            if (roadTiles[i].transform.position.z <= -260)
            {
                Vector3 pos = roadTiles[i].transform.position;
                pos.z = 240;
                roadTiles[i].transform.position = pos;
            }
        }

        if (currentObstacle != null && currentObstacle.transform.position.z <= -240)
        {
            Destroy(currentObstacle);
        }
        else if (currentObstacle != null)
        {
            currentObstacle.transform.position += new Vector3(0, 0, -worldSpeed);
        }

    }

    public void setCurrentObstacle(GameObject thing)
    {
        currentObstacle = thing;
    }
}
