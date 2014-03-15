using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	public Texture2D startScreen;
	public Texture2D gameOverScreen;
	public Texture2D winScreen;
	public Texture2D pauseIcon;
	public Texture2D playButton;
	public Texture2D playAgain;
	public Texture2D tryAgain;
	public GUISkin NeonKnightGUI;

	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI(){

		GUI.skin = NeonKnightGUI;

		if(Application.loadedLevelName == "MainMenu"){
			showTitleScreen();
		}

		if(Application.loadedLevelName == "WinScreen"){
			showWinScreen();
		}

		if(Application.loadedLevelName == "LoseScreen"){
			showLoseScreen();
		}
              
	}
	
	
	void showTitleScreen(){
		GUI.DrawTexture(new Rect(0f,0f, Screen.width, Screen.height), startScreen);
		if (GUI.Button (new Rect(Screen.width/ 2 - 150, Screen.height/2 + 20, 1024, 288),""))
		    {
			Application.LoadLevel("Tutorial");
		    }
		GUI.Label(new Rect(Screen.width/2 - 100, Screen.height/2 - 100, 1024,576), playButton);
	}

	void showWinScreen(){
		GUI.DrawTexture(new Rect(0f,0f, Screen.width, Screen.height), winScreen);
		if (GUI.Button (new Rect(Screen.width/2 - 535, Screen.height/2 + 120, 1024, 288),""))
		{
			Application.LoadLevel("MainMenu");
		}

		GUI.Label(new Rect(Screen.width/2 - 512, Screen.height/2, 1024,576), playAgain);
	}


	void showLoseScreen(){
		GUI.DrawTexture(new Rect(0f,0f, Screen.width, Screen.height), gameOverScreen);
		if (GUI.Button (new Rect(Screen.width/ 2 - 535, Screen.height/ 2 + 120, 1024, 288),""))
		{
			Application.LoadLevel("MainMenu");
		}
		GUI.Label(new Rect(Screen.width/2 - 512, Screen.height/2, 1024,576), tryAgain);
	}

	
}
