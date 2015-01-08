using UnityEngine;
using System.Collections;

public class CollectBehavior : MonoBehaviour {
	
	public GameObject collectParticle;

	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.CompareTag("Player"))
			CollectBit();
	}

	void CollectBit()
	{
		PersistantData.persistantDataController.bits += 1;
		gameObject.SetActive(false);
		SpawnParticles();
	}

	void SpawnParticles()
	{
		Vector2 CollectPosition = (transform.position);
		
		Instantiate(collectParticle, CollectPosition, Quaternion.identity);
		Instantiate(collectParticle, CollectPosition, Quaternion.identity);
		Instantiate(collectParticle, CollectPosition, Quaternion.identity);
		Instantiate(collectParticle, CollectPosition, Quaternion.identity);
		Instantiate(collectParticle, CollectPosition, Quaternion.identity);
		
	}
}
