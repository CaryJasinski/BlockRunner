using UnityEngine;
using System.Collections;

public class EndPortal : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.CompareTag("Player"))
		{
			GameManager.manager.LevelSuccess();
		}
	}
}
