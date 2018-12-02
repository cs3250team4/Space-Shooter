// Code by Joe Turner jturne48@msudenver.edu

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OW_Data : MonoBehaviour
{
    // the static class
    public static OW_Data owc;

    // overworld player variables
    public Vector3 playerPosition;
    public Quaternion playerRotation;

    //overworld planet variables
    public GameObject[] planets;
    public string[] planetNames;
    public Vector3[] planetPositions;
    public Quaternion[] planetRotations;

    void Awake()
    {
        if (owc == null)
        {
            DontDestroyOnLoad(gameObject);
            owc = this;
        }
        else if (owc != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
            GameObject player = GameObject.Find("OW_Player");
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
        // if the overworld player is present in the scene (meaning we are in the overworld)
        // this code persists through all scenes but we don't want this to happen in scenes other than the overworld
        if (GameObject.Find("OW_Player"))
        {
            GameObject player = GameObject.Find("OW_Player");
            if (playerPosition != null)
            {
                player.GetComponent<Rigidbody>().transform.position = playerPosition;
            }
            if (playerRotation != null)
            {
                player.GetComponent<Rigidbody>().transform.rotation = playerRotation;
            }
        }

        for(int i = 0; i < planetNames.Length; i++)
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
