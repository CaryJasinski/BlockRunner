using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class InGameUIManager : MonoBehaviour 
{
	public Canvas inGameUICanvas;
	public GameObject lifeTextHolder;

	private Text lifeText;

	void Start ()
	{
		lifeText = lifeTextHolder.GetComponent<Text> ();
		SetTextValue (GameManager.manager.GetComponent<GameManager>().intPlayerLives);
	}

	public void EnableOverlay(bool enabled)
	{
		inGameUICanvas.enabled = enabled;
	}

	public void SetTextValue(int lifeCount)
	{
		lifeText.text = lifeCount.ToString();
	}
}
