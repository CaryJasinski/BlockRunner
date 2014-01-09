using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	CharacterController controller;
	bool isJumping = false;
	float timer = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		controller = GetComponent<CharacterController>();
		controller.Move (new Vector3 (0.5f, 0, 0));
		if (isJumping)
			Jump ();
	}
	void OnTriggerEnter()
	{
		isJumping = true;
	}
	void Jump()
	{
		if (timer > 0) {
			timer -= Time.deltaTime;
			controller.Move (new Vector3 (0, 0.3f, 0));
		} else {
			//controller.Move (new Vector3 (0, 0, 0));
			isJumping = false;
		}
	}
}
