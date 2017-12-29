using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
    public element weakness;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PlayerElement" && collision.gameObject.GetComponent<ElementAttribution>().elementType == weakness)
        {
            GetComponent<Animator>().SetTrigger("Disappear");
            Destroy(gameObject, 0.5f);
        }
    }
}
