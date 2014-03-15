using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {
	public int intPlayerLives = 5;
	public GUISkin NeonKnightGUI;

	void Start ()
	{
		intPlayerLives *= 2;
	}
	public void deductLife()
	{
		intPlayerLives--;
		if(intPlayerLives <= 0)
			Application.LoadLevel("LoseScreen");
	}

	void OnGUI()
	{
		GUI.skin = NeonKnightGUI;
		GUI.Label(new Rect (0, 0, 170, 50), "Lives: " + intPlayerLives/2 + "");
	}
}
