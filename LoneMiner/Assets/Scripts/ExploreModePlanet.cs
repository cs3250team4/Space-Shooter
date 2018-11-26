// Code by Joe Turner jturne48@msudenver.edu

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploreModePlanet : MonoBehaviour
{
    // variable for the object to rotate around (set in Unit editor)
    public Transform centerOfMass;
    // speed at which to rotate the planet (set in Unit editor)
    public float rotateSpeed;
    // speed at which to rotate around the center of mass object (set in Unit editor)
    public float rotateAroundSpeed;
    // for planet's rigidbody component
    private Rigidbody rb;

    //
    void Start()
    {
        // get planet's rigidbody component
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionY;
    }

    private void Update()
    {
        // rotate the planet
        transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
        // if there is an object to rotate around (set in Unit editor)
        if (centerOfMass != null)
        {
            // rotate around the center of mass
            transform.RotateAround(centerOfMass.transform.position, Vector3.up, Time.deltaTime * rotateAroundSpeed);
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        int index = -1;
        for (int i = 0; i < ExploreModeData.data.planetPositions.Length; i++)
        {
            if (ExploreModeData.data.planetNames[i] == this.name)
            {
                index = i;
            }
        }
        if (index > -1)
        {
            ExploreModeData.data.planetPositions[index] = rb.transform.position;
            ExploreModeData.data.planetRotations[index] = rb.transform.rotation;
        }
    }
}
