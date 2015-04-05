using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class LevelSelectManager : MonoBehaviour {

	public Canvas levelSelectCanvas;
	
	public void EnableOverlay(bool enabled)
	{
		levelSelectCanvas.enabled = enabled;
		if(enabled)
		{
			//Initialization code goes here
		}
	}

	public void OpenTutorial()
	{
		SceneLoader.manager.SetLevel("Level 1");
		GameManager.manager.SetGameState(GameManager.GameState.InGame);
	}

	public void OpenLevelOne()
	{
		SceneLoader.manager.SetLevel("LevelPrototype");
		GameManager.manager.SetGameState(GameManager.GameState.InGame);
	}

	public void OpenLevelTwo()
	{
		SceneLoader.manager.SetLevel("Level 2");
		GameManager.manager.SetGameState(GameManager.GameState.InGame);
	}
}
