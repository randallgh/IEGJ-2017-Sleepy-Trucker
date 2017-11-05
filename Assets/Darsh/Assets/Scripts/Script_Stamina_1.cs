using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Stamina_1 : MonoBehaviour {

    public float stamina = 100;
	
	// Update is called once per frame
	void Update () {
        stamina = stamina - Time.deltaTime;

        Debug.Log(stamina);

    }

}
