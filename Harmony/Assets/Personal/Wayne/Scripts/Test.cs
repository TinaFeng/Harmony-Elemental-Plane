﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {

        collision.collider.gameObject.GetComponent<EnemyState>().GetHurt(1);

    }
}
