using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {
	
	public enum UIState { StartMenu, InGameUI, LevelFail, LevelSuccess, PauseMenu };
	public GameObject playerLifeObject;
	public GameObject collectableCountObject;
	public GameObject levelNameObject;

	private PlayerLifePanel playerLifePanel; 

	void Start () 
	{
		playerLifePanel = playerLifeObject.GetComponent<PlayerLifePanel> ();
	}

	public void UpdateLifeDisplay(int lifeCount)
	{
		playerLifePanel = playerLifeObject.GetComponent<PlayerLifePanel> ();
		playerLifePanel.SetTextValue (lifeCount);
	}
}
