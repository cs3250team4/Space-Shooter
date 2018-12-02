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
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour {

    public static PlayerData control;

    // Player Data
    public float maxHullIntegrity;
    public float hullIntegrity;
    public float maxShieldStrength;
    public float shieldStrength;
    public float laserDamage;
    private Scene currentScene;
    private string sceneName;
    private ExploreModeRadiation radiationController;


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

    private void Start()
    {
        radiationController = FindObjectOfType<ExploreModeRadiation>();
    }

    private void Update()
    {
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        if (sceneName == "ExploreMode2D" && shieldStrength < maxShieldStrength)
        {
            if(!radiationController.radiation)
            {
                shieldStrength++;
            }
        }
    }
}
