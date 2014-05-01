using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject Player;
	private PlayerScript m_playerScript;
	public int intCollectibles = 0;
	public int intPlayerLives = 5;
	private GameObject[] m_moveablePlatforms;
	private bool m_blnCanDie = true;

	void Start () 
	{
		Player = GameObject.Find("NeonKnight"); 
		m_playerScript = Player.GetComponent<PlayerScript>();
		m_moveablePlatforms = GameObject.FindGameObjectsWithTag("MoveablePlatform");
		if(intPlayerLives > 0)
			intPlayerLives *= 2;
		else
			m_blnCanDie = false;
	}

	void Update () 
	{
		if(m_blnCanDie && intPlayerLives <= 0)
			Application.LoadLevel("LoseScreen");
	}
	

	public void KillPlayer()
	{
		Player.transform.position = m_playerScript.StartingPosition;
		m_playerScript.blnPlayerActive = false;

		if(m_blnCanDie)
			intPlayerLives--;

		ResetPlatformPositions();
	}

	public void ResetPlatformPositions()
	{
		foreach(GameObject platform in m_moveablePlatforms)
		{
			if(platform.GetComponent<HorizontalPlatformBehavior>() != null)
				platform.transform.position = platform.GetComponent<HorizontalPlatformBehavior>().GetStartPosition();
			if(platform.GetComponent<VerticalPlatformBehavior>() != null)
				platform.transform.position = platform.GetComponent<VerticalPlatformBehavior>().GetStartPosition();
		}
	}

	public void IncreaseScore()
	{
		intCollectibles +=1;
	}
}
