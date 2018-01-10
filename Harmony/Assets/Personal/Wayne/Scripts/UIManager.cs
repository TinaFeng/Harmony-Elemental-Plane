using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public Sprite[] heartSprites;
    public Image heartUI;

    public GameObject PauseUI;
    private bool paused = false;
    private bool gameOver = false;

    public GameObject gameOverUI;
    public string currentScene;

    public GameObject gemUI;
    public Sprite[] elementSprites;
    public GameObject playerElementUI;

    public bool startWithElement;
    // Use this for initialization
    void Start () {
        PauseUI.SetActive(false);
        if(startWithElement)
        {
            playerElementUI.GetComponent<Image>().sprite = elementSprites[GameObject.Find("Player").GetComponent<PlayerElement>().GetElementNumber() - 1];
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        if(!gameOver)
        {
            CheckPause();
        }
        
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

    public void RestartButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentScene);
    }

    public void ShowGameOverUI()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0;
        gameOver = true;
    }

    public void UpdateGem(int value)
    {
        gemUI.GetComponent<Text>().text = value.ToString();
    }

    public void UpdatePlayerElement(element element)
    {
        if(element == element.fire)
        {
            playerElementUI.GetComponent<Image>().sprite = elementSprites[3];
        }else if (element == element.air)
        {
            playerElementUI.GetComponent<Image>().sprite = elementSprites[0];
        }
        else if (element == element.grass)
        {
            playerElementUI.GetComponent<Image>().sprite = elementSprites[1];
        }
        else
        {
            playerElementUI.GetComponent<Image>().sprite = elementSprites[2];
        }
    }

}
