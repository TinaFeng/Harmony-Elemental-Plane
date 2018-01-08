using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerElement : MonoBehaviour
{
    public AudioClip shootSE;
    // Player
    public PlayerMovement Player;
    private bool PlayerFaceDirection; // Right = true, Left = false
    private Animator animator;

    // Whether the player can use elements
    public bool ElementOn = false;

    // Key to use elements and switch 
    private UIManager uiManager;
    public KeyCode ElementShiftKey;
    public KeyCode ElementAttackKey;
    private int ElementNumber = 0;
    private bool CanShoot = true;

    // ElementAir
    public float AirSpeedChange;

    // ElementGrass
    public GameObject Grass;
    public Vector2 GrassVelocity;
    public bool boolGrassAcquire;

    // ElementIce
    public GameObject Ice;
    public Vector2 IceVelocity;
    public bool boolIceAcquire;

    // ElementFire
    public GameObject Fire;
    public Vector2 FireVelocity;
    public bool boolFireAcquire;

    private void Start()
    {
        uiManager = GameObject.Find("Manager").GetComponent<UIManager>();
        PlayerFaceDirection = true;
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        // Which direction the player is facing to
        if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
        {
            PlayerFaceDirection = true;
            animator.SetTrigger("TurnRight");
            animator.speed = 1;
        }
        else if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            PlayerFaceDirection = false;
            animator.SetTrigger("TurnLeft");
            animator.speed = 1;
        }
        else
        {
            animator.Play(0);
            animator.speed = 0;
        }

        // Shift between elements
        if (Input.GetKeyDown(ElementShiftKey))
        {
            ElementOn = true;
            if (ElementOn)
            {
                // Element Air: 0
                if (ElementNumber == 0)
                {
                    ElementAir(true);
                    ElementNumber = 1;
                    uiManager.UpdatePlayerElement(element.air);
                }
                // Element Grass: 1
                else if (ElementNumber == 1)
                {
                    ElementAir(false);
                    ElementNumber = 2;
                    uiManager.UpdatePlayerElement(element.grass);
                }
                // Element Ice: 2
                else if (ElementNumber == 2)
                {
                    ElementNumber = 3;
                    uiManager.UpdatePlayerElement(element.water);
                }
                // Element Fire: 3
                else
                {
                    ElementNumber = 0;
                    uiManager.UpdatePlayerElement(element.fire);
                }

            }
        }
        // Attack with elements
        if (Input.GetKeyDown(ElementAttackKey) && ElementOn && CanShoot)
        {
            StartCoroutine("ElementAttack");
        }
    }

    // Element Air
    void ElementAir(bool AirOn)
    {
        if (AirOn)
        {
            Player.MaxSpeed = Player.MaxSpeed * AirSpeedChange;
            Player.JumpForce = Player.JumpForce * AirSpeedChange;
            Player.MaxJump = 2;
        }
        else
        {
            Player.MaxSpeed = Player.MaxSpeed / AirSpeedChange;
            Player.JumpForce = Player.JumpForce / AirSpeedChange;
            Player.MaxJump = 1;
        }
    }

    // Elements
    void Element(GameObject Ele, float t,Vector2 vel)
    {
        AudioSource.PlayClipAtPoint(shootSE, new Vector3(0, 0, 0));
        if (!PlayerFaceDirection)
        {
            vel.x = -vel.x;
        }

        GameObject New = GameObject.Instantiate(Ele, transform.position, Quaternion.identity);
        GameObject.Destroy(New, t);
        New.GetComponent<Rigidbody2D>().velocity = vel;
    }

    IEnumerator ElementAttack()
    {
        CanShoot = false;
        // Element Grass: 1
        if (ElementNumber == 2)
        {
            Element(Grass, 5f, GrassVelocity);
        }
        // Element Ice: 2
        if (ElementNumber == 3)
        {
            Element(Ice, 8f, IceVelocity);
        }
        // Element Fire: 3
        if (ElementNumber == 0)
        {
            Element(Fire, 8f, new Vector2(FireVelocity.x, FireVelocity.y - 2));
            Element(Fire, 8f, new Vector2(FireVelocity.x,FireVelocity.y - 1));
            Element(Fire, 8f, FireVelocity);
            Element(Fire, 8f, new Vector2(FireVelocity.x, FireVelocity.y + 1));
            Element(Fire, 8f, new Vector2(FireVelocity.x, FireVelocity.y + 2));
        }
        // suspend execution for 0.3 seconds
        yield return new WaitForSeconds(0.3f);
        CanShoot = true;
    }

}   

