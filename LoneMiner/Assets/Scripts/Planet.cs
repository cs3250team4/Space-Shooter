// Code by Joe Turner jturne48@msudenver.edu

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public Transform centerOfMass;
    public float rotateSpeed;
    public float rotateAroundSpeed; 

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
        if (centerOfMass != null) {
            transform.RotateAround(centerOfMass.transform.position, centerOfMass.transform.up, Time.deltaTime * rotateAroundSpeed);
        }

    }
}
