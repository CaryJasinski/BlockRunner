using UnityEngine;
using System.Collections;

public class ClickAndRotate : MonoBehaviour {
	[HideInInspector] public Vector3 StartPosition = new Vector3(0,0,270);
	[HideInInspector] public Vector3 EndPosition = new Vector3(0,0,90);
	public bool StartPos = true;

	void OnMouseDown() {
		if (StartPos) {
			transform.Rotate(EndPosition);
			StartPos = false;
		} else {
			transform.Rotate(StartPosition);
			StartPos = true;
		}
	}
}