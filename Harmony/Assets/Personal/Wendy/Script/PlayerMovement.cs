using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    // Player
    public Rigidbody2D Player;
    // Speed
    public float MaxSpeed;
    public float horizontalForce;
    // Jump Force
    public float JumpForce;
    // Whether on ground
    private RaycastHit2D Hit;
    private bool IsGround = false;
    // Double Jump
    public int MaxJump = 1;
    private int Jump = 0;
    private int TempJump;
    public AudioClip jumpSE;

    // Jump
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            IsGround = true;
            TempJump = Jump;
            Jump = 0;
            Hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y + 0.611f), Vector2.up, 0.001f);
            if (Hit.collider != null)
            {
                IsGround = (TempJump < MaxJump);
                Jump = TempJump;
            }
        }

    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        // Move towards left or right
        float horizontal = Input.GetAxis("Horizontal");
        Player.AddForce(new Vector2(horizontal * horizontalForce, 0));
        //check max
        if(Player.velocity.x > MaxSpeed)
        {
            Player.velocity = new Vector2(MaxSpeed,Player.velocity.y);
        }
        if (Player.velocity.x < -MaxSpeed)
        {
            Player.velocity = new Vector2(-MaxSpeed, Player.velocity.y);
        }
        // Jump

        if (Input.GetKeyDown(KeyCode.Space) && IsGround == true)
        {
            AudioSource.PlayClipAtPoint(jumpSE, new Vector3(0, 0, 0));
            Player.AddForce(Vector2.up * JumpForce);
            Jump += 1;
            IsGround = (Jump < MaxJump);
        }
    }

}
