using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {
	
	public enum UIState { StartMenu, InGameUI, LevelFail, LevelSuccess, PauseMenu, Credits };
	public UIState uiState = UIState.StartMenu;
	public UIState previousUIState;
	public static UIManager manager;

	private StartMenuManager startMenu;
	private InGameUIManager inGameUI;
	private PauseMenuManager pauseMenu;
	private LevelFailManager levelFail;
	private LevelSuccessManager levelSuccess;
	private CreditsMenuManager creditMenu;

	void Start () 
	{
		manager = GetComponent<UIManager> ();
		startMenu = GetComponent<StartMenuManager> ();
		inGameUI = GetComponent<InGameUIManager> ();
		pauseMenu = GetComponent<PauseMenuManager> ();
		levelFail = GetComponent<LevelFailManager> ();
		levelSuccess = GetComponent<LevelSuccessManager> ();
		creditMenu = GetComponent<CreditsMenuManager> ();
	}

	void Update()
	{
		if (!Application.isLoadingLevel && previousUIState != uiState) 
		{
			SetUIState ();
		}
	}

	public void UpdateLifeDisplay(int lifeCount)
	{
		inGameUI.SetTextValue (lifeCount);
	}

	void SetUIState()
	{
		if (uiState == UIState.StartMenu) 
		{
			previousUIState = UIState.StartMenu;
			startMenu.EnableOverlay (true);
		} 
		else
			startMenu.EnableOverlay (false);

		if (uiState == UIState.InGameUI) 
		{
			previousUIState = UIState.InGameUI;
			inGameUI.EnableOverlay (true);
		} 
		else
			inGameUI.EnableOverlay (false);

		if (uiState == UIState.PauseMenu) 
		{
			previousUIState = UIState.PauseMenu;
			pauseMenu.EnableOverlay(true);
		} 
		else
			pauseMenu.EnableOverlay(false);

		if (uiState == UIState.LevelFail) 
		{
			previousUIState = UIState.LevelFail;
			levelFail.EnableOverlay(true);
		} 
		else
			levelFail.EnableOverlay(false);

		if (uiState == UIState.LevelSuccess) 
		{
			previousUIState = UIState.LevelSuccess;
			levelSuccess.EnableOverlay(true);
		} 
		else
			levelSuccess.EnableOverlay(false);

		if (uiState == UIState.Credits) 
		{
			previousUIState = UIState.Credits;
			creditMenu.EnableOverlay(true);
		}
		else
			creditMenu.EnableOverlay(false);
	}
}
