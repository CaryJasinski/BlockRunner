using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	public Texture2D startScreen;
	public Texture2D gameOverScreen;
	public Texture2D winScreen;
	public Texture2D pauseIcon;
	public Texture2D playButton;

	//Styles for buttons
	public GUIStyle playButtonStyle;
//	public GUIStyle instructionButtonStyle;
	
	
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
			
			//GUI.Label(new Rect(Screen.width / 2 - 500, Screen.height / 2 - 250, 1024, 576), startScreen);		
			//if(GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 200, 50)		              
	}
	
	
	void showTitleScreen(){
		GUI.DrawTexture(new Rect(0f,0f, Screen.width, Screen.height), startScreen);

		GUI.Button (new Rect(Screen.width / 2 + 50, Screen.height / 2 - 150, 300, 300), playButton, playButtonStyle); 
	}

	
}
