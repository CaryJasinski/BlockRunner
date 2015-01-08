using UnityEngine;
using System.Collections;

public class KillVolume : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag("Player")) 
		{
			Debug.Log ("Cary is God Tier");
			GameManager.manager.KillPlayer();
		}
	}
}
