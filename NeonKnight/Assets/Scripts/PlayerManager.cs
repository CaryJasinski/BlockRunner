using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {
	public int intPlayerLives = 5;
	public GUISkin NeonKnightGUI;
	
	public void deductLife()
	{
		if(intPlayerLives > 0)
			intPlayerLives--;
		else
			Application.LoadLevel("LoseScreen");
	}

	void OnGUI()
	{
		GUI.skin = NeonKnightGUI;
		GUI.Label(new Rect (0, 10, 200, 200), "Lives: "+intPlayerLives+"");
	}
}
