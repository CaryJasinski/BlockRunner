using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class InGameUIManager : MonoBehaviour 
{
	public Canvas inGameUICanvas;
	public Text lifeTextHolder;
	public Text collectibleTextHolder;
	public Text maxCollectibleTextHolder;

	//Use this for initialization
	public void EnableOverlay(bool enabled)
	{
		inGameUICanvas.enabled = enabled;
	}

	void Update ()
	{
		if(inGameUICanvas.enabled)
		{
			lifeTextHolder.text = PersistantData.persistantDataController.playerLives.ToString();
			collectibleTextHolder.text = PersistantData.persistantDataController.bits.ToString();
		}
	}
}