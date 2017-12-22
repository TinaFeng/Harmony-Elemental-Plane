using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public Sprite[] heartSprites;
    public Image heartUI;

    public GameObject PauseUI;
    private bool paused = false;

    public GameObject gemUI;
    public GameObject playerElementUI;

    // Use this for initialization
    void Start () {
        PauseUI.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        CheckPause();
    }

    public void UpdateHealth(int value)
    {
        heartUI.sprite = heartSprites[value];
    }

    private void CheckPause()
    {
        //check pause
        if (Input.GetButtonDown("Pause"))
        {
            paused = !paused;
        }
        if (paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if (!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void ResumeButton()
    {
        paused = false;
    }


    public void UpdateGem(int value)
    {
        gemUI.GetComponent<Text>().text = value.ToString();
    }

    public void UpdatePlayerElement(element element)
    {
        if(element == element.fire)
        {
            playerElementUI.GetComponent<Text>().text = "fire";
        }else if (element == element.air)
        {
            playerElementUI.GetComponent<Text>().text = "air";
        }
        else if (element == element.grass)
        {
            playerElementUI.GetComponent<Text>().text = "grass";
        }
        else
        {
            playerElementUI.GetComponent<Text>().text = "water";
        }
    }

}
