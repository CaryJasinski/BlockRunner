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

	public void OpenLevel()
	{
		SceneLoader.manager.SetLevel(1);
		GameManager.manager.SetGameState(GameManager.GameState.InGame);
	}
}
