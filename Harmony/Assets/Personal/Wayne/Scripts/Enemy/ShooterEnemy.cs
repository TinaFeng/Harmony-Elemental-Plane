﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : MonoBehaviour {
    public GameObject bullet;//things this enemy will shot
    public Vector2 velocity;// velocity of the item being shotted
    public Vector3 positionDiffer;//position difference from the shot position to the enemy itself
    public float timeInterval;//time interval of shooting
    private bool canShoot = true;

	// Use this for initialization
	void Start () {
        StartCoroutine(Shoot());
	}

    private void Update()
    {
        if (GetComponent<EnemyState>().IfDefeated() && canShoot)
        {
            StopAllCoroutines();
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            canShoot = false;
        }
    }

    IEnumerator Shoot()
    {
        while(true)
        {
            //shot a new bullet and set its velocity
            GameObject newBullet = GameObject.Instantiate(bullet, transform.position + positionDiffer, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().velocity = velocity;
            //wait for a period
            yield return new WaitForSeconds(timeInterval);
        }
    }
}
