using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowUV : MonoBehaviour
{
    public float parralax = 2f;
    private MeshRenderer mr;
    private Material mat;
    private Vector2 offset;

    // Use this for initialization
    void Start ()
    {
        mr = GetComponent<MeshRenderer>();
        mat = mr.material;
        offset = mat.mainTextureOffset;
    }
	
	// Update is called once per frame
	void Update ()
    {
        offset.x = transform.position.x / transform.localScale.x / parralax;
        offset.y = transform.position.z / transform.localScale.z / parralax;

        mat.mainTextureOffset = offset;
    }
}
