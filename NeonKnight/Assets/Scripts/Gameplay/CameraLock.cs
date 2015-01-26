using UnityEngine;
using System.Collections;

public class CameraLock : MonoBehaviour {

	public GameObject Player;
	private PlayerScript playerScript;
	public float cameraXOffset = 7f;
	public float cameraYOffset = 0f;
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
		playerScript = Player.GetComponent<PlayerScript>();
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

		Debug.Log( Player.rigidbody2D.velocity.y);

		cameraYOffset = 0;

		if(Player.rigidbody2D.velocity.y < 0 && Player.rigidbody2D.velocity.y < -15)
		{
			cameraYOffset = Player.rigidbody2D.velocity.y*0.75f;
		}

		PlayerPos.x = Player.transform.position.x + cameraXOffset;
		PlayerPos.y = Player.transform.position.y + cameraYOffset;


		CameraPos = transform.position;
		CameraPos.z = PlayerPos.z;
		
		transform.position = Vector3.SmoothDamp(CameraPos, PlayerPos, ref velocity, smoothTime);

		//Deactivates player movement while camera is not viewing the player
		//if(PlayerPos.x + 5 > CameraPos.x && PlayerPos.x - 12 < CameraPos.x)
			//Player.GetComponent<PlayerScript>().playerActive = true;
		if(PlayerPos.x - 13 > CameraPos.x)
			playerScript.playerActive = false;
	}
}
