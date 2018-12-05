/* https://docs.unity3d.com/ScriptReference/Application.LoadLevelAdditive.html
 * Core code from https://www.youtube.com/watch?v=Drb61_C8-SQ
 * Modified:
 * Pete Fennell version 10202018
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallPauseScene : MonoBehaviour {

    private bool pause;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!PlayerData.control.pause)
            {
                PlayerData.control.pause = true;
                Time.timeScale = 0;
                Application.LoadLevelAdditive("pauseMenu");
                //Application.LoadLevelAdditive(3);
            }
        }
		
	}
}
