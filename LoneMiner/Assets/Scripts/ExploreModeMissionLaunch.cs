/**
 * ExploreModeMissionLaunch
 * 
 * launches missions in Explore Mode
 **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExploreModeMissionLaunch : MonoBehaviour
{

    // variable to hold name of scene to load
    // set this ini Unity editor
    public string scene;

    // called on (left) mouse click
    void OnMouseDown()
    {
        if (scene != null)
        {
            // load the scene
            SceneManager.LoadScene(scene);
        }
    }
}
