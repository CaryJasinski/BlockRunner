using UnityEngine;
using System.Collections;

public class Pausing : MonoBehaviour {

	public bool isPaused = false;
	public bool startFrozen = true;
	public float startDelay = 0.5f;

	void Start()
	{
		Freeze ();
	}

	public void Freeze()
	{
		Time.timeScale = 0f;
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.P))
		   startGame(); 
	}

	public void PauseGame()
	{
		isPaused = true;
		Time.timeScale = 0f;
		UIManager.manager.uiState = UIManager.UIState.PauseMenu;
	}

	public void ResumeGame()
	{
		isPaused = false;
		Time.timeScale = 1f;
		UIManager.manager.uiState = UIManager.UIState.InGameUI;
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
		Time.timeScale = 1f;
	}

	IEnumerator DelayGameStart()
	{
		yield return new WaitForSeconds (startDelay);
	}
	
}
