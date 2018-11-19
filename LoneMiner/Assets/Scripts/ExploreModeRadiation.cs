/* 
 * ExploreModeRadiation
 * 
 * Author(s):  Kenneth Berry 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploreModeRadiation : MonoBehaviour {

    public float maxDistance; // maximum distance the ship can travel before radiation damage
    private ParticleSystem radiation;   // radiation particle system of player's ship
    private bool firstTime;

    /*
     * Initialization
     */
    void Start ()
    {
        firstTime = true;
        // Get the Radiation particle system for the player's ship
        radiation = transform.GetChild(0).GetComponent<ParticleSystem>();
        radiation.Emit(0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.x > maxDistance
        || transform.position.x < -maxDistance
        || transform.position.z > maxDistance
        || transform.position.z < -maxDistance)
        {
            radiation.Play();
            if (firstTime)
            {
                firstTime = false;
                radiation.emissionRate = 50;
            }
        }
        else if (radiation.isPlaying)
        {
            radiation.Stop();
        }
    }
}
