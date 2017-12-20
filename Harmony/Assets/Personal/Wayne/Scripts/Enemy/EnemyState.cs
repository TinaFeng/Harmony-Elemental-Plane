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

    private void Start()
    {
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //when touch player when is defeated
        if(collision.gameObject.tag == "Player")
        {
            //test if have enough gems
            if (defeated && GameObject.Find("Manager").GetComponent<LevelProcessManager>().gem == 0)
            {
                Destroy(this.gameObject);
            }
            
        }
        //when be attacked
        if(collision.gameObject.tag == "PlayerElement" && canHurt)
        {
            GetHurt(collision.gameObject.GetComponent<ElementAttribution>().intAttack);
        }

    }

    IEnumerator Invincivable()
    {
        //let the enemy invincible for 1 seconds after lose one heart
        this.GetComponent<SpriteRenderer>().color = new Color32(color.a, color.b, color.g, 155);
        yield return new WaitForSeconds(1f);
        this.GetComponent<SpriteRenderer>().color = new Color32(color.a, color.b, color.g, 255);
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
}
