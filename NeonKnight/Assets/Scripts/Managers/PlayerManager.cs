using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	public GameObject playerPrefab;
	public Transform playerStartMarker;
	private GameObject playerInstance = null;

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
		playerScript.playerMotorState = PlayerScript.PlayerMotorState.walking;
	}

	public void DisablePlayer()
	{
		PlayerScript playerScript = playerInstance.GetComponent<PlayerScript>();
		playerScript.playerMotorState = PlayerScript.PlayerMotorState.disabled;
	}

	public void ResetPlayer()
	{
		playerInstance.transform.position = playerStartMarker.position;
		DisablePlayer();
	}
}
