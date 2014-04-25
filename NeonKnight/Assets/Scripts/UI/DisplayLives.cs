using UnityEngine;
using System.Collections;

public class DisplayLives : MonoBehaviour {
	public GameObject GameManager;
	private GameManager m_gameManager;

	public GUISkin NeonKnightGUI;
	public Texture2D neonKnightIcon;

	void Start () 
	{
		GameManager = GameObject.Find("GameManager"); 
		m_gameManager = GameManager.GetComponent<GameManager>();
	}


	void OnGUI()
	{
		GUI.skin = NeonKnightGUI;
		GUI.Label(new Rect (0, 0, 170, 50), "x" + m_gameManager.intPlayerLives/2 + "");
		GUI.Label(new Rect (0, 0, 100, 50), neonKnightIcon);
	}
}
