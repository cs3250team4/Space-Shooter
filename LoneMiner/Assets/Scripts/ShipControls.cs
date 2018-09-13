 /* 
  * ShipControls
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
  */
using UnityEngine;

public class ShipControls : MonoBehaviour
{
    public float thrust;                // forward or backwards force being applied
    public float rotateThrust;          // rotational force being applied

    private float thrustInput;          // keyboard input for thrust
    private float rotateInput;          // keyboard input for rotational thrust
    private Rigidbody rb;               // Rigidbody component of player's ship
    private Vector3 eulerAngleVelocity; // Euler angle velocity of ship

    /*
     * Initialization
     */
    void Start () {
        // Get the Rigidbody component of player's ship
        rb = GetComponent<Rigidbody>();

        // Prevent positional movement along Y-axis and rotational movement along X-axis & Z-axis
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
	}


    /*
     * Update is called once per frame
     */
    void Update()
    {
        //Check for keyboard input.
        thrustInput = Input.GetAxis("Vertical");
        rotateInput = Input.GetAxis("Horizontal");
        
        // Add forward thrust to ships velocity vector
        rb.AddRelativeForce(Vector3.forward * thrustInput * thrust);

        // Calculate eular angle velocity
        eulerAngleVelocity = new Vector3(0.0f, rotateInput * rotateThrust, 0.0f);

        // Calculate change in rotation for time since last frame
        Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity * Time.deltaTime);

        // Rotate the ship's Rigidbody
        rb.MoveRotation(rb.rotation * deltaRotation);
        
        // Check if the player's ship has angular velocity on the y axis
        if (rb.angularVelocity.y > 0)
        { // Wait until the user rotates the ship
            if (rotateInput != 0)
            {  // Set angular velocity to 0 for X, Y, and Z axis
                rb.angularVelocity = new Vector3(0.0f, 0.0f, 0.0f);
            }
        }
    }
}
