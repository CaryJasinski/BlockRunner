using UnityEngine;
using System.Collections;

public class DragAndRotate : MonoBehaviour {

	public float startRotationZ;
	public float solutionRotationZ;
	
	void Start () 
	{
		startRotationZ = transform.eulerAngles.z;
		solutionRotationZ = transform.eulerAngles.z + 270;
	}

	void Update () 
	{
		Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		diff.Normalize();
		
		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		float transRotZ = transform.eulerAngles.z;

		if((startRotationZ + 90) > transRotZ && transRotZ > startRotationZ)
			transform.rotation = Quaternion.Euler(0f, 0f, startRotationZ);

		if((solutionRotationZ - 180) < transRotZ && transRotZ < solutionRotationZ)
			transform.rotation = Quaternion.Euler(0f, 0f, solutionRotationZ);
	}

	void OnMouseDrag()
	{
		Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		diff.Normalize();
		
		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		//Debug.Log(rot_z);
		transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
	}
}
