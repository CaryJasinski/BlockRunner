using UnityEngine;
using System.Collections;

public class EndPortalBehavior : MonoBehaviour {

	//Animates portals
	void Update () 
	{
		transform.Rotate((-transform.forward) * Time.deltaTime * 25);
	}
}
