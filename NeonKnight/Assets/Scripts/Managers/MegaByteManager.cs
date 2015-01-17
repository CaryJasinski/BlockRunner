using UnityEngine;
using System.Collections;

public class MegaByteManager : MonoBehaviour {

	public GameObject[] megaByteArray = new GameObject[3];
	public Sprite collectedSprite;
	void Start () 
	{
		LoadCollectedMegaBytes();
	}

	public void SaveCollectedMegaBytes()
	{
		for(int index = 0; index < PersistantData.persistantDataController.megaBytesPerLevel[Application.loadedLevel].Length; index ++)
		{
			PersistantData.persistantDataController.megaBytesPerLevel[Application.loadedLevel][index] = megaByteArray[index].GetComponent<MegaByteCollect>().wasCollected;
			if(megaByteArray[index].GetComponent<MegaByteCollect>().wasCollected)
				PersistantData.persistantDataController.megaBytes+=1;
		}
		
	}

	public void LoadCollectedMegaBytes()
	{
		Color tempColor;
		for(int index = 0; index < PersistantData.persistantDataController.megaBytesPerLevel[Application.loadedLevel].Length; index ++)
		{
			if(PersistantData.persistantDataController.megaBytesPerLevel[Application.loadedLevel][index])
			{
				megaByteArray[index].GetComponent<SpriteRenderer>().sprite = collectedSprite;
				megaByteArray[index].GetComponent<MegaByteCollect>().wasCollected = PersistantData.persistantDataController.megaBytesPerLevel[Application.loadedLevel][index];
			}
		}
	}

	//Old 
//	public void SaveCollectedMegaBytes()
//	{
//		for(int index = 0; index < PersistantData.persistantDataController.level01MegaBytes.Length; index ++)
//		{
//			PersistantData.persistantDataController.level01MegaBytes[index]=megaByteArray[index].GetComponent<MegaByteCollect>().wasCollected;
//			if(megaByteArray[index].GetComponent<MegaByteCollect>().wasCollected)
//				PersistantData.persistantDataController.megaBytes+=1;
//		}
//
//	}

	//Old 
	//	public void LoadCollectedMegaBytes()
	//	{
	//		for(int index = 0; index < PersistantData.persistantDataController.level01MegaBytes.Length; index ++)
	//		{
	//			megaByteArray[index].GetComponent<MegaByteCollect>().wasCollected=PersistantData.persistantDataController.level01MegaBytes[index];
	//		}
	//	}

}
