using UnityEngine;
using System.Collections;

public class LevelDisplay : MonoBehaviour {
	public GUISkin NeonKnightGUI;

	void OnGUI()
	{
		GUI.skin = NeonKnightGUI;
		GUI.Label(new Rect (Screen.width - 190,0,170,50), Application.loadedLevelName);	
	}
}
