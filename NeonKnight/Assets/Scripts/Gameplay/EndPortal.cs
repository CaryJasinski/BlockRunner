using UnityEngine;
using System.Collections;

public class EndPortal : MonoBehaviour {

	private int m_currentLevelIndex;

	void Start()
	{
		m_currentLevelIndex = Application.loadedLevel;
	}
	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.CompareTag("Player"))
		{
			Application.LoadLevel(m_currentLevelIndex++);
		}
	}
}
