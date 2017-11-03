using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Gravity : MonoBehaviour
{
    // Gravity
    protected float GravityModifier = 1.0f;
    protected Vector2 Vec2Gravity;

    // Player
    protected Rigidbody2D Rb2dPlayer;

    void OnEnable()
    {
        Rb2dPlayer = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        // Calculate player gravity velocity -> velocity = acceleration * time
        Vec2Gravity += Physics2D.gravity * GravityModifier * Time.deltaTime; // Physics2D.gravity -> acceleration

        // Calculate player y position -> position = velocity * time
        Vector2 DeltaPosition = Vec2Gravity * Time.deltaTime;

        Vector2 Move = Vector2.up * DeltaPosition.y;
        movement(Move);
    }

    void movement(Vector2 Move)
    {
        Rb2dPlayer.position += Move;
    }
}
