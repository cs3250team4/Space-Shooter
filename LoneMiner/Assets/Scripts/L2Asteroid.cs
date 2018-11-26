﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2Asteroid : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    private MissionController missionController;

    void Start()
    {
        GameObject missionControllerObject = GameObject.FindWithTag("GameController");
        if (missionControllerObject != null)
        {
            missionController = missionControllerObject.GetComponent<MissionController>();
        }
        if (missionController == null)
        {
            Debug.Log("Cannot find 'MissionController' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Enemy" || other.tag == "EnemyShot")
        {
            return;
        }
        if (explosion != null)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        if (other.tag == "Player")
        {
            if (this.tag == "EnemyShot")
            {
                PlayerData.control.hullIntegrity -= 1;
            }
            if (this.tag == "Enemy")
            {
                PlayerData.control.hullIntegrity -= 100;
            }
            if (PlayerData.control.hullIntegrity <= 0)
            {
                PlayerData.control.hullIntegrity = 0;
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                Destroy(other.gameObject);
                missionController.MissionFailed();
            }
        }
        Destroy(gameObject);
    }
}