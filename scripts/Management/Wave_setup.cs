using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Starts and sets up the wave-system
//Still needs much work

public class Wave_setup : MonoBehaviour {

    public GameObject circling;
    private Wave_system ws;

	// Use this for initialization
	void Start () {
        ws = new Wave_system(5, circling, 7);
    }

    // Update is called once per frame
    void Update () {

        if(Input.GetKeyDown(KeyCode.O))
        {
            ws.ready = true;
            ws.nextWave();
        }
	}
}
