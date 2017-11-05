using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObstaclePicker : MonoBehaviour {

    public GameObject[] obstacles = new GameObject[4];
    //public WakefulnessScript wakefulness;

    private GameObject currentObstacle;
    private WorldController world;

    public Player player;

	// Use this for initialization
	void Start ()
    {
        world = GetComponent<WorldController>();
    }
	
	// Update is called once per frame
	void Update () {
		if(currentObstacle == null)
        {
            while(currentObstacle == null)
            {
                int objRoll = Random.Range(0, obstacles.Length);
                if (player.GetWakefulness() <= obstacles[objRoll].GetComponent<ObstacleScript>().maxWakefulness)
                {
                    currentObstacle = Instantiate(obstacles[objRoll]);
                    currentObstacle.transform.position = new Vector3(Random.Range(-7,7), currentObstacle.transform.position.y, 250);
                    
                    int realRoll = Random.Range(1, 101);

                    if (realRoll > player.GetWakefulness() + currentObstacle.GetComponent<ObstacleScript>().realChanceMod)
                    {
                        Destroy(currentObstacle.GetComponent<Collider>());
                    }

                    world.setCurrentObstacle(currentObstacle);
                    //Set the initial position
                    //SSet the object 
                }
            }
        }

        //update the position of the obstacle
        //This will be updated in the worldController

        if ( player.GetWakefulness() >= currentObstacle.GetComponent<ObstacleScript>().visibilityCap)
        {
            Destroy(currentObstacle);
        }

        //if the obstacle is beyond a certain point, get rid of it
        //Done in world controlelr
	}
}
