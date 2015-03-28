using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public static LevelManager manager;
	public PlayerManager playerManager;
	public CollectibleManager collectibleManager;

	void Awake()
	{          
		manager = this;

		playerManager = GetComponent<PlayerManager>();
		collectibleManager = GetComponent<CollectibleManager> ();
	}

	public GameObject GetPlayerInstance()
	{
		return GetComponent<PlayerManager>().GetPlayer();
	}

	public void EnablePlayer()
	{
		GetComponent<PlayerManager>().EnablePlayer();
	}

	public void DisablePlayer()
	{
		GetComponent<PlayerManager>().DisablePlayer();
	}

	//Everything that needs to be setup when the level is first loaded.
	public void InitializeLevel()
	{
		playerManager.InitializePlayer();
		collectibleManager.InitializeCollectibles();
		GetComponent<PlatformManager>().InitializePlatorms();
		GetComponent<MegaByteManager>().LoadCollectedMegaBytes();
	}
	
	//Everything that needs to be reset upon player death 
	public void ResetLevel()
	{
		playerManager.ResetPlayer();
		collectibleManager.ResetCollectibles();
		GetComponent<PlatformManager>().ResetPlatformPositions();
		GetComponent<MegaByteManager>().LoadCollectedMegaBytes();
	}
}
