using UnityEngine;
using System.Collections;

public class EndPortal : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.CompareTag("Player"))
		{
			int m_currentLevelIndex = Application.loadedLevel;
			Application.LoadLevel(m_currentLevelIndex++);
			PersistantData.persistantDataController.SaveAllData();
		}
	}
}
