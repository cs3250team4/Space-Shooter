using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * authors: Asbjorn Thirslund (tutorial), David Habinsky
 * 
 */

public class CameraFollow : MonoBehaviour {


    public Transform target;  // for positioning camera based  on ship position using empty game object as child to player.
    public Transform looking; // another transform just to look at the ship or player directly.

    public float smoothSpeed = 10f;
    public Vector3 offset;

    void FixedUpdate()
    {

        /* potential option of using offset to constantly adjust the camera angle as the ship rotates around sphere.
        offset.x = target.rotation.y * 2;
        offset.y = target.rotation.y * 5;
        Vector3 desiredPosition = target.position + offset;
        */
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, target.position, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        transform.LookAt(looking);
    }
}
