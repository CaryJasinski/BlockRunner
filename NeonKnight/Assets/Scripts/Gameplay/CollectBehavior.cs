using UnityEngine;
using System.Collections;

public class CollectBehavior : MonoBehaviour {

	public Sprite bitSprite;
	public Sprite byteSprite;
	public SpriteRenderer collectibleSprite;
	public GameObject collectParticle;
	public enum CollectibleType {bitCollectible, byteCollectible}
	public CollectibleType collectibleType = CollectibleType.bitCollectible;

#if UNITY_EDITOR
	void OnDrawGizmos()
	{
		if(collectibleType == CollectibleType.byteCollectible)
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(transform.position, 0.5f);
		}
	}
#endif

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
		PersistantData.data.bits += GameManager.manager.bitValue;
		gameObject.SetActive(false);
		SpawnParticles();
	}

	void CollectByte()
	{
		Debug.Log("Hit");
		PersistantData.data.bits += GameManager.manager.byteValue;
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
