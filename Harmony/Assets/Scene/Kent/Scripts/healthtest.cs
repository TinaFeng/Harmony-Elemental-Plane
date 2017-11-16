using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthtest : MonoBehaviour {

	public Sprite[] HeartSprites; 
	public int x = 0; //only here until i can retrieve player health
	public Image HeartUI;

	void Update() {
		HeartUI.sprite = HeartSprites [x]; // will retrieve player health variable on update, 
		//changes sprite based on health of player
	}
}
