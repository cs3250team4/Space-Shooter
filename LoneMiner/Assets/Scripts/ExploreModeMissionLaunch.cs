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
    private GameObject player;

    // variable to hold name of scene to load
    // set this ini Unity editor
    public string scene;

    private void Start()
    {
        player = GameObject.Find("ExploreMode_Player");
        player.GetComponent<MeshRenderer>().enabled = true;
        foreach (Transform t in player.GetComponentsInChildren<Transform>())
            foreach(Renderer r in t.GetComponentsInChildren<Renderer>())
                r.enabled = true;
    }

    // called on (left) mouse click
    void OnMouseDown()
    {
        if (scene != null)
        {
            // make static ExploreMode_Player class invisible
            player.GetComponent<MeshRenderer>().enabled = false;
            foreach (Transform t in player.GetComponentsInChildren<Transform>())
                foreach (Renderer r in t.GetComponentsInChildren<Renderer>())
                    r.enabled = false;

            // load the scene
            SceneManager.LoadScene(scene);
        }
    }
}
