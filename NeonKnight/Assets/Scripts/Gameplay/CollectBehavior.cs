using UnityEngine;
using System.Collections;

public class CollectBehavior : MonoBehaviour {
	
	public GameObject collectParticle;
	public GameObject currentCollectible;
	
	void OnTap(TapGesture gesture)
	{
		Vector2 CollectPosition = (currentCollectible.transform.position);
		
		Instantiate(collectParticle, CollectPosition, Quaternion.identity);
		Instantiate(collectParticle, CollectPosition, Quaternion.identity);
		Instantiate(collectParticle, CollectPosition, Quaternion.identity);
		Instantiate(collectParticle, CollectPosition, Quaternion.identity);
		Instantiate(collectParticle, CollectPosition, Quaternion.identity);
		Instantiate(collectParticle, CollectPosition, Quaternion.identity);
		Instantiate(collectParticle, CollectPosition, Quaternion.identity);
		Instantiate(collectParticle, CollectPosition, Quaternion.identity);
		Instantiate(collectParticle, CollectPosition, Quaternion.identity);
		
		Destroy (gameObject);
	}
}
