using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerLifePanel : MonoBehaviour {

	public GameObject lifeTextHolder;
	private Text lifeText;

	void Start ()
	{
		lifeText = lifeTextHolder.GetComponent<Text> ();
	}

	public void SetTextValue(int lifeCount)
	{
		lifeText.text = lifeCount.ToString();
	}
}
