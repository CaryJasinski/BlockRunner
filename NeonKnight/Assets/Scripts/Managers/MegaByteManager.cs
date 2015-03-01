using UnityEngine;
using System.Collections;

public class MegaByteManager : MonoBehaviour {

	public GameObject[] megaByteArray = new GameObject[3];
	public Sprite collectedSprite;

	void Start () 
	{
		//LoadCollectedMegaBytes();
	}

	public void SaveCollectedMegaBytes()
	{
		for(int index = 0; index < PersistantData.data.megaBytesPerLevel[Application.loadedLevel].Length; index ++)
		{
			PersistantData.data.megaBytesPerLevel[Application.loadedLevel][index] = megaByteArray[index].GetComponent<MegaByteCollect>().wasCollected;
		}
	}

	public void LoadCollectedMegaBytes()
	{
		for(int index = 0; index < PersistantData.data.megaBytesPerLevel[Application.loadedLevel].Length; index ++)
		{
			if(PersistantData.data.megaBytesPerLevel[Application.loadedLevel][index])
			{
				megaByteArray[index].GetComponent<SpriteRenderer>().sprite = collectedSprite;
				megaByteArray[index].GetComponent<MegaByteCollect>().wasCollected = PersistantData.data.megaBytesPerLevel[Application.loadedLevel][index];
			}
		}
	}
}
