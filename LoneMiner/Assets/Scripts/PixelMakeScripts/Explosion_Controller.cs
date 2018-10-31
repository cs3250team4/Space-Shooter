using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Controller : MonoBehaviour {

    private ParticleSystem ps;

    private void Start()
    {
        ps = transform.GetComponent<ParticleSystem>();
    }


    private void Update()
    {
        if (!ps.IsAlive())
        {
            Destroy(gameObject);
        }
    }
}
