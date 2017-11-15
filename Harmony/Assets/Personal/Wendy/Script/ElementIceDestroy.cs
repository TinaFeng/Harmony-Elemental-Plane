using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementIceDestroy : MonoBehaviour
{
    void OnCollisionEnter2D(Collider2D other)
    {
        print("collide");
        // Destroy(other.gameObject);
        
    }
}
