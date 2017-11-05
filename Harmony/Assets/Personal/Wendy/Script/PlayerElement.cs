using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerElement : MonoBehaviour
{   
    // Player
    public PlayerMovement Player;

    // Whether the player uses elements
    private bool ElementOn = false;

    // Key to use elements and switch 
    public KeyCode ElementKey1;
    public KeyCode ElementKey2;
    public KeyCode ElementKey3;
    public KeyCode ElementKey4;
    private int ElementNumber;

    // ElementAir
    public float AirSpeedChange;

    // ElementStone
    public GameObject Stone;
    public Vector2 StoneVelocity;

    void FixedUpdate ()
    {
        // Element Air
        if (Input.GetKey(ElementKey1))
        {
            ElementAir();
        }

        if (Input.GetKey(ElementKey2))
        {
            ElementStone();
        }
	}

    // Element Air
    void ElementAir()
    {
        if (ElementOn == false)
        {
            Player.MaxSpeed = Player.MaxSpeed * AirSpeedChange;
            Player.JumpForce = Player.JumpForce * AirSpeedChange;
            ElementOn = true;
        }
        else
        {
            Player.MaxSpeed = Player.MaxSpeed / AirSpeedChange;
            Player.JumpForce = Player.JumpForce / AirSpeedChange;
            ElementOn = false;
        }
    }

    void ElementStone()
    {
        GameObject NewStone = GameObject.Instantiate(Stone, transform.position, Quaternion.identity, Stone.transform);
        NewStone.GetComponent<Rigidbody2D>().velocity = StoneVelocity;
    }
}   
