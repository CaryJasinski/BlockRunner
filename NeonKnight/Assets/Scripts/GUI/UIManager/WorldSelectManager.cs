using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class WorldSelectManager : MonoBehaviour {

	public Canvas worldSelectCanvas;
	
	public void EnableOverlay(bool enabled)
	{
		worldSelectCanvas.enabled = enabled;
		if(enabled)
		{
			//Initialization code goes here
		}
	}

	public void OpenWorldOneMenu()
	{
		Debug.Log("World 1 _ Clicked");
		UIManager.manager.SetUIState(UIManager.UIState.LevelSelect);
	}
}
