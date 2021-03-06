﻿ using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//a enemy that only goes left and right

public class DummyEnemy : MonoBehaviour {
    public Vector2[] velocityArray;//X denotes the X velocity, Y here is how much time the enemy moves

    public Sprite leftSprite;
    public Sprite rightSprite;

    private bool canMove = true;
    private float timer;
    private int velocityIndex;//which index of velocity is the object in

	// Use this for initialization
	void Start () {
        velocityIndex = 0;
        timer = 0;
        ChangeSprite(velocityArray[0][0]);        
    }
	
	// Update is called once per frame
	void Update () {
        //when enemy is defeated, stop it 
        if (GetComponent<EnemyState>().IfDefeated()&&canMove)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            canMove = false;
        }
        if (canMove)
        {
            Move();
        }
        
        
	}

    private void Move()
        //go through the velocityArray and move by the information show in Vector2 
    {
        
        GetComponent<Rigidbody2D>().velocity = new Vector2(velocityArray[velocityIndex][0], GetComponent<Rigidbody2D>().velocity.y);
        timer += Time.deltaTime;
        //when finish move in one direction, change to the next one
        if (timer > velocityArray[velocityIndex][1])
        {
            timer = 0;
            velocityIndex += 1;
            //test if index too big
            if(velocityIndex >= velocityArray.Length)
            {
                velocityIndex = 0;
            }
            ChangeSprite(velocityArray[velocityIndex][0]);
        }      
    }

    public void ChangeSprite(float x)
        //get the monster's x velocity and change its sprite
    {
        if(x>0)
        {
            GetComponent<SpriteRenderer>().sprite = rightSprite;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = leftSprite;
        }
    }

}
