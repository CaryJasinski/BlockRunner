using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public static GameObject manager;
	public GameObject Player;
	private PlayerScript m_playerScript;
	public Transform platformHolder;
	private List<Transform> m_moveablePlatforms = new List<Transform>();
	private bool m_blnCanDie = true;

	void Start () 
	{
		manager = this.gameObject;
		Player = GameObject.Find("NeonKnight"); 
		m_playerScript = Player.GetComponent<PlayerScript>();

		StartCoroutine(Delayed());

		if(PersistantData.persistantDataController.playerLives < 0)
			m_blnCanDie = false;
	}

	IEnumerator Delayed()
	{
		yield return new WaitForSeconds(0.5f);
		foreach(Transform platform in transform)
		{
			m_moveablePlatforms.Add (platform.transform);
		}
	}

	void Update () 
	{
		if(m_blnCanDie && PersistantData.persistantDataController.playerLives <= 0)
			Application.LoadLevel("LoseScreen");
	}

	public void KillPlayer()
	{
		Player.transform.position = m_playerScript.startingPosition;
		m_playerScript.playerActive = false;

		if (m_blnCanDie) 
		{
			PersistantData.persistantDataController.playerLives--;
		}

		ResetPlatformPositions();
	}

	public void ResetPlatformPositions()
	{
		foreach(Transform platform in m_moveablePlatforms)
		{
			if(platform.GetComponent<GodPlatform>() != null)
				platform.position = platform.GetComponent<GodPlatform>().GetStartPosition();
		}
	}
}
