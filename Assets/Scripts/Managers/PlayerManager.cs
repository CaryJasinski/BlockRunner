using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	public GameObject playerPrefab;
	public Transform playerStartMarker;
	public GameObject playerInstance = null;

	public void InitializePlayer()
	{
		if(playerInstance == null)
			playerInstance = (GameObject)Instantiate(playerPrefab, playerStartMarker.position, Quaternion.identity);
		else
			playerInstance.transform.position = playerStartMarker.position;

		DisablePlayer();
		CameraManager.manager.InitializeCamera(playerInstance);
	}

	public void EnablePlayer()
	{
		PlayerScript playerScript = playerInstance.GetComponent<PlayerScript>();
		playerScript.playerMotorState = PlayerScript.PlayerMotorState.running;
	}

	public void DisablePlayer()
	{
		PlayerScript playerScript = playerInstance.GetComponent<PlayerScript>();
		playerScript.playerMotorState = PlayerScript.PlayerMotorState.disabled;
	}

	public void DisablePlayerForDuration(float disableDuration)
	{
		StartCoroutine(DisablePlayerCorutine(disableDuration));
	}

	IEnumerator DisablePlayerCorutine(float disableDuration)
	{
		PlayerScript playerScript = playerInstance.GetComponent<PlayerScript>();
		playerScript.playerMotorState = PlayerScript.PlayerMotorState.disabled;
		yield return new WaitForSeconds(disableDuration);
		playerScript.playerMotorState = PlayerScript.PlayerMotorState.running;
	}

	public void ResetPlayer()
	{
		playerInstance.transform.position = playerStartMarker.position;
		DisablePlayer();
	}

	public GameObject GetPlayer()
	{
		return playerInstance;
	}
}
