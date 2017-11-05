using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Player
    private Rigidbody2D Player;
    // Speed
    public float MaxSpeed = 2.0f;
    // Jump Force
    public float JumpForce = 0.0000000003f;

	void Start ()
    {
        Player = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float horizontal = Input.GetAxis("Horizontal");
        // float vertical = Mathf.Abs(Input.GetAxis("Vertical"));
        Player.velocity = new Vector2(horizontal * MaxSpeed, Player.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Player.AddForce(Vector2.up * JumpForce);
        }
        
	}
}
