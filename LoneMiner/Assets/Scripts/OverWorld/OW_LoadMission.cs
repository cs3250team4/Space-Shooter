// Code by Joe Turner jturne48@msudenver.edu

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OW_LoadMission : MonoBehaviour {

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
