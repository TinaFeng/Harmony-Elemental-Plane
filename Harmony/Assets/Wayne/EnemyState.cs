using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour {
    private int health = 20;
    private bool defeated = false;

  
    public void GetHurt(int value)
        //the monster get hurt and reduce health point
    {
        health -= value;
        CheckHealth();
    }
	
    public void CheckHealth()
        //check the hp to decide if need to do something
    {

        //become unable to move if health<=0
        if (health<=0)
        {
            defeated = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //when touch player
        if(collision.gameObject.tag == "Player")
        {
            //be purified when is defeated and player has gems
            /*
            if(defeated&&)
            {
                
            }*/
        }

    }
}
