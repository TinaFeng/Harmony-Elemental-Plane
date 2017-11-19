using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementIceDestroy : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(this.gameObject);
    }
}
