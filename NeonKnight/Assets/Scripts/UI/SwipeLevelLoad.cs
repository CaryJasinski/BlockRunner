using UnityEngine;
using System.Collections;

public class SwipeLevelLoad : MonoBehaviour {


	[HideInInspector] public HorizontalPlatformBehavior platform;

	void Start ()
	{
		platform = gameObject.GetComponent<HorizontalPlatformBehavior> ();	
	}

	void Update () 
	{
		SwipeToStart ();
	}

	//When Player swipes the platform, start level one
	void SwipeToStart()
	{
		if (transform.position.x > platform.solutionPosition.x - 0.1f) 
		{
			Application.LoadLevel("Level 1-1");
		}
	}
}
