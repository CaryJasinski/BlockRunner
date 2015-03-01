using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//Persistant Managers 
	public static GameManager manager;
	public SceneLoader sceneLoader;
	public AudioManager audioManager;
	public CameraManager cameraManager;

	public enum GameState { Splash, Menus, InGame, Paused, Empty}
	public GameState gameState = GameState.Splash;

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


//public class GameManager : MonoBehaviour {
//
//	public static GameManager manager;
//	public GameObject Player;
//	public GameObject megaByteManager;
//	private PlayerScript m_playerScript;
//	public Transform platformHolder;
//	private GameObject[] m_moveablePlatforms;
//	public int bitValue = 1;
//	public int byteValue = 8;
//
//	void Awake()
//	{          //If manager doesn't exist, create one
//		if(manager == null)
//		{
//			DontDestroyOnLoad(gameObject);
//			manager = this;
//		} else if(manager != null)    //if manager does exist, destroy this copy
//		{
//			Destroy(gameObject);
//		}
//		manager = this;
//	}
//
//	void Start () 
//	{
//		if(Application.loadedLevelName == "LevelPrototype")
//		{
//			Player = GameObject.Find("NeonKnight"); 
//			m_playerScript = Player.GetComponent<PlayerScript>();
//		}
//
//		StartCoroutine(Delayed());
//	}
//
//	IEnumerator Delayed()
//	{
//		yield return new WaitForSeconds(0.5f);
//		m_moveablePlatforms = GameObject.FindGameObjectsWithTag ("MasterPlatform");
//	}
//
//	void Update () 
//	{
//		if(PersistantData.data.playerLives <= 0)
//			Application.LoadLevel("LoseScreen");
//	}
//
//	public void KillPlayer()
//	{
//		Player.transform.position = m_playerScript.startingPosition;
//		m_playerScript.playerActive = false;
//		PersistantData.data.playerLives--;
//		ResetPlatformPositions();
//		StartCoroutine(ResumePlayer());
//		TutorialText.tutorialText.DeathReset();
//	}
//
//	IEnumerator ResumePlayer()
//	{
//		yield return new WaitForSeconds(0.5f);
//		m_playerScript.playerActive = true;
//	}
//
//	public void ResetPlatformPositions()
//	{
//		foreach(GameObject platform in m_moveablePlatforms)
//		{
//			if(platform.GetComponent<GodPlatform>() != null)
//			{
//				if(platform.GetComponent<GodPlatform>().platformType != GodPlatform.PlatformType.Static)
//					platform.transform.position = platform.GetComponent<GodPlatform>().GetStartPosition();
//			}
//		}
//	}
//
//	public void LevelSuccess()
//	{
//		UIManager.manager.uiState = UIManager.UIState.LevelSuccess;
//		Time.timeScale = 0f;
//		megaByteManager.GetComponent<MegaByteManager>().SaveCollectedMegaBytes();
//		PersistantData.data.SaveAllData();
//	}
//}
