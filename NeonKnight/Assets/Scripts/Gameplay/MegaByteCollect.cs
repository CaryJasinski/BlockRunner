using UnityEngine;
using System.Collections;

public class MegaByteCollect : MonoBehaviour {
	public bool wasCollected = false;

	void Start () {
	
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag ("Player")) 
		{
			Debug.Log("megabyte");
			collectMegaByte();
		}
	}

	void collectMegaByte()
	{
		wasCollected = true;
	}
}
