using UnityEngine;
using System.Collections;

public class ScrollScript : MonoBehaviour {

	public float speed = 0f;
	public Vector2 playerSpeed = Vector2.zero;
	public Vector2 previousPlayerPos = Vector2.zero;

	void Update () 
	{
		Vector2 playerPos = new Vector2(LevelManager.manager.playerManager.playerInstance.transform.position.x, 
		                          LevelManager.manager.playerManager.playerInstance.transform.position.y);

		playerSpeed = playerPos - previousPlayerPos;

		GetComponent<Renderer>().material.mainTextureOffset = new Vector2((Time.time * playerSpeed.x)%1, (Time.time * playerSpeed.y)%1);

		previousPlayerPos = playerPos;
		playerSpeed = Vector2.zero;
	}
}
