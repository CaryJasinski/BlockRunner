using UnityEngine;
using System.Collections;

public class KillVolume : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag("Player")) 
		{
			GameManager.manager.KillPlayer();
		}
	}
}
