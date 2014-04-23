using UnityEngine;
using System.Collections;

public class CollectBehavior : MonoBehaviour {
	
	public GameObject collectParticle;
	public GameObject currentCollectible;
	public GameObject GameManager;
	private GameManager m_gameManager;

	void Start()
	{
		GameManager = GameObject.FindGameObjectWithTag("GameManager");
		m_gameManager = GameManager.GetComponent<GameManager>();
	}

	void OnTap(TapGesture gesture)
	{
		DestroyBit();
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.CompareTag("Player"))
			DestroyBit();
	}

	void DestroyBit()
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

		m_gameManager.IncreaseScore();

		Destroy (gameObject);
	}
}
