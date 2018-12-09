﻿/* 
 * ExploreModePlayerControls
 * 
 * Adapted from ShipControls.cs
 * - added:
 *    - slow down after no input (Ken Berry)
 *    - 
 * 
 * 
 * Allows user to control the player ship
 * when added as a component of the "Player" GameObject
 * 
 * Controls:
 *     forward      -  W or Up-arrow
 *     backward     -  S or Down-arrow
 *     rotate left  -  A or Left-arrow
 *     rotate right -  D or Right-arrow
 * 
 * Author(s):  David Habinsky
 *             Kenneth Berry
 *             Joe Turner
 */
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExploreModePlayerControls : MonoBehaviour
{
    // static player class
    public static ExploreModePlayerControls player;

    public float thrust;                // forward or backwards force being applied
    public float rotateThrust;          // rotational force being applied
    public float maxVelocity;           // maximum velocity of ship
    private float thrustInput;          // keyboard input for thrust
    private float rotateInput;          // keyboard input for rotational thrust
    public Rigidbody rb;               // Rigidbody component of player's ship
    public Vector3 eulerAngleVelocity; // Euler angle velocity of ship
    public Quaternion deltaRotation;
    public bool visible;

    void Awake()
    {
        if (player == null)
        {
            DontDestroyOnLoad(gameObject);
            player = this;
        }
        else if (player != this)
        {
            Destroy(gameObject);
        }
    }

    /*
     * Initialization
     */
    void Start()
    {
        // Get the Rigidbody component of player's ship
        rb = GetComponent<Rigidbody>();

        // Prevent positional movement along Y-axis and rotational movement along X-axis & Z-axis
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        // Set initial thrust multiplier
        thrust = 1;

        // Set maximum velocity
        maxVelocity = 5;

        visible = true;
    }

    /*
     * Update is called once per frame
     */
    private void FixedUpdate()
    {
        //Check for keyboard input.
        thrustInput = Input.GetAxis("Vertical");
        rotateInput = Input.GetAxis("Horizontal");
   
        // Check for thrust input
        if (thrustInput != 0)
        {  // Check if ship's velocity is less than max velocity
            if (rb.velocity.magnitude <= maxVelocity)
            {  // Add thrust to ship's velocity
                rb.AddRelativeForce(Vector3.forward * thrustInput * thrust);
            }
        }
        else  // there is no thrust input
        {  // Check if ship's velocity is greater than 0.1
            if (rb.velocity.magnitude > 0.1f)
            {  // Decrease the ship's velocity if greater than 0.1
                rb.velocity = rb.velocity * 0.99f;
            }
            else  // Velocity is greater than 0.1
            {  // Set velocity to zero
                rb.velocity = Vector3.zero;
            }
        }
   
        // Calculate eular angle velocity
        eulerAngleVelocity = new Vector3(0.0f, rotateInput * rotateThrust, 0.0f);

        // Calculate change in rotation for time since last frame
        deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);

        // Rotate the ship's Rigidbody
        rb.MoveRotation(rb.rotation * deltaRotation);

        // Check if the player's ship has angular velocity on the y axis
        if (rb.angularVelocity.y != 0)
        { // Wait until the user rotates the ship
            if (rotateInput != 0)
            {  // Set angular velocity to 0 for X, Y, and Z axis
                rb.angularVelocity = new Vector3(0.0f, 0.0f, 0.0f);
            }
        }
    }

    private void LateUpdate()
    {
        // update player thrust in ExploreModeData
        ExploreModeData.data.thrust = thrust;
        // update player rotational thrust in ExploreModeData
        ExploreModeData.data.rotateThrust = rotateThrust;
        // update player position in ExploreModeData 
        ExploreModeData.data.playerPosition = rb.transform.position;
        // update player rotation in ExploreModeData 
        ExploreModeData.data.playerRotation = rb.transform.rotation;
        // update player position in ExploreModeData 
        ExploreModeData.data.playerEulerAngleVelocity = eulerAngleVelocity;
        // update player rotation in ExploreModeData 
        ExploreModeData.data.playerDeltaRotation = deltaRotation;
    }
}

