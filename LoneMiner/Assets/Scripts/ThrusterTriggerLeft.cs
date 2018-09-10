/*
 * ThrusterTriggerLeft
 * 
 * Toggles on and off the thruster particles on players
 * ship when the ship is being rotated to the left.
 * 
 * Needs to be added as a component to all auxiliary thruster 
 * GameObjects that should be on when the ship rotates left.
 * 
 * Author(s):   Kenneth Berry
 */

using UnityEngine;

public class ThrusterTriggerLeft : MonoBehaviour
{

    private ParticleSystem particles; // thruster ParticleSystem

    /*
     * Initialization
     */
    void Start()
    {
        // Get this GameObjects ParticleSystem
        particles = GetComponent<ParticleSystem>();
    }

    /*
     * Update is called once per frame
     */
    void Update()
    {
        // Check if there is rotate-left input
        if (Input.GetAxis("Horizontal") < 0.0f)
        {
            // Turn on particle system
            particles.Play();
        }
        else
        {
            // Turn off particle system
            particles.Stop();
        }
    }
}
