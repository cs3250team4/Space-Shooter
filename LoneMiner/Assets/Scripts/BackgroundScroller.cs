/*
 * Original code by Adam Buckner https://www.linkedin.com/in/adam-buckner-vfx
 * from https://unity3d.com/learn/tutorials/topics/2d-game-creation/2d-scrolling-backgrounds
 * 
 * Modified by Joe Turner mailto:jturne48@msudenver.edu
 */

using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeZ;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + Vector3.back * newPosition;
    }
}