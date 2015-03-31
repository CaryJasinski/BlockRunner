using UnityEngine;
using System.Collections;

public class Pausing : MonoBehaviour {

	public void PauseGame()
	{
		Debug.Log("Pause");
		LevelManager.manager.DisablePlayer();
		UIManager.manager.SetUIState(UIManager.UIState.PauseMenu);
	}

	public void ResumeGame()
	{
		Debug.Log("Resume");
		LevelManager.manager.EnablePlayer();
		UIManager.manager.SetUIState(UIManager.UIState.InGameUI);
	}

	public void TogglePause()
	{
		if (GameManager.manager.gameState == GameManager.GameState.Paused) 
			ResumeGame();
		else
			PauseGame();
	}
}
