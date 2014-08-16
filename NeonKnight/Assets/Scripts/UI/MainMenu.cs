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
	public AudioSource backButton;
	public GUISkin NeonKnightGUI;

	void OnGUI(){

		GUI.skin = NeonKnightGUI;

		if (Application.loadedLevelName == "MainMenu") 
			{
				show3DTitle();		
			}

		if(Application.loadedLevelName == "WinScreen")
			{
				showWinScreen();
			}

		if(Application.loadedLevelName == "LoseScreen")
			{
				showLoseScreen();
			}
              
	}


	void show3DTitle(){
		GUI.Label(new Rect(Screen.width/2 - 300, Screen.height/2 - 50, 1024,300), "Swipe To Begin!");
	}

	void showWinScreen(){
		GUI.DrawTexture(new Rect(0f,0f, Screen.width, Screen.height), winScreen);
		if (GUI.Button (new Rect(Screen.width/2 - 535, Screen.height/2, 1024, 288),""))
		{
			backButton.Play();
			StartCoroutine(startGame(0.5f));
		}

		GUI.Label(new Rect(Screen.width/2 - 512, Screen.height/2 - 150, 1024,576), playAgain);
	}


	void showLoseScreen(){
		GUI.DrawTexture(new Rect(0f,0f, Screen.width, Screen.height), gameOverScreen);
		if (GUI.Button (new Rect(Screen.width/ 2 - 535, Screen.height/ 2, 1024, 288),""))
		{
			backButton.Play();
			StartCoroutine(startGame(0.5f));
		}
		GUI.Label(new Rect(Screen.width/2 - 512, Screen.height/2 - 150, 1024,576), tryAgain);
	}

	IEnumerator startGame(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);

		switch(Application.loadedLevelName)
		{
		case "LoseScreen":
			Application.LoadLevel("Level 1-1");
			break;
		case "WinScreen":
			Application.LoadLevel("MainMenu");
			break;
		}
	}

	
}
