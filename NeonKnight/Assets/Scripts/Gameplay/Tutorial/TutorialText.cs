using UnityEngine;
using System.Collections;

public class TutorialText : MonoBehaviour {
	public Canvas Jump;

	void Start () {
		Jump.enabled = false;
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag ("Player"))
			Debug.Log ("hit");
			UIToggle ();
			PlayerToggle ();
	}
	public void UIToggle()
	{
		Jump.enabled = true;
	}

	public void PlayerToggle()
	{
		GameManager.manager.Player.GetComponent<PlayerScript>().playerActive = false;
	}
}
