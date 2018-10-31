using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Control : MonoBehaviour {

    public float BulletSpeed;
    public float damage;
    private Rigidbody rb;

    void start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rb.velocity = transform.forward * BulletSpeed;
        Destroy(gameObject, 2);
    }
	
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Asteroid");
        {
            collision.transform.GetComponent<PixelMake_AstroidController>().stats.currentHealth -= damage;
            Destroy(gameObject);
        }
    }
        

}
