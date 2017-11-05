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
    private RaycastHit2D Hit;
    private bool IsGround = true;

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
        Hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y-0.123213f), Vector2.down,0.001f);
        IsGround = (Hit.collider != null);

        if (Input.GetKeyDown(KeyCode.Space) && IsGround == true) 
        {
            Player.AddForce(Vector2.up * JumpForce);
        }

    }

}
