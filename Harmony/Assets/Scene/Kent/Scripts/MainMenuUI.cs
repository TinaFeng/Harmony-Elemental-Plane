﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour {
    public GameObject MainMenuCanvas;
    public GameObject CreditsCanvas;
    public GameObject InstructionCanvas;
	public string MainMenuScene;
	public string destinationScene;

    private void Start(){
        MainMenuCanvas.SetActive(true);
        CreditsCanvas.SetActive(false);
        InstructionCanvas.SetActive(false);
    }
    
    public void StartGame(){
		UnityEngine.SceneManagement.SceneManager.LoadScene (destinationScene);
	}

    public void Credits()
    {
        MainMenuCanvas.SetActive(false);
        CreditsCanvas.SetActive(true);
    }
    public void Return()
    {
        Start();
    }
	public void QuitGame(){
		Debug.Log("Game will now Quit");
		Application.Quit ();
	}
	public void LoadMainMenu(){
		UnityEngine.SceneManagement.SceneManager.LoadScene (MainMenuScene);
	} 
	
    public void Instruction()
    {
        MainMenuCanvas.SetActive(false);
        InstructionCanvas.SetActive(true);
    }

}
//UnityEngine.SceneManagement.SceneManager.LoadScene(destinationScene);