using UnityEngine;
using System.Collections;

public class CameraLock : MonoBehaviour {
	public Vector3 startPosition;

	// Use this for initialization
	void Start () {
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.parent.position.x, startPosition.y, startPosition.z);
	}
}
