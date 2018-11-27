/*
 * ExploreModeCamera
 * 
 * A basic follow camera script that allows the camera to follow
 * the GameObject named "Player".  Needs to be added as a component
 * to the main scene camera.
 * 
 * Follows horizontal and verticle movements of "Player GameObject
 * but does not rotate along with player.
 * 
 * Author(s):   Kenneth Berry
 */

using UnityEngine;

public class ExploreModeCamera : MonoBehaviour
{
    public int height;
    private GameObject player;  // reference to the player game object
    private Vector3 offset;     // offset distance between the player and camera

    /*
     * Initialization
     */
    void Start()
    {
        // Find "Player" GameObject in scene
        player = GameObject.Find("ExploreMode_Player");
        offset = Vector3.up * height;
    }

    /*
     * LateUpdate is called after Update each frame
     */
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as
        // the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
    }
}
