using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
    public int requiredHealedEnemy;
    public string destinationScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //when all enemies are healed
        if(collision.gameObject.tag == "Player" && GameObject.Find("Manager").GetComponent<LevelProcessManager>().enemyHealed >= requiredHealedEnemy)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(destinationScene);
        }
    }

}
