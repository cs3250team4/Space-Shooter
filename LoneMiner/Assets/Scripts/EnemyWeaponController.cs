/*
 * Orginal code by Adam Buckner: https://www.linkedin.com/in/adam-buckner-vfx
 * From Unity Tutorial:
 * https://unity3d.com/learn/tutorials/projects/space-shooter-tutorial/extending-space-shooter-enemies-more-hazards?playlist=17147
 * 
 * Updated by Joe Turner mailto:jturne48@msudenver.edu
 */

using UnityEngine;
using System.Collections;

public class EnemyWeaponController : MonoBehaviour
{

    public GameObject shot;
    public Transform centerLaser;
    public Transform leftLaser;
    public Transform rightLaser;
    public float fireRate;
    public float delay;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Fire", delay, fireRate);
    }

    void Fire()
    {
        if(centerLaser != null)
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