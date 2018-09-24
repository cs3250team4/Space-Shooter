/*
 * Original code by Adam Buckner https://www.linkedin.com/in/adam-buckner-vfx
 * From Unity Tutorial:
 * https://unity3d.com/learn/tutorials/projects/space-shooter-tutorial/boundary?playlist=17147
 */

using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}