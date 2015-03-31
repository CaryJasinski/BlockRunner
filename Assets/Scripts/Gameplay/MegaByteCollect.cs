using UnityEngine;
using System.Collections;

public class MegaByteCollect : MonoBehaviour {

	public bool wasCollected = false;

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag ("Player")) 
			collectMegaByte();
	}

	void collectMegaByte()
	{
		wasCollected = true;
		gameObject.SetActive(false);
	}
}
