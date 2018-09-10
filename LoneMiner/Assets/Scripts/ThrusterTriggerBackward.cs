/*
 * ThrusterTriggerBackward
 * 
 * Toggles on and off the thrust particles on players
 * ship when backward/reverse thrust is applied.
 * 
 * Needs to be added as a component to forward thruster
 * GameObject
 * 
 * Author(s):   Kenneth Berry
 */

using UnityEngine;

public class ThrusterTriggerBackward : MonoBehaviour {

    private ParticleSystem particles; // thruster ParticleSystem

	/*
     * Initialization
     */
	void Start ()
    {
        // Get GameObject's ParticleSystem
        particles = GetComponent<ParticleSystem>();
    }
	
	/*
     * Update is called once per frame
     */
	void Update ()
    {
        //Check if there is forward thrust input
        if (Input.GetAxis("Vertical") < 0.0f)
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
