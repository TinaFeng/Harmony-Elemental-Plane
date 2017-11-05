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
    public KeyCode ElementKey;

    // Element
    public float AirSpeedChange;
    private int ElementNumber;

    void FixedUpdate ()
    {
        // Element Air
        if (Input.GetKey(ElementKey))
        {
            ElementAir();
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
}
