using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class InGameUIManager : MonoBehaviour 
{
	public Canvas inGameUICanvas;
	public Text lifeTextHolder;
	public Text collectibleTextHolder;
	//public Text maxCollectibleTextHolder;
	public Canvas startRunCanvas;


	//Use this for initialization
	public void EnableOverlay(bool enabled)
	{
		inGameUICanvas.enabled = enabled;

		if(enabled)
			startRunCanvas.enabled = true;
		else
			startRunCanvas.enabled = false;
	}

	void Update ()
	{
		if(inGameUICanvas.enabled)
		{
			lifeTextHolder.text = PersistantData.data.playerLives.ToString();
			//collectibleTextHolder.text = PersistantData.data.bits.ToString();
			collectibleTextHolder.text = LevelManager.manager.collectibleManager.GetCollectibleScore().ToString();
		}
	}
}