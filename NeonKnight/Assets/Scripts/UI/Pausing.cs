using UnityEngine;
using System.Collections;

public class Pausing : MonoBehaviour {

	public bool trigPause = false;
	public bool startFrozen = true;

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

	void OnGUI()
	    {
		if (Application.loadedLevelName != "MainMenu")
		  if (GUI.Button (new Rect (0,Screen.height - 50,100,50), "Pause"))
			{
				trigPause = true;
	   	    }

		 if (startFrozen && Application.loadedLevelName != "MainMenu")
			 startButton ();
		 
		if(trigPause)
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

	void startButton()
	{
		if (GUI.Button (new Rect (Screen.width/2,Screen.height/2,100,50), "Go!"))
		{
			startFrozen = false;
		}
	}
	
}
