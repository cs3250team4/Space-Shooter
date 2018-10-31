/*
 * Original code by Adam Buckner https://www.linkedin.com/in/adam-buckner-vfx
 * From Unity Tutorials:
 * https://unity3d.com/learn/tutorials/projects/space-shooter-tutorial/creating-hazards?playlist=17147
 * https://unity3d.com/learn/tutorials/projects/space-shooter-tutorial/explosions?playlist=17147
 * 
 * Modified by Joe Turner mailto:jturne48@msudenver.edu
 */

using UnityEngine;
using System.Collections;

[System.Serializable]
public class DotEBoundary
{
    public float xMin, xMax, zMin, zMax;
}

public class DotE : MonoBehaviour
{
    public float health;
    private float scaleDown;
    public float speed;
    public GameObject explosion;
    public GameObject playerExplosion;
    public GameObject finalExplosion;
    public DotEBoundary boundary;
    //private AudioSource audioSource;
    private DotEMissionController missionController;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        scaleDown = (PlayerData.control.laserDamage / health) * (this.transform.localScale.x / 2);
        GameObject missionControllerObject = GameObject.FindWithTag("GameController");
        //audioSource = GetComponent<AudioSource>();
        if (missionControllerObject != null)
        {
            missionController = missionControllerObject.GetComponent<DotEMissionController>();
        }
        if (missionController == null)
        {
            Debug.Log("Cannot find 'MissionController' script");
        }
    }

    void Update()
    {
        float location = rb.position.x;
        //Debug.Log(rb.position.x + ", " +rb.position.z);
        if ((location > boundary.xMax && speed > 0) || (location < boundary.xMin && speed < 0))
        {
            speed = -speed;
        }
        Vector3 movement = new Vector3(speed, 0.0f, 0.0f);
        rb.velocity = movement;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Enemy")
        {
            return;
        }
        else
        {
            health -= PlayerData.control.laserDamage;            
            this.transform.localScale -= new Vector3(scaleDown, scaleDown, scaleDown);
            if(health <= 0)
            {
                if (explosion != null)
                {
                    Instantiate(finalExplosion, transform.position, transform.rotation);                    
                }
                Destroy(this.gameObject);
                missionController.MissionComplete();
            }
        }       
        Destroy(other.gameObject);
        Instantiate(explosion, other.transform.position, other.transform.rotation);
    }
}
