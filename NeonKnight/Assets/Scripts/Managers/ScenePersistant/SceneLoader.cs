using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour {

	public static SceneLoader manager;

	public enum LoadState { loading, complete, Idel }
	public LoadState loadState = LoadState.Idel;
	private int previousLevelIndex = 0;

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

	public void LoadNextScene()
	{
		int currLevelIndex = previousLevelIndex = Application.loadedLevel;
		loadState = LoadState.loading;
		currLevelIndex++;
		Application.LoadLevel(currLevelIndex);
	}

	public void SetLevel(int levelIndex)
	{
		previousLevelIndex = Application.loadedLevel;
		loadState = LoadState.loading;
		Application.LoadLevel(levelIndex);
	}

	public void SetLevel(string levelName)
	{
		previousLevelIndex = Application.loadedLevel;
		loadState = LoadState.loading;
		Application.LoadLevel(levelName);
	}

	public void LoadMainMenu()
	{
		previousLevelIndex = Application.loadedLevel;
		loadState = LoadState.loading;
		DestroyPersistantObjects();
		Application.LoadLevel(0);
	}

	public void DestroyPersistantObjects()
	{
		Destroy(GameObject.FindGameObjectWithTag("GameManager"));
		Destroy(GameObject.FindGameObjectWithTag("UIManager"));
		Destroy(GameObject.FindGameObjectWithTag("FingerGestures"));
		Destroy(GameObject.FindGameObjectWithTag("Gestures"));
		Destroy(GameObject.FindGameObjectWithTag("MainCamera"));
	}

	void Update () 
	{
		if(Application.loadedLevel != previousLevelIndex)
		{
			loadState = LoadState.complete;
			previousLevelIndex = Application.loadedLevel;
		}
	}
}
