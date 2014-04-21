using UnityEngine;
using System.Collections;

public class CameraLock : MonoBehaviour {

	public GameObject Player;
	public float fltCameraOffset = 7;
	public float fltSmoothTime = 0.5f;
	
	private Vector3 PlayerPos;
	private Vector3 CameraPos;
	private Vector3 velocity = Vector3.zero;
	
	void Start () {
		PlayerPos.z = transform.position.z;
	}

	void Update () 
	{
		PlayerPos.x = Player.transform.position.x + fltCameraOffset;
		PlayerPos.y = Player.transform.position.y;

		CameraPos = transform.position;
		CameraPos.x = PlayerPos.x;
		CameraPos.z = PlayerPos.z;

		transform.position = Vector3.SmoothDamp(CameraPos, PlayerPos, ref velocity, fltSmoothTime);
	}
}
