using UnityEngine;
using System.Collections;

public class EndPortal : MonoBehaviour {

	private int m_currentLevelIndex;
	public GameObject targetPortal;
	private Vector2 targetPortalPosition =  Vector3.zero;

	void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawLine(transform.position, targetPortal.transform.position);
	}

	void Start()
	{
		targetPortalPosition = targetPortal.transform.position;
		//m_currentLevelIndex = Application.loadedLevel;
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.CompareTag("Player"))
		{
			collider.transform.position = targetPortalPosition;
			//Application.LoadLevel(m_currentLevelIndex++);
		}
	}
}
