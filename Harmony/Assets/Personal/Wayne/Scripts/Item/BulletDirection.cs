using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDirection : MonoBehaviour {
    //caculate the velocity and rotate the sprite
    public int defaultAngle;
    private Rigidbody2D rigid;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {
        float angle = Mathf.Atan2(rigid.velocity.y, rigid.velocity.x);
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, defaultAngle + angle*180/3.14159f);
	}
}
