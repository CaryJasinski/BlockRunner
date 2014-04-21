using UnityEngine;
using System.Collections;

public class CollectBehavior : MonoBehaviour {


	public GameObject collectParticle;
	public GameObject currentCollectible;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void OnTriggerEnter2D(Collider2D collider)
	{



		if(collider.gameObject.tag == "Player")
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
}
