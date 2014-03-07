using UnityEngine;
using System.Collections;

public class PlatMovement : MonoBehaviour {
	public GameObject goPositionDot;
	public GameObject goMotionLine;

	private Vector2 m_firstPosition;
	private Vector2 m_secondPosition;
	private Vector2 m_centerPosition;

	public float fltPositionOffest = 1.5f;

	public bool vertical = false;
	public bool moveable = false;

	public float fltLockedPosition;

	void Start () 
	{
		if(moveable)
		{
			m_firstPosition = new Vector2(transform.position.x, 
			                              transform.position.y);
			if(vertical)
			{
				m_secondPosition = new Vector2(m_firstPosition.x, 
				                             m_firstPosition.y + fltPositionOffest);
				m_centerPosition = new Vector2(m_firstPosition.x, 
				                             m_firstPosition.y + ((m_secondPosition.y - m_firstPosition.y)/2));
			}
			else
			{
				m_secondPosition = new Vector2(m_firstPosition.x + fltPositionOffest, 
				                             m_firstPosition.y);
				m_centerPosition = new Vector2(m_firstPosition.x + ((m_secondPosition.x - m_firstPosition.x)/2),
				                               m_firstPosition.y);
			}
			Debug.Log(m_firstPosition + " | " + m_secondPosition + " | " + m_centerPosition);

			Instantiate(goPositionDot, m_firstPosition, Quaternion.identity);
			Instantiate(goPositionDot, m_secondPosition, Quaternion.identity);
			if(vertical)
				Instantiate(goMotionLine, m_centerPosition, Quaternion.identity);
			else
				Instantiate(goMotionLine, m_centerPosition, Quaternion.Euler(0, 0, 90));
		}
	}
	void Update () 
	{
//		foreach (Touch touch in Input.touches) 
//		{
//			if (touch.phase == TouchPhase.Began)
//			{
//				Ray ray = Camera.main.ScreenPointToRay (touch.position);
//				if (Physics.Raycast (ray)) {
//					Instantiate (positionDot, transform.position, transform.rotation);
//				}
//			}
//		}
	}
	void OnMouseDown() {
		if(vertical) 
			fltLockedPosition = transform.position.x;
		else
			fltLockedPosition = transform.position.y;

		Screen.showCursor = false;
	}
	
	void OnMouseDrag() 
	{ 
		Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
		Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
		Debug.Log (curPosition.x);
		if(vertical)
		{
			curPosition.x = fltLockedPosition;

			if(curPosition.y > m_secondPosition.y)
				curPosition.y = m_secondPosition.y;
			if(curPosition.y < m_firstPosition.y)
				curPosition.y = m_firstPosition.y;

			//curPosition.y += transform.GetChild(0).transform.localScale.y;
		}
		else
		{
			curPosition.y = fltLockedPosition;
			if(curPosition.x > m_secondPosition.x)
				curPosition.x = m_secondPosition.x;
			if(curPosition.x < m_firstPosition.x)
				curPosition.x = m_firstPosition.x;
		}
		transform.position = new Vector2 (curPosition.x, curPosition.y);
	}
	
	void OnMouseUp()
	{
		Screen.showCursor = true;
	}
}
