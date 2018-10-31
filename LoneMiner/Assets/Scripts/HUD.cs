/*
 * Code by mailto:jturne48@msudenver.edu
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required to access UI components

public class HUD : MonoBehaviour {

    public GameObject hull; // Assign the appropriate HUD component to this in Unity
    public GameObject shields; // Assign the appropriate HUD component to this in Unity

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float shieldStrength = PlayerData.control.shieldStrength / PlayerData.control.maxShieldStrength * 100; // Calculates hull integrity using info from PlayerData.cs
        float hullIntegrity = PlayerData.control.hullIntegrity / PlayerData.control.maxHullIntegrity * 100; // Calculates shield strength using info from PlayerData.cs
        hull.GetComponent<Text>().text = "Hull Integrity: " + hullIntegrity + "%"; // Updates assigned text component on HUD UI
        shields.GetComponent<Text>().text = "Shield Strength: " + shieldStrength + "%"; // Updates assigned text component on HUD UI
    }

}
