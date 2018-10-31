using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float spinSpeed;

	// Use this for initialization
	void Start ()
    {
        spinSpeed = 1f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
	}
}
