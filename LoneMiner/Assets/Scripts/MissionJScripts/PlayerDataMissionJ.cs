/*
 * Original code by Adam Buckner: https://www.linkedin.com/in/adam-buckner-vfx
 * From Unity Tutorial:
 * https://unity3d.com/learn/tutorials/topics/scripting/persistence-saving-and-loading-data
 * 
 * Modified by Joe Turner: jturne48@msudenver.edu
 * 
 * Adapted from: https://unity3d.com/learn/tutorials/projects/survival-shooter/player-health?playlist=17144
 * Modified by jsaenzes@msudenver.edu
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PlayerDataMissionJ : MonoBehaviour {

    public static PlayerDataMissionJ control;

    // Player Data
    public float maxHullIntegrity;
    public float hullIntegrity;
    public float maxShieldStrength;
    public float shieldStrength;
    public float laserDamage;

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

   // public const int maxHealth = 100;
    //public int currentHealth = maxHealth;

    public void TakeDamage(int amount)
    {
        hullIntegrity -= amount;
        if (hullIntegrity <= 0)
        {
            hullIntegrity = 0;
            Debug.Log("Destroyed!");
        }

        shieldStrength -= amount;
        if (shieldStrength <= 0)
        {
            shieldStrength = 0;
            //Debug.Log("Shields down!")
        }
    }
    //void OnGUI()
    //{
    //   GUI.Label(new Rect(1, 1, 100, 20), "Shield: " + shieldStrength / maxShieldStrength * 100 + "%");
    // GUI.Label(new Rect(1, 18, 100, 20), "Hull: " + hullIntegrity / maxHullIntegrity * 100 + "%");
    //} 

}
