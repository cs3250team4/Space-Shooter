/*
 * Original code by Adam Buckner: https://www.linkedin.com/in/adam-buckner-vfx
 * From Unity Tutorial:
 * https://unity3d.com/learn/tutorials/topics/scripting/persistence-saving-and-loading-data
 * 
 * Modified by Joe Turner: jturne48@msudenver.edu
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PlayerData : MonoBehaviour {

    public static PlayerData control;

    // Player Data
    public float maxHullIntegrity;
    public float hullIntegrity;
    public float maxShieldStrength;
    public float shieldStrength;

    void Awake()
    {
        if(control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if(control != this)
        {
            Destroy(gameObject);
        }
    }

	// Use this for initialization
	void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        GUI.Label(new Rect(1, 1, 100, 20), "Shield: " + shieldStrength / maxShieldStrength * 100 + "%");
        GUI.Label(new Rect(1, 18, 100, 20), "Hull: " + hullIntegrity / maxHullIntegrity * 100 + "%");
    }
}
