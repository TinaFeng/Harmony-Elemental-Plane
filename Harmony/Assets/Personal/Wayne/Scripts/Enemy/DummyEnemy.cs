 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//a enemy that only goes left and right

public class DummyEnemy : MonoBehaviour {
    public Vector2[] velocityArray;//X denotes the X velocity, Y here is how much time the enemy moves

	// Use this for initialization
	void Start () {
        StartCoroutine(Move());

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Move()
        //go through the velocityArray and move by the information show in Vector2 
    {
        while (true)
        {
            foreach (Vector3 v in velocityArray)
            {
                //set the velocity
                GetComponent<Rigidbody2D>().velocity = new Vector2(v.x, GetComponent<Rigidbody2D>().velocity.y);
                //wait for movement
                yield return new WaitForSeconds(v.y);
            }
        }
    }
}
