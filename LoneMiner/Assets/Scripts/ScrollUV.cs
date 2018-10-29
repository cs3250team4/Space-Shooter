using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUV : MonoBehaviour
{
    private MeshRenderer mr;
    private Material mat;
    private Vector2 offset;

	// Initialization
	void Start ()
    {
        mr = GetComponent<MeshRenderer>();
        mat = mr.material;
        offset = mat.mainTextureOffset;
    }
	
	// Update is called once per frame
	void Update ()
    {
        offset.x += Time.deltaTime / 10f;
        mat.mainTextureOffset = offset;
	}
}
