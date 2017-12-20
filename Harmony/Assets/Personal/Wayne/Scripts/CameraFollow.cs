using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public GameObject target;
    public Vector2 leftUpperPoint;// the left upper point the camera can be
    public Vector2 rightLowerPoint;//the right lower point the camera can be
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		//horizontal movement
        if(target.transform.position.x > leftUpperPoint.x && target.transform.position.x < rightLowerPoint.x)
        {
            //when the camera is able to move at x axis, move it to make the target at the center
            transform.position = new Vector3(target.transform.position.x, transform.position.y, transform.position.z);
        }
        //vertical movement
        if (target.transform.position.y < leftUpperPoint.y && target.transform.position.y > rightLowerPoint.y)
        {
            //when the camera is able to move at y axis, move it to make the target at the center
            transform.position = new Vector3(transform.position.x, target.transform.position.y, transform.position.z);
        }

    }
}
