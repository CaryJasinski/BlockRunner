using UnityEngine;
using System.Collections;

public class CollectibleManager : MonoBehaviour {

	private int m_CollectibleScore = 0;
	private GameObject[] m_collectibles;
	
	public void InitializeCollectibles()
	{
		m_CollectibleScore = 0;
		m_collectibles = GameObject.FindGameObjectsWithTag ("Collectible");
	}
	
	public void ResetCollectibles()
	{
		m_CollectibleScore = 0;
		foreach(GameObject collectible in m_collectibles)
		{
			collectible.SetActive(true);
		}
	}

	public void AddCollectibleScore(int value)
	{
		m_CollectibleScore += value;
	}

	public int GetCollectibleScore()
	{
		return m_CollectibleScore;
	}
}
