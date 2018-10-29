using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public GameObject orbitTarget;
    public float orbitSpeed;

    private Transform targetTransform;


	// Use this for initialization
	void Start ()
    {
        targetTransform = orbitTarget.GetComponent<Transform>();
        orbitSpeed = 10;
	}
	
	// Update is called once per frame
	void Update ()
    {
        OrbitAround();
	}

    void OrbitAround ()
    {
        transform.RotateAround(targetTransform.position, Vector3.up, orbitSpeed * Time.deltaTime);
    }
}
