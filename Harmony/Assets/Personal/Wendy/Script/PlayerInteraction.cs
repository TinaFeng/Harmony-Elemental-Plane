using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction: MonoBehaviour
{
    // Health
    public int IntPlayerHealth = 5;
    public bool BoolPlayerInvincible = true;

    //UI
    public bool BoolPlayerLose = false;

    // Number of gems of different elements
    public int IntFireGem = 0;
    public int IntIceGem = 0;
    public int IntStoneGem = 0;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // If hit by an Enemy
        if (collision.gameObject.tag == "Enemy")
        {
            // If the enemy is not defeated
            if (!collision.gameObject.GetComponent<EnemyState>().IfDefeated())
            {
                GetHurt();
                //this.GetComponent<Rigidbody2D>().AddForce(new Vector2 (collision.transform.x));
            }
        }
        else if (collision.gameObject.tag == "EnemyBullet")
        {
            GetHurt();
        }


        /*
        // Collect gems or intereact?
        if ((collision.gameObject.tag == "Gem"))
        {
            
        }
        */
    }

    IEnumerator Invincible()
    {
        //Let the player invincible for 2 seconds after lose one heart
        BoolPlayerInvincible = false;
        //Shining
        for (int x = 1; x <= 10; x++)
        {
            if (x % 2 == 1)
            {
                this.GetComponent<SpriteRenderer>().color = new Color32(184, 184, 184, 255);
            }
            else
            {
                this.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            }
            yield return new WaitForSeconds(0.25f);
        }
        // Able to get hurt again
        BoolPlayerInvincible = true;
    }

    void GetHurt()
    {
        IntPlayerHealth -= 1;
        if (IntPlayerHealth == 0)
        {
            Destroy(this.gameObject);
            BoolPlayerLose = true;
        }
        StartCoroutine(Invincible());
    }
}
