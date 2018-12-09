using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Resume(){
        PlayerData.control.pause = false;
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}
