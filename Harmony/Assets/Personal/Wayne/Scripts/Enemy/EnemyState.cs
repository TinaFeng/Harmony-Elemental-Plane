using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum element
{
    fire,
    water,
    grass,
    air
}


public class EnemyState : MonoBehaviour {
    public int health = 20;
    private bool defeated = false;
    private bool canHurt = true;
    public element elementType;
    private Color32 color;
    private bool healed = false;

    public AudioClip hurtSE;
    public AudioClip healSE;

    private void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color32(70, 70, 70, 255);
        color = GetComponent<SpriteRenderer>().color;
    }

    public void GetHurt(int value)
        //the monster get hurt and reduce health point
    {
        health -= value;
        //become unable to move if health<=0
        if (health <= 0)
        {
            defeated = true;
            canHurt = false;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<Collider2D>().isTrigger = true;
            //change color to prompt the player the state change
            GetComponent<SpriteRenderer>().color = new Color32(120, 120, 120, 255);
        }
        else
        //still alive, invincivable for a period
        {
            StartCoroutine(Invincivable());
        }
    }
	
    public bool IfDefeated()
        //return if this monster is defeated
    {
        return defeated;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //when be attacked
        if (collision.gameObject.tag == "PlayerElement" && canHurt)
        {
            AudioSource.PlayClipAtPoint(hurtSE, new Vector3(0, 0, 0));
            GetHurt(collision.gameObject.GetComponent<ElementAttribution>().intAttack);
        }

        if (collision.gameObject.tag == "Player")
        {
            LevelProcessManager levelManager = GameObject.Find("Manager").GetComponent<LevelProcessManager>();
            //test if have enough gems
            if (!healed && defeated && levelManager.gem > 0)
            {
                //heal this enemy
                healed = true;
                gameObject.tag = "Untagged";
                levelManager.ChangeGemNumber(-1);
                levelManager.ChangeHealedEnemyNumber(1);
                AudioSource.PlayClipAtPoint(healSE, new Vector3(0, 0, 0));
                StartCoroutine(HealColor());
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //when touch player, shoot off? it
        if (collision.gameObject.tag == "Player")
        {
            float angle = Mathf.Atan2(collision.gameObject.transform.position.y - transform.position.y, collision.gameObject.transform.position.x - transform.position.x);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Mathf.Cos(angle), Mathf.Sin(angle) + 1) * 250);
        }
    }

    IEnumerator Invincivable()
    {
        canHurt = false;
        //let the enemy invincible for 1 seconds after lose one heart
        this.GetComponent<SpriteRenderer>().color = new Color32(color.r, color.g, color.b, 155);
        yield return new WaitForSeconds(1f);
        this.GetComponent<SpriteRenderer>().color = new Color32(color.r, color.g, color.b, 255);
        /*
        for (int x = 1; x <= 6; x++)
        {//shining
            if (x % 2 == 1)
            {
                this.GetComponent<SpriteRenderer>().color = new Color32(color.a, color.b, color.g, 155);
            }
            else
            {
                this.GetComponent<SpriteRenderer>().color = new Color32(color.a, color.b, color.g, 255);
            }
            yield return new WaitForSeconds(0.25f);
        }*/
        canHurt = true;// able to get hurt again

    }

    IEnumerator HealColor()
     //rainbow color effect when healed
    {
        color = GetComponent<SpriteRenderer>().color;
        byte speed = 15;
        float timeInterval = 0.005f;
        for (int x = 120; x< 255; x+=speed)
        {
            color.r += speed;
            if(color.g > 0)
            {
                color.g -= speed;
                color.b -= speed;
            }
            GetComponent<SpriteRenderer>().color = color;
            yield return new WaitForSeconds(timeInterval);
        }

        for(int x = 0; x<255; x+= speed)
        {
            color.b += speed;
            GetComponent<SpriteRenderer>().color = color;
            yield return new WaitForSeconds(timeInterval);
        }

        for (int x = 0; x < 255; x += speed)
        {
            color.r -= speed;
            GetComponent<SpriteRenderer>().color = color;
            yield return new WaitForSeconds(timeInterval);
        }

        for (int x = 0; x < 255; x += speed)
        {
            color.g += speed;
            GetComponent<SpriteRenderer>().color = color;
            yield return new WaitForSeconds(timeInterval);
        }

        for (int x = 0; x < 255; x += speed)
        {
            color.b -= speed;
            GetComponent<SpriteRenderer>().color = color;
            yield return new WaitForSeconds(timeInterval);
        }

        for (int x = 0; x < 255; x += speed)
        {
            color.r += speed;
            GetComponent<SpriteRenderer>().color = color;
            yield return new WaitForSeconds(timeInterval);
        }

        for (int x = 0; x < 255; x += speed)
        {
            color.b += speed;
            GetComponent<SpriteRenderer>().color = color;
            yield return new WaitForSeconds(timeInterval);
        }
    }

}
