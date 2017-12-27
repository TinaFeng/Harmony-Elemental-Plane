using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour {
	public string MainMenuScene;
	public string destinationScene; 
	public void StartGame(){
		UnityEngine.SceneManagement.SceneManager.LoadScene (destinationScene);
	}
	public void QuitGame(){
		Debug.Log("Game will now Quit");
		Application.Quit ();
	}
	public void LoadMainMenu(){
		UnityEngine.SceneManagement.SceneManager.LoadScene (MainMenuScene);
	} 
		
}
//UnityEngine.SceneManagement.SceneManager.LoadScene(destinationScene);