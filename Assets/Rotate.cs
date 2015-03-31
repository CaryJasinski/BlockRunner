using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
	
	public float speed = 0f; 

	void Update () 
	{
		transform.Rotate(0,0,speed*Time.deltaTime);
	}
}
