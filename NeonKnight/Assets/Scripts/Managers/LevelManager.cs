using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public static LevelManager manager;

	void Awake()
	{          
		manager = this;
	}

	public void StartRun()
	{
		GetComponent<PlayerManager>().EnablePlayer();
	}

	public void LevelFail()
	{
		GetComponent<PlayerManager>().DisablePlayer();
	}

	//Everything that needs to be setup when the level is first loaded.
	public void InitializeLevel()
	{
		GetComponent<PlayerManager>().InitializePlayer();
		GetComponent<PlatformManager>().InitializePlatorms();
		GetComponent<CollectibleManager>().InitializeCollectibles();
		GetComponent<MegaByteManager>().LoadCollectedMegaBytes();
	}
	
	//Everything that needs to be reset upon player death 
	public void ResetLevel()
	{
		GetComponent<PlayerManager>().ResetPlayer();
		GetComponent<PlatformManager>().ResetPlatformPositions();
		GetComponent<CollectibleManager>().ResetCollectibles();
		GetComponent<MegaByteManager>().LoadCollectedMegaBytes();
	}
}
