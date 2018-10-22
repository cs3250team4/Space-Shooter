/*
 * Orginal code by Adam Buckner: https://www.linkedin.com/in/adam-buckner-vfx
 * From Unity Tutorials:
 * https://unity3d.com/learn/tutorials/projects/space-shooter-tutorial/moving-player?playlist=17147
 * https://unity3d.com/learn/tutorials/projects/space-shooter/shooting-shots?playlist=17147
 * https://unity3d.com/learn/tutorials/projects/space-shooter-tutorial/audio?playlist=17147
 * 
 * Updated & Modified by Joe Turner mailto:jturne48@msudenver.edu
 */

using UnityEngine;
using System.Collections;

[System.Serializable]
public class SideScrollBoundary
{
    public float xMin, xMax, zMin, zMax;
}

public class SideScrollPlayerController : MonoBehaviour
{
    public float speed;
    public float tilt;
    //public float zPos;
    public SideScrollBoundary boundary;
    private Rigidbody rb;
    private AudioSource audioSource;

    public GameObject shot;
    public Transform centerLaser;
    public Transform leftLaser;
    public Transform rightLaser;
    public float fireRate;

    private float nextFire;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            if(shot != null)
            {
                nextFire = Time.time + fireRate;
                if (centerLaser != null)
                {
                    Instantiate(shot, centerLaser.position, centerLaser.rotation);
                }                
                if(leftLaser != null)
                {
                    Instantiate(shot, leftLaser.position, leftLaser.rotation);
                }
                if(rightLaser != null)
                {
                    Instantiate(shot, rightLaser.position, rightLaser.rotation);
                }                
                audioSource.Play();
            }            
        }
    }

    void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(-moveVertical, 0.0f, moveHorizontal);
        rb.velocity = movement * speed;
        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );
        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt + 90.0f);
    }

}