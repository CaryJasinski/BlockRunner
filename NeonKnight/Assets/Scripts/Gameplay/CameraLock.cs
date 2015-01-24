using UnityEngine;
using System.Collections;

public class CameraLock : MonoBehaviour {

	public GameObject Player;
	public float cameraOffset = 7f;
	public float smoothTime = 0.5f;
	public float cameraSize = 20.0f;
	public float orthoExpandSpeed = 10.0f;
	public bool isPlaying = false;

	private Vector3 PlayerPos;
	private Vector3 CameraPos;
	private Vector3 velocity = Vector3.zero;
	
	void Start () 
	{
		//Locks the cameras z pos to the z pos of the player
		PlayerPos.z = transform.position.z;
	}

	void FixedUpdate ()
	{

		if (isPlaying) 
		{   //Expands camera view size over time
			if (camera.orthographicSize < cameraSize)
			{
				camera.orthographicSize += orthoExpandSpeed * Time.fixedDeltaTime;
			}
		}

		PlayerPos.x = Player.transform.position.x + cameraOffset;
		PlayerPos.y = Player.transform.position.y;
		
		CameraPos = transform.position;
		CameraPos.z = PlayerPos.z;
		
		transform.position = Vector3.SmoothDamp(CameraPos, PlayerPos, ref velocity, smoothTime);

		//Deactivates player movement while camera is not viewing the player
		//if(PlayerPos.x + 5 > CameraPos.x && PlayerPos.x - 12 < CameraPos.x)
			//Player.GetComponent<PlayerScript>().playerActive = true;
		if(PlayerPos.x - 13 > CameraPos.x)
			Player.GetComponent<PlayerScript>().playerActive = false;
	}
}
