using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    // Player
    public Rigidbody2D Player;
    // Speed
    public float MaxSpeed;
    // Jump Force
    public float JumpForce;
    // Whether on ground
    public bool IsOnGround;

    void Start ()
    {
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        // Move towards left or right
        float horizontal = Input.GetAxis("Horizontal");
        Player.velocity = new Vector2(horizontal * MaxSpeed, Player.velocity.y);

        // Jump
        IsOnGround = Physics.Raycast(Player.position, new Vector3(0,-1, -0.009084969f)); //?

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Player.AddForce(Vector2.up * JumpForce);
        }
        
	}

}
