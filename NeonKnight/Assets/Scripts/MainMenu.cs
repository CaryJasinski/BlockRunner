using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	public Texture2D startScreen;
	public Texture2D gameOverScreen;
	public Texture2D winScreen;
	public Texture2D pauseIcon;
	public Texture2D playButton;

	//Styles For Buttons
	public GUIStyle startButtonStyle;
	public GUIStyle winScreenStyle;

	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI(){
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
		if (GUI.Button (new Rect(Screen.width / 2 + 50, Screen.height / 2, 300, 300),playButton, startButtonStyle))
		    {
			Application.LoadLevel("2DTest");
		    }
	}

	void showWinScreen(){
		GUI.DrawTexture(new Rect(0f,0f, Screen.width, Screen.height), winScreen);
		if (GUI.Button (new Rect(Screen.width / 2 - 100, Screen.height / 2 + 100, 300, 300),"Play Again?", winScreenStyle))
		{
			Application.LoadLevel("2DTest");
		}
	}


	void showLoseScreen(){
		GUI.DrawTexture(new Rect(0f,0f, Screen.width, Screen.height), gameOverScreen);
		if (GUI.Button (new Rect(Screen.width / 2 - 100, Screen.height / 2 + 100, 300, 300),"Try Again?", winScreenStyle))
		{
			Application.LoadLevel("2DTest");
		}
	}

	
}
