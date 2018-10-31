using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid_Field : MonoBehaviour {

    public GameObject[] asteroids = new GameObject[6];
    public int numberOfAsteroids;
    public int[] randomAsteroid;
    public float[] speedRange;
    public Vector3 spawnRange;

    public int seed;

    private GameObject[] AsteroidClones;

    public void Start()
    {
        randomAsteroid = new int[numberOfAsteroids];
        speedRange = new float[numberOfAsteroids];
        AsteroidClones = new GameObject[numberOfAsteroids];
        Random.InitState(seed);

        for (int i = 0; i < numberOfAsteroids; i++)
        {
            randomAsteroid[i] = Random.Range(0, 6);
            speedRange[i] = Random.Range(10, 50);

           AsteroidClones[i] = Instantiate(asteroids[randomAsteroid[i]], new Vector3(transform.position.x + Random.Range(-spawnRange.x, spawnRange.x),
                                                                                     transform.position.y + Random.Range(-spawnRange.y, spawnRange.y),
                                                                                     transform.position.y + Random.Range(-spawnRange.z, spawnRange.z)), Quaternion.identity);

            AsteroidClones[i].transform.GetComponent<Rigidbody>().velocity = transform.forward * speedRange[i];
            AsteroidClones[i].transform.parent = this.transform;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, spawnRange * 2);
    }

}
