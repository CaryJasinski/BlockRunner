using UnityEngine;
using System.Collections;

public class KillVolume : MonoBehaviour {

	public GameObject playerSpawnPosition;

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag("Player")) 
		{
			if(GameObject.Find("GameManager"))
				GameManager.manager.KillPlayer();
			else
				collider.transform.position = playerSpawnPosition.transform.position;
		}
	}
}
