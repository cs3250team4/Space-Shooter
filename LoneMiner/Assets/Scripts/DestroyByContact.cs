/*
 * Original code by Adam Buckner https://www.linkedin.com/in/adam-buckner-vfx
 * From Unity Tutorials:
 * https://unity3d.com/learn/tutorials/projects/space-shooter-tutorial/creating-hazards?playlist=17147
 * https://unity3d.com/learn/tutorials/projects/space-shooter-tutorial/explosions?playlist=17147
 */

using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary" || other.tag == "Enemy")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            //gameController.GameOver();
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
