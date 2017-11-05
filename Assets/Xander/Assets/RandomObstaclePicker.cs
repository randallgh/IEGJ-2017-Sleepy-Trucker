using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObstaclePicker : MonoBehaviour {

    public GameObject[] obstacles;
    //public WakefulnessScript wakefulness;

    private GameObject currentObstacle;

	// Use this for initialization
	void Start () {
        currentObstacle = null;

    }
	
	// Update is called once per frame
	void Update () {
		if(currentObstacle == null)
        {
            while(currentObstacle == null)
            {
                int objRoll = Random.Range(0, obstacles.Length);
                //if(wakefulness.wakefulness <= obstacles[objRoll].GetComponent<ObstacleScript>().maxWakefulness)
                //{
                //    currentObstacle = Instantiate(obstacles[objRoll]);

                //    int realRoll = Random.Range(1, 101);
                //    if(realRoll > wakefulness.wakefulness + currentObstacle.GetComponent<ObstacleScript>().realChanceMod)
                //    {
                //        Destroy(currentObstacle.GetComponent<Collider>());
                //    }

                //    //Set the initial position
                //}
            }
        }

        //update the position of the obstacle

        //if the obstacle is beyond a certain point, get rid of it
	}
}
