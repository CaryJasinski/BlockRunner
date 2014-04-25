using UnityEngine;
using System.Collections;

public class DisplayScore : MonoBehaviour {

	private GameObject[] m_collectibles;
	public GameObject GameManager;
	private GameManager m_gameManager;
	
	public GUISkin NeonKnightGUI;
	public Texture2D collectIcon;
	
	void Start () 
	{
		GameManager = GameObject.Find("GameManager"); 
		m_gameManager = GameManager.GetComponent<GameManager>();
		m_collectibles = GameObject.FindGameObjectsWithTag("Collectible");
	}
	
	
	void OnGUI()
	{
		GUI.skin = NeonKnightGUI;
		GUI.Label(new Rect (Screen.width / 2 - 100, 10, 200, 50), ""+m_gameManager.intCollectibles+ "/"+ m_collectibles.Length);
		GUI.Label(new Rect (Screen.width / 2 - 150, 10, 200, 50), collectIcon);
	}

}
