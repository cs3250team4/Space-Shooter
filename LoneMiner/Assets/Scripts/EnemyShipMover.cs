using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyBoundary
{
    public float xMin, xMax;
}

public class EnemyShipMover : MonoBehaviour {

    public float horizontalSpeed;
    public float verticalSpeed;    
    public float tilt;
    public EnemyBoundary boundary;
    private Rigidbody rb;
<<<<<<< HEAD
    //private AudioSource audioSource;    
=======
    private AudioSource audioSource;    
>>>>>>> MissionTesting

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
<<<<<<< HEAD
        //audioSource = GetComponent<AudioSource>();
=======
        audioSource = GetComponent<AudioSource>();
>>>>>>> MissionTesting
	}
	
	// Update is called once per frame
	void Update () {
        float location = rb.position.x;
        //Debug.Log(rb.position.x + ", " +rb.position.z);
        if ((location > boundary.xMax && horizontalSpeed > 0) || (location < boundary.xMin && horizontalSpeed < 0))
        {
            horizontalSpeed = -horizontalSpeed;
        }
        Vector3 movement = new Vector3(horizontalSpeed, 0.0f, -verticalSpeed);
        rb.velocity = movement;
        rb.rotation = Quaternion.Euler(0.0f, 180.0f, rb.velocity.x * tilt);
    }

}
