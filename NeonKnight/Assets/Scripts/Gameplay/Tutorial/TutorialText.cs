using UnityEngine;
using System.Collections;

public class TutorialText : MonoBehaviour {
//	public Canvas JumpCanvas;
//	public static TutorialText tutorialText;
//	public bool triggerJump = false;
//	public bool hasJumped = false;
//
//	void Start () {
//		JumpCanvas.enabled = false;
//	}
//	void Awake()
//	{        //If manager doesn't exist, create one
//		if(tutorialText == null)
//		{
//			DontDestroyOnLoad(gameObject);
//			tutorialText = this;
//		} 
//		else if(tutorialText != null)    //if manager does exist, destroy this copy
//			{
//				Destroy(gameObject);
//			}
//		tutorialText = this;
//	}
//	void Update()
//	{
//		if (triggerJump && Input.GetKeyDown (KeyCode.Space)) 
//		{
//			hasJumped = true;
//			PlayerToggle ();
//			UIToggle ();
//		}
//	}
//
//	void OnTriggerEnter2D(Collider2D collider)
//	{
//		if (collider.CompareTag ("Player")) 
//		{
//			UIToggle ();
//			PlayerToggle();
//			triggerJump = true;
//		}
//	}
//	 void UIToggle()
//	{
//		JumpCanvas.enabled = true;
//		if (hasJumped)
//			JumpCanvas.enabled = false;
//	}
//
//	 void PlayerToggle()
//	{
//		GameManager.manager.Player.GetComponent<PlayerScript>().playerActive = false;
//		GameManager.manager.Player.GetComponent<PlayerScript> ().canJump = true;
//		if (hasJumped)
//		{
//			GameManager.manager.Player.GetComponent<PlayerScript> ().playerActive = true;
//			GameManager.manager.Player.GetComponent<PlayerScript>().Jump ();
//		}
//	}
//
//	public void DeathReset()
//	{
//		triggerJump = false;
//		hasJumped = false;
//		JumpCanvas.enabled = false;
//		GameManager.manager.Player.GetComponent<PlayerScript>().canJump = false;
//	}
}
