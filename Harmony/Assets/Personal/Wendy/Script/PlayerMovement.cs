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
    private bool IsGround = false;
    // Double Jump
    public int MaxJump = 1;
    private int Jump = 0;

    // Jump
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            Hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.123213f), Vector2.down, 0.001f);
            print(new Vector2(transform.position.x, transform.position.y - 0.123213f));
            if (Hit.collider != null)
            {
                IsGround = true;
                Jump = 0;
            }
        }

    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        // Move towards left or right
        float horizontal = Input.GetAxis("Horizontal");
        if (Player.velocity.x < MaxSpeed)
        {
            Player.AddForce(new Vector2(horizontal * MaxSpeed, 0));
        }

        // Jump
        
        if (Input.GetKeyDown(KeyCode.Space) && IsGround == true)
        {
            Player.AddForce(Vector2.up * JumpForce);
            Jump += 1;
            if(Jump>= MaxJump)
            {
                IsGround = false;
            }
        }
    }

}
