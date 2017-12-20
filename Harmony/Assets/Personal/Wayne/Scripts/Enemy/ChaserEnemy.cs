using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserEnemy : MonoBehaviour {
    public float sight;//how long the enemy can see
    public float speed;//how fast this enemy moves
    public bool onGround = false;// is this enemy one walks on ground
    public GameObject target;
    private bool isChasing = false;


    private void Update()
    {
        if (!GetComponent<EnemyState>().IfDefeated())
            //if the enemy haven't been defeated
        {
            if (isChasing)
            //when is chasing, chase
            {
                Chase();
            }
            else
            //havn't begin to chase, check if should to
            {
                if (DistanceFrom(target) < sight)
                {
                    isChasing = true;
                }
            }
        }
      
    }


    public float DistanceFrom(GameObject target)
        //return the distance (sqrt(differX^2 + differY^2))
    {
        return Mathf.Sqrt(Mathf.Pow(gameObject.transform.position.x - target.transform.position.x, 2)+ Mathf.Pow(gameObject.transform.position.y - target.transform.position.y, 2));
    }

    public void Chase()
        //change itself's velocity to run towards the player
    {
        //caculate the direction angle
        float radian = Mathf.Atan2(target.transform.position.y - gameObject.transform.position.y, target.transform.position.x - gameObject.transform.position.x);
        //caculat the velocity
        Vector2 velocity = new Vector2(Mathf.Cos(radian), Mathf.Sin(radian)) * speed;
        //set the velocity depends on what type the enemy is 
        if (onGround)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = velocity;
        }

    }
}
