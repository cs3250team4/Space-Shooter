/*
 * Original code by Adam Buckner https://www.linkedin.com/in/adam-buckner-vfx
 * From Unity Tutorials:
 * https://unity3d.com/learn/tutorials/projects/space-shooter-tutorial/creating-hazards?playlist=17147
 * 
 * Updated by Joe Turner mailto:jturne48@msudenver.edu
 */

using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }
}
