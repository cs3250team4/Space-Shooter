// Code by Joe Turner jturne48@msudenver.edu

using UnityEngine;
using System.Collections;

public class OW_PlayerControl : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSpeed = 100f;
    private Rigidbody rb;

    void Start()
    {
        // get player's rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // if up key, move forward
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        // if down key move backward
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime);
        // if left key rotate counter-clockwise
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            transform.Rotate(-Vector3.up, turnSpeed * Time.deltaTime);
        // if right key rotate clockwise
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        // update player position in overworld data for presisting between scenes
        OW_Data.owc.playerPosition = rb.transform.position;
        // update player rotation in overworld data for presisting between scenes
        OW_Data.owc.playerRotation = rb.transform.rotation;
    }
}