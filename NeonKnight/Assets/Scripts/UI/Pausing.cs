using UnityEngine;
using System.Collections;

public class Pausing : MonoBehaviour {

	public bool isPaused = false;
	public bool startFrozen = true;
	public float startDelay = 0.5f;
	
	void Update()
	{
		Freeze();
		//Pause ();
	}

	void Pause()
	{
		if (isPaused) 
		{
			Time.timeScale = 0F;
		} 
		else 
		{
			Time.timeScale = 1f;
		}
	}

	void Freeze()
	{
		if (startFrozen) 
		   Time.timeScale = 0F;
		else 
		   Time.timeScale = 1f;
	}

	void PauseMenu()
	{
		if (GUI.Button (new Rect (Screen.width/2,Screen.height/2 - 50,100,50), "Main Menu"))
			Application.LoadLevel("MainMenu");
		if (GUI.Button (new Rect (Screen.width/2,Screen.height/2 - 100,100,50), "Resume"))
			isPaused = false;
		if (GUI.Button (new Rect (Screen.width/2,Screen.height/2,100,50), "Quit"))
			Application.Quit();
	}

	public void PauseGame()
	{
		UIManager.manager.uiState = UIManager.UIState.PauseMenu;
		isPaused = true;
		Time.timeScale = 0F;
	}

	public void ResumeGame()
	{
		UIManager.manager.uiState = UIManager.UIState.InGameUI;
		isPaused = false;
		Time.timeScale = 1F;
	}

	public void TogglePause()
	{
		if (isPaused) 
			ResumeGame();
		else
			PauseGame();
	}

	public void startGame()
	{
		StartCoroutine (DelayGameStart ());
		Camera.main.GetComponent<CameraLock>().isPlaying = true;
		UIManager.manager.uiState = UIManager.UIState.InGameUI;
		startFrozen = false;
	}

	IEnumerator DelayGameStart()
	{

		yield return new WaitForSeconds (startDelay);
	}
	
}
