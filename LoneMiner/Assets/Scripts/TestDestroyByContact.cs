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

public class TestDestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int enemiesDestroyed;
    private TestMissionController missionController;

    void Start()
    {
        GameObject missionControllerObject = GameObject.FindWithTag("GameController");
        if (missionControllerObject != null)
        {
            missionController = missionControllerObject.GetComponent<TestMissionController>();
        }
        if (missionController == null)
        {
            Debug.Log("Cannot find 'TestMissionController' script");
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
        if (this.tag == "Enemy")
        {
            missionController.AddScore(1);
        }
        Destroy(gameObject);
    }
}
