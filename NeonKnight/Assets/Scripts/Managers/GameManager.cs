using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager manager;
	public GameObject Player;
	private PlayerScript m_playerScript;
	public Transform platformHolder;
	private GameObject[] m_moveablePlatforms;

	void Awake()
	{          //If manager doesn't exist, create one
//		if(manager == null)
//		{
//			DontDestroyOnLoad(gameObject);
//			manager = this;
//		} else if(manager != null)    //if manager does exist, destroy this copy
//		{
//			Destroy(gameObject);
//		}
		manager = this;
	}

	void Start () 
	{
		Player = GameObject.Find("NeonKnight"); 
		m_playerScript = Player.GetComponent<PlayerScript>();

		StartCoroutine(Delayed());
	}

	IEnumerator Delayed()
	{
		yield return new WaitForSeconds(0.5f);
		m_moveablePlatforms = GameObject.FindGameObjectsWithTag ("MasterPlatform");
	}

	void Update () 
	{
		if(PersistantData.persistantDataController.playerLives <= 0)
			Application.LoadLevel("LoseScreen");
	}

	public void KillPlayer()
	{
		Player.transform.position = m_playerScript.startingPosition;
		m_playerScript.playerActive = false;
		PersistantData.persistantDataController.playerLives--;
		ResetPlatformPositions();
	}

	public void ResetPlatformPositions()
	{
		foreach(GameObject platform in m_moveablePlatforms)
		{
			if(platform.GetComponent<GodPlatform>() != null)
			{
				if(platform.GetComponent<GodPlatform>().platformType != GodPlatform.PlatformType.Static)
					platform.transform.position = platform.GetComponent<GodPlatform>().GetStartPosition();
			}
		}
	}
}
