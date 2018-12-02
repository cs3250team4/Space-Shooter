// Code by Joe Turner jturne48@msudenver.edu

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OW_ParallaxBG : MonoBehaviour
{
    // the speed at which to scroll the background (set in Unit editor)
    public float parallax;

    // Update is called once per frame
    void Update()
    {
        // get the mesh renderer component
        MeshRenderer mr = GetComponent<MeshRenderer>();
        // get the mesh renderer material
        Material mat = mr.material;
        // get the material's offset
        Vector2 offset = mat.mainTextureOffset;
        // calculate new offset x position
        offset.x = transform.position.x / transform.localScale.x / parallax;
        // calculate new offset y position
        offset.y = transform.position.y / transform.localScale.y / parallax;
        // update the offset
        mat.mainTextureOffset = offset;
    }
}
