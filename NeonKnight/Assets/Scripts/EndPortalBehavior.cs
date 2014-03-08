using UnityEngine;
using System.Collections;

public class EndPortalBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Rotate((-transform.forward) * Time.deltaTime * 25);
	}
}
