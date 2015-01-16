using UnityEngine;
using System.Collections;

public class CollectBehavior : MonoBehaviour {

	public Sprite bitSprite;
	public Sprite byteSprite;
	public SpriteRenderer collectibleSprite;
	public GameObject collectParticle;
	public enum CollectibleType {bitCollectible, byteCollectible}
	public CollectibleType collectibleType = CollectibleType.bitCollectible;

	void Start()
	{
		if (collectibleType == CollectibleType.bitCollectible)
			collectibleSprite.sprite = bitSprite;

		if (collectibleType == CollectibleType.byteCollectible)
			collectibleSprite.sprite = byteSprite;
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag ("Player")) 
		{
			if (collectibleType == CollectibleType.bitCollectible)
				 CollectBit ();

			if (collectibleType == CollectibleType.byteCollectible)
				CollectByte();
		}
	}

	void CollectBit()
	{
		PersistantData.persistantDataController.bits += GameManager.manager.bitValue;
		gameObject.SetActive(false);
		SpawnParticles();
	}

	void CollectByte()
	{
		PersistantData.persistantDataController.bits += GameManager.manager.byteValue;
		gameObject.SetActive(false);
		SpawnParticles();
	}

	void CollectMegaByte()
	{
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
