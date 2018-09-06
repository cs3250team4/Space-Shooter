using UnityEngine;
using System.Collections;

public class BasicFollowCam : MonoBehaviour
{
    private GameObject player; // reference to the player game object
    private Vector3 offset; // offset distance between the player and camera

    // initialization
    void Start()
    {
        // get Player object in scene
        player = GameObject.Find("Player");

        // Calculate and store the offset value by getting the distance
        // between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as
        // the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
    }
}
