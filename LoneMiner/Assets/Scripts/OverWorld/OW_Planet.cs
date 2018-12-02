// Code by Joe Turner jturne48@msudenver.edu

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OW_Planet : MonoBehaviour
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
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // rotate the planet
        transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
        // if there is an object to rotate around (set in Unit editor)
        if (centerOfMass != null)
        {
            // rotate around the center of mass
            transform.RotateAround(centerOfMass.transform.position, Vector3.forward, Time.deltaTime * rotateAroundSpeed);
        }
        int index = -1;
        for (int i = 0; i < OW_Data.owc.planetPositions.Length; i++)
        {
            if(OW_Data.owc.planetNames[i] == this.name)
            {
                index = i;
            }
        }
        if (index > -1)
        {
            OW_Data.owc.planetPositions[index] = rb.transform.position;
            OW_Data.owc.planetRotations[index] = rb.transform.rotation;
        }
    }
}
