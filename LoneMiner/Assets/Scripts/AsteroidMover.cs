/*
 * Original code by Adam Buckner https://www.linkedin.com/in/adam-buckner-vfx
 * From Unity Tutorial:
 * https://unity3d.com/learn/tutorials/projects/space-shooter-tutorial/explosions?playlist=17147
 * 
 * Updated by Joe Turner mailto:jturne48@msudenver.edu
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMover : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
