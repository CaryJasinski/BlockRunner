using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

	public GameObject exitPortal;

#if UNITY_EDITOR
	void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawLine(transform.position, exitPortal.transform.position);
	}
#endif	
	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.CompareTag("Player"))
			collider.transform.position = exitPortal.transform.position;
	}
}
