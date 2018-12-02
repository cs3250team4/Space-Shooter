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
    private ParticleSystem radiation_sparks;   // radiation particle system of player's ship
    private ParticleSystem radiation_clouds;   // radiation particle system of player's ship
    private bool firstTime;
    public bool radiation;
    PlayerData playerData;

    /*
     * Initialization
     */
    void Start ()
    {
        playerData = FindObjectOfType<PlayerData>();
        firstTime = true;
        radiation = false;
        // Get the Radiation particle system for the player's ship
        radiation_sparks = transform.GetChild(0).transform.GetChild(0).GetComponent<ParticleSystem>();
        radiation_clouds = transform.GetChild(0).transform.GetChild(1).GetComponent<ParticleSystem>();
        radiation_sparks.Emit(0);
        radiation_clouds.Emit(0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.magnitude > maxDistance)
        {
            if (!radiation)
            {
                radiation = true;
            }
            radiation_sparks.Play();
            radiation_clouds.Play();
            if (firstTime)
            {
                firstTime = false;
            }
            // damage the player's shield if they enter the radiation field
            if (playerData.shieldStrength >= 2)
            {
                playerData.shieldStrength -= 2;
            }
            // set radiation emission rate to a factor of the distance from center
            radiation_sparks.emissionRate = (transform.position.magnitude - maxDistance) * 10;
            radiation_clouds.emissionRate = (transform.position.magnitude - maxDistance) * 10;
        }
        else
        {
            if (radiation_sparks.isPlaying)
            {
                radiation_sparks.Stop();
                radiation_clouds.Stop();
            }
            if (radiation)
            {
                radiation = false;
            }
        }
    }
}
