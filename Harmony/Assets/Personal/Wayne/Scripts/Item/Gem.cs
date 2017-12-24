using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour {
    public AudioClip collectGem;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //
        if(collision.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(collectGem, new Vector3(0, 0, 0));
            Destroy(this.gameObject);
            GameObject.Find("Manager").GetComponent<LevelProcessManager>().ChangeGemNumber(1);
        }
    }
}
