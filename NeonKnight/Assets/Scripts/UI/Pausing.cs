using UnityEngine;
using System.Collections;

public class Pausing : MonoBehaviour {

	public bool trigPause = false;
	public bool startFrozen = true;
	public float startDelay = 0.5f;

	// Use this for initialization
	void Start () {
	}

	void Update()
	{
		Freeze();

		if(trigPause)
			Pause();
		    PauseMenu();
	}

	void Pause()
	{
		if (trigPause)
			Time.timeScale = 0F;
		else
			Time.timeScale = 1f;
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
			trigPause = false;
		if (GUI.Button (new Rect (Screen.width/2,Screen.height/2,100,50), "Quit"))
			Application.Quit();
	}

	public void pauseGame()
	{
		trigPause = true;
	}

	public void startGame()
	{
		Camera.main.GetComponent<CameraLock>().isPlaying = true;
		startFrozen = false;
		//StartCoroutine (DelayGameStart ());
	}

	IEnumerator DelayGameStart()
	{

		yield return new WaitForSeconds (startDelay);
	}
	
}
