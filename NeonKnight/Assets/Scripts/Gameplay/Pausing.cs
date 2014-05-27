using UnityEngine;
using System.Collections;

public class Pausing : MonoBehaviour {

	public bool trigPause = false;

	// Use this for initialization
	void Start () {
	}

	void Update()
	{
		if(trigPause)
			Pause();
		    PauseMenu();
		if(!trigPause)
		 Time.timeScale = 1.0F;
	}

	void OnGUI()
	    {
		  if (GUI.Button (new Rect (0,Screen.height - 50,100,50), "Pause"))
			{
				Debug.Log("you clicked");
				trigPause = true;
	   	    }
		 
		if(trigPause)
			PauseMenu();
	}

	void Pause()
	{
		if(trigPause)
			Time.timeScale = 0F;
	}

	void PauseMenu()
	{
		if (GUI.Button (new Rect (Screen.width/2,Screen.height/2,100,50), "Main Menu"))
			Application.LoadLevel("MainMenu");
		if (GUI.Button (new Rect (Screen.width/2,Screen.height/2 - 50,100,50), "Resume"))
			trigPause = false;
	}

}
