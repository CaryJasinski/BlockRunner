using UnityEngine;
using System.Collections;

public class JumpTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTap( TapGesture gesture )
	{
		if(LevelManager.manager != null)
		{
			GameObject playerInstance = LevelManager.manager.GetPlayerInstance();
			playerInstance.GetComponent<PlayerScript>().Jump();
		}
	}
}
