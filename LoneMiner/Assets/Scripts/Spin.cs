using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float speed;

	// Use this for initialization
	void Start ()
    {
        speed = 1f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
	}
}
