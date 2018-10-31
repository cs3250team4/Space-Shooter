using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ship_Stats
{
    public float maxHealth;
    public float currentHealth;
}

public class ShipControl : MonoBehaviour {

    Rigidbody rb;

    public Ship_Stats stats;

    public GameObject bullet;
    public Transform[] firepoints = new Transform[2];
    public float fireRate;
    private float nextFire;

    public GameObject explosionPrefab;

    public float moveSpeed;
    public float tiltAngle;

    private void Start()
    {
        rb = transform.GetComponent<Rigidbody>();

        stats.currentHealth = stats.maxHealth;

        nextFire = 1 / fireRate;


    }

    private void Update()
    {
        if(stats.currentHealth <= 0)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }   

    private void FixedUpdate()
    {
        float moveLR = Input.GetAxis("Horizontal");
        float moveFB = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveLR, 0, moveFB);
        rb.velocity = movement * moveSpeed;

        rb.rotation = Quaternion.Euler(Vector3.forward * moveLR * -tiltAngle);

        bool fireButton = Input.GetButton("Fire1");

        Collider[] shipColliders = transform.GetComponentsInChildren<Collider>();

        if (fireButton)
        {
            nextFire -= Time.fixedDeltaTime;
            if(nextFire <= 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    GameObject bulletClone = Instantiate(bullet, firepoints[i].position, Quaternion.identity);


                    for(int x = 0; x < shipColliders.Length; x++)
                    {
                        Physics.IgnoreCollision(bulletClone.transform.GetComponent<Collider>(), shipColliders[x]);
                    }
                }
                nextFire += 1 / fireRate;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            stats.currentHealth -= collision.transform.GetComponent<PixelMake_AstroidController>().stats.damage;
            Destroy(collision.gameObject);
        }
    }

}
