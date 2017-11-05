using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObstaclePicker : MonoBehaviour {

    public GameObject[] obstacles;
    //public WakefulnessScript wakefulness;

    public GameObject currentObstacle;

    public Player player;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		if(!currentObstacle.activeInHierarchy)
        {
            while(!currentObstacle.activeInHierarchy)
            {
                int objRoll = Random.Range(0, obstacles.Length);
                if (player.GetWakefulness() <= obstacles[objRoll].GetComponent<ObstacleScript>().maxWakefulness)
                {
                    //currentObstacle = Instantiate(obstacles[objRoll]);

                    int realRoll = Random.Range(1, 101);
                    if (realRoll > player.GetWakefulness() + currentObstacle.GetComponent<ObstacleScript>().realChanceMod)
                    {
                        Destroy(currentObstacle.GetComponent<Collider>());
                    }

                    currentObstacle.SetActive(true);
                    currentObstacle.transform.position = new Vector3(currentObstacle.transform.position.x, currentObstacle.transform.position.y, 250);
                    //Set the initial position
                    //SSet the object 
                }
            }
        }

        //update the position of the obstacle
        //This will be updated in the worldController

        //if the obstacle is beyond a certain point, get rid of it
	}
}
