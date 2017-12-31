using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1_4 : MonoBehaviour {
    public float enterRoomX;
    public GameObject Wall;
    private GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(player.transform.position.x > enterRoomX)
        {
            Wall.SetActive(true);
        }
	}
}
