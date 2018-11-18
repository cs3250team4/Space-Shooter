/* 
 * ExploreModePlayerControls
 * 
 * Adapted from ShipControls.cs
 * - added Radiation particle system control
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

public class ExploreModePlayerControls : MonoBehaviour
{
    public float thrust;                // forward or backwards force being applied
    public float rotateThrust;          // rotational force being applied
    public float maxVelocity;           // maximum velocity of ship
    public float maxDistance;           // maximum distance the ship can travel before radiation damage

    private ParticleSystem radiation;   // radiation particle system of player's ship
    private float thrustInput;          // keyboard input for thrust
    private float rotateInput;          // keyboard input for rotational thrust
    private Rigidbody rb;               // Rigidbody component of player's ship
    private Vector3 eulerAngleVelocity; // Euler angle velocity of ship

    /*
     * Initialization
     */
    void Start()
    {
        // Get the Radiation particle system for the player's ship
        radiation = transform.GetChild(0).GetComponent<ParticleSystem>();
        radiation.Stop();

        // Get the Rigidbody component of player's ship
        rb = GetComponent<Rigidbody>();

        // Prevent positional movement along Y-axis and rotational movement along X-axis & Z-axis
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

        // Set initial thrust multiplier
        thrust = 1;

        // Set maximum velocity
        maxVelocity = 5;
    }


    /*
     * Update is called once per frame
     */
    void Update()
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
        Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);

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

        if(transform.position.x > maxDistance
                || transform.position.x < -maxDistance
                || transform.position.z > maxDistance
                || transform.position.z < -maxDistance)
        {
            radiation.Play();
        }
        else if(radiation.isPlaying)
        {
            radiation.Stop();
        }
        // update player position in ExploreModeData for presisting between scenes
        ExploreModeData.data.playerPosition = rb.transform.position;
        // update player rotation in ExploreModeData for presisting between scenes
        ExploreModeData.data.playerRotation = rb.transform.rotation;
    }
}
