using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipControls : MonoBehaviour {

   
    public float thrust;
    public float rotateThrust;
    private float thrustInput;
    private float rotateInput;
    private Rigidbody rb;
    Vector3 m_EulerAngleVelocity;

    // Use this for initialization
    void Start () {
        rb = GetComponent <Rigidbody>();
       
	}
	
	// Update is called once per frame
	void Update () {
        //Check for input.
        thrustInput = Input.GetAxis("Vertical");
        rotateInput = Input.GetAxis("Horizontal");
        m_EulerAngleVelocity = new Vector3(0, rotateInput * rotateThrust, 0);


    }

    void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.forward * thrustInput * thrust);
        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }
   

}
