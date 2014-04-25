using UnityEngine;
using System.Collections;

public class KillVolume : MonoBehaviour {
	public GameObject GameManager;
	private GameManager m_gameManager;

	void Awake ()
	{
		if(GameManager == null)
			GameManager = GameObject.FindGameObjectWithTag("GameManager");

		m_gameManager = GameManager.GetComponent<GameManager>();
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag("Player")) 
		{
			Debug.Log ("Why does this work :/");
			m_gameManager.SendMessage ("KillPlayer");
		}
	}
}
