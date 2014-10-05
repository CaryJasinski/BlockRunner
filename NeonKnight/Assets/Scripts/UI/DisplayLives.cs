using UnityEngine;
using System.Collections;

public class DisplayLives : MonoBehaviour {
	public GameObject GameManager;
	private GameManager m_gameManager;

	public GUISkin NeonKnightGUI;
	public Texture2D neonKnightIcon;
	public GUIStyle smallerText;

	void Start () 
	{
		GameManager = GameObject.Find("GameManager"); 
		m_gameManager = GameManager.GetComponent<GameManager>();
	}


	void OnGUI()
	{
		GUI.skin = NeonKnightGUI;
		GUI.Label(new Rect (60, 32, 20, 30), "x", smallerText);
		GUI.Label(new Rect (5, 0, 170, 50), "" + m_gameManager.intPlayerLives + "");
		GUI.Label(new Rect (-5, 0, 100, 50), neonKnightIcon);
	}
}
