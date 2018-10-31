using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallPauseScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            Application.LoadLevelAdditive(4);

        }
		
	}
}
