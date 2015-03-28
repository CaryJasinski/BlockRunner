using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//Persistant Managers 
	public static GameManager manager;
	public SceneLoader sceneLoader;
	public AudioManager audioManager;
	public CameraManager cameraManager;

	public enum GameState { Splash, Menus, InGame, Paused, Empty }
	public GameState gameState = GameState.Splash;

	public float onStartRunDelay = 0.25f;
	public int bitValue = 1;
	public int byteValue = 8;

	void Awake()
	{          
		if(manager == null)           //If manager doesn't exist, create one
		{
			DontDestroyOnLoad(gameObject);
			manager = this;
		} else if(manager != null)    //if manager does exist, destroy this copy
		{
			Destroy(gameObject);
		}
		manager = this;
	}

	void Update () 
	{
		if(SceneLoader.manager.loadState == SceneLoader.LoadState.complete)
		{
			InitializeGameState();
			SceneLoader.manager.loadState = SceneLoader.LoadState.Idel;
		}
	}

	//============================================
	// Public Methods
	//============================================
	
	public void SetGameState(GameState newGameState)
	{
		gameState = newGameState;
		//InitializeGameState();
	}
	
	public void InitializeRun()
	{
		Debug.Log("InitializeRun");
		LevelManager.manager.InitializeLevel();
	}

	public void StartRun()
	{
		StartCoroutine(DelayStart());
	}

	IEnumerator DelayStart()
	{
		yield return new WaitForSeconds(onStartRunDelay);
		LevelManager.manager.EnablePlayer();
	}
	public void KillPlayer()
	{
		if(PersistantData.data.playerLives > 0)
		{
			PersistantData.data.playerLives--;
			LevelManager.manager.ResetLevel();
			UIManager.manager.SetUIState(UIManager.UIState.InGameUI);
		}
		else
		{
			LevelManager.manager.DisablePlayer();
			UIManager.manager.SetUIState(UIManager.UIState.LevelFail);
		}
	}

	public void LevelSuccess()
	{
		LevelManager.manager.DisablePlayer();
		UIManager.manager.SetUIState(UIManager.UIState.LevelSuccess);
		MegaByteManager.manager.SaveCollectedMegaBytes();
		PersistantData.data.bits = LevelManager.manager.collectibleManager.GetCollectibleScore ();
		PersistantData.data.SaveAllData();
	}

	//============================================
	// Private Methods
	//============================================

	void InitializeGameState()
	{
		switch(gameState)
		{
		case GameState.Splash:
			//Splash Initialization Code
			break;
		case GameState.Menus:

			break; 
		case GameState.InGame:
			UIManager.manager.SetUIState(UIManager.UIState.InGameUI);
			InitializeRun();
			break;
		case GameState.Paused:

			break;
		case GameState.Empty:
		default:

			break;
		}
	}
}