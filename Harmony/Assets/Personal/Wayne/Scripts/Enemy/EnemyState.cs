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

    public AudioClip hurtSE;

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
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            GetComponent<Collider2D>().isTrigger = true;
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
            if (defeated && levelManager.gem > 0)
            {
                //heal this enemy
                Destroy(this.gameObject);
                levelManager.ChangeGemNumber(-1);
                levelManager.ChangeHealedEnemyNumber(1);
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
