/**
 * ExploreModeData
 * 
 * stores data for objects in explore mode
 * so that the data can be restored after
 * returning to explore mode from a mission.
 **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploreModeData : MonoBehaviour
{
    // the static class
    private static ExploreModeData data;

    // explore mode player variables
    private Vector3 playerPosition;
    private Quaternion playerRotation;

    // explore mode planet array
    public GameObject[] planets;
    private string[] planetNames;
    private Vector3[] planetPositions;
    private Quaternion[] planetRotations;

    void Awake()
    {
        if (data == null)
        {
            DontDestroyOnLoad(gameObject);
            data = this;
        }
        else if (data != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        GameObject player = GameObject.Find("ExploreMode_Player");
        playerPosition = player.GetComponent<Rigidbody>().transform.position;
        playerRotation = player.GetComponent<Rigidbody>().transform.rotation;

        planetNames = new string[planets.Length];
        planetPositions = new Vector3[planets.Length];
        planetRotations = new Quaternion[planets.Length];
        foreach (GameObject planet in planets)
            for (int i = 0; i < planets.Length; i++)
            {
                Rigidbody rb = planets[i].GetComponent<Rigidbody>();
                planetNames[i] = planets[i].name;
                planetPositions[i] = rb.position;
                planetRotations[i] = rb.rotation;
            }
    }

    void FixedUpdate()
    {
        // if the explore mode player is present in the scene (meaning we are in the explore mode)
        // this code persists through all scenes but we don't want this to happen in scenes other than the overworld
        if (GameObject.Find("ExploreMode_Player"))
        {
            GameObject player = GameObject.Find("ExploreMode_Player");
            if (playerPosition != null)
            {
                player.GetComponent<Rigidbody>().transform.position = playerPosition;
            }
            if (playerRotation != null)
            {
                player.GetComponent<Rigidbody>().transform.rotation = playerRotation;
            }
        }

        for (int i = 0; i < planetNames.Length; i++)
        {
            if (GameObject.Find(planetNames[i]))
            {
                GameObject p = GameObject.Find(planetNames[i]);
                Rigidbody rb = p.GetComponent<Rigidbody>();
                rb.transform.position = planetPositions[i];
                rb.transform.rotation = planetRotations[i];
            }
        }
    }
}
