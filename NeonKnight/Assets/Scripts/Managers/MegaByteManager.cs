using UnityEngine;
using System.Collections;

public class MegaByteManager : MonoBehaviour {
	public GameObject[] megaByteArray = new GameObject[3];


	// Use this for initialization
	void Start () {
		StartCoroutine(delayed ());
	}

	IEnumerator delayed()
	{
		yield return new WaitForSeconds (0.5f);

		switch (Application.loadedLevel) 
		{
			case 0:
				checkCollection();
				break;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}

	void checkCollection()
	{
		for(int index = 0; index < PersistantData.persistantDataController.level01MegaBytes.Length; index ++)
		{
			megaByteArray[index].GetComponent<MegaByteCollect>().wasCollected=PersistantData.persistantDataController.level01MegaBytes[index];
		}
	}

	public void assignCollection()
	{
		for(int index = 0; index < PersistantData.persistantDataController.level01MegaBytes.Length; index ++)
		{
			PersistantData.persistantDataController.level01MegaBytes[index]=megaByteArray[index].GetComponent<MegaByteCollect>().wasCollected;
			if(megaByteArray[index].GetComponent<MegaByteCollect>().wasCollected)
				PersistantData.persistantDataController.megaBytes+=1;
		}

	}
}
