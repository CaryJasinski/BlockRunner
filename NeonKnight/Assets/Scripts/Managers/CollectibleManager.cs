using UnityEngine;
using System.Collections;

public class CollectibleManager : MonoBehaviour {

	private GameObject[] m_collectibles;
	
	public void InitializeCollectibles()
	{
		m_collectibles = GameObject.FindGameObjectsWithTag ("Collectible");
	}
	
	public void ResetCollectibles()
	{
		foreach(GameObject collectible in m_collectibles)
		{
			collectible.SetActive(true);
		}
	}

}
