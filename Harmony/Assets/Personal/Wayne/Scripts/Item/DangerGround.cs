using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerGround : MonoBehaviour {
    public Vector2 velocityAfterTouch;
    public bool keepHorizontalSpeed;
    public bool keepVerticalSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //hurt the player and bounce it
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerInteraction>().GetHurt();
            if(keepHorizontalSpeed)
            {
                velocityAfterTouch.x = collision.gameObject.GetComponent<Rigidbody2D>().velocity.x;
            }
            if (keepVerticalSpeed)
            {
                velocityAfterTouch.x = collision.gameObject.GetComponent<Rigidbody2D>().velocity.y;
            }
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = velocityAfterTouch;
        }
    }
}
