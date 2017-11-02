using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D Player;
	// Use this for initialization
	void Start ()
    {
        Player = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Mathf.Abs(Input.GetAxis("Vertical"));
        Player.velocity = new Vector2(horizontal, 0);
        if (vertical >= 1)
        {
            Player.velocity = new Vector2(horizontal, 0);
        }
        
	}
}
