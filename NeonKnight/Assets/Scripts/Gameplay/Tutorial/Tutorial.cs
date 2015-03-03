using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tutorial : MonoBehaviour {
	public Text jumpText;
	public Text grabText;
	public Text dragText;
	public Text dragTextHorizontal;
	public Text superJumpText;
	public Text mbText;
	public Text teleportText;
	public static Tutorial tutorialText;
	public bool triggerJump = false;
	public enum TutorialState {idle,jump,grab,drag,drag2, superJump, MB, teleport}
	public TutorialState currentTutorialState = TutorialState.idle;

	void Start () {
		jumpText.enabled = false;
		grabText.enabled = false;
		dragText.enabled = false;
		dragTextHorizontal.enabled = false;
		teleportText.enabled = false;
	}

	void Update()
	{
		if (triggerJump && LevelManager.manager.playerManager.playerInstance.GetComponent<PlayerScript>().jumpState==PlayerScript.JumpState.jumping) 
		{
			LevelManager.manager.EnablePlayer();
			jumpText.enabled = false;
		}
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag ("Player") && this.tag =="JumpTrigger") 
		{
			UIToggle ();
			triggerJump = true;
		}

		if (collider.CompareTag ("Player") && this.tag !="JumpTrigger") 
		{
			UIToggle ();
		}
	}

	 void UIToggle()
	{
		switch (currentTutorialState) 
		{
		case TutorialState.jump:
			LevelManager.manager.DisablePlayer();
			jumpText.enabled = true;
			currentTutorialState=TutorialState.idle;
			break;

		case TutorialState.grab:
			StartCoroutine(Wait(grabText));
			break;

		case TutorialState.drag:
			StartCoroutine(Wait(dragText));
			break;

		case TutorialState.drag2:
			StartCoroutine(Wait(dragTextHorizontal));
			break;

		case TutorialState.superJump:
			StartCoroutine(Wait(superJumpText));
			break;

		case TutorialState.MB:
			StartCoroutine(Wait(mbText));
			break;

		case TutorialState.teleport:
			StartCoroutine(Wait(teleportText));
			break;

		case TutorialState.idle:
		default:
	
			break;
		
		}
	}


	IEnumerator Wait(Text currentText)
	{
		currentText.enabled = true;
		LevelManager.manager.DisablePlayer();
		LevelManager.manager.playerManager.playerInstance.GetComponent<PlayerScript>().jumpState = PlayerScript.JumpState.inactive;
		yield return new WaitForSeconds(3);
		currentText.enabled = false;
		LevelManager.manager.EnablePlayer();
		LevelManager.manager.playerManager.playerInstance.GetComponent<PlayerScript>().jumpState = PlayerScript.JumpState.grounded;
	}
}
