using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//keep track of the process of the level
public class LevelProcessManager : MonoBehaviour {
    public int gem;
    public int enemyHealed;


	// Use this for initialization
	void Start () {
        gem = 0;
        enemyHealed = 0;
	}
	
	public void ChangeGemNumber(int value)
        //change the gem number by value and update the UI
    {
        gem += value;
        //UIManager......
    }

    public void ChangeHealedEnemyNumber(int value)
    //change the gem number by value and update the UI
    {
        enemyHealed += value;
        //UIManager.....
    }
}
