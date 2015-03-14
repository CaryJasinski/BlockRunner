using UnityEngine;
using System.Collections;

public class ScrollScript : MonoBehaviour {

	public float speed = 0f;


	void Update () 
	{
		GetComponent<Renderer>().material.mainTextureOffset = new Vector2((Time.time * speed)%1, 0f);
	}
}
