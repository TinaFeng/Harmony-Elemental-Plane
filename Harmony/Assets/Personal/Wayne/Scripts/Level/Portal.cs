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
            //int elementNumber = collision.gameObject.GetComponent<PlayerElement>().GetElementNumber();
            UnityEngine.SceneManagement.SceneManager.LoadScene(destinationScene);
            //GameObject.Find("Player").GetComponent<PlayerElement>().SetElementNumber(elementNumber);
            //save all the se
            foreach(GameObject go in GameObject.FindObjectsOfType<UnityEngine.GameObject>())
            {
                if(go.name == "One shot audio")
                {
                    DontDestroyOnLoad(go);
                }
            }

        }
    }

}
