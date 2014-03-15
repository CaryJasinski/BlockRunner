using UnityEngine;
using System.Collections;

public class MovePlatform : MonoBehaviour 
{
	public GameObject goPositionDot;
	public GameObject goMotionLine;

	private Vector2 m_startPosition;
	private Vector2 m_centerPosition;
	private Vector2 m_solutionPosition;

	public float fltSolutionOffset = 5.0f;

	public bool vertical = false;
	private bool m_positive = true;
	
	void Start () 
	{
		assignPositions ();
		displayPath ();
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

	void OnMouseDrag ()
	{
		Vector3 touchPoint = Camera.main.ScreenToWorldPoint (new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));

		if(vertical)
			transform.position = moveVertical(touchPoint);
		else
			transform.position = moveHorizontal(touchPoint);
	}

	void OnMouseUp ()
	{
		transform.position = snapPlatform();
	}

	private void assignPositions ()
	{
		m_startPosition = transform.position;
		if(vertical)
		{
			m_solutionPosition = new Vector2 (m_startPosition.x, m_startPosition.y + fltSolutionOffset);
			m_centerPosition = new Vector2 (m_startPosition.x, (m_solutionPosition.y + m_startPosition.y)/2);
			if(m_solutionPosition.y - m_startPosition.y > 0)
				m_positive = true;
			else
				m_positive = false;
		}
		else
		{
			m_solutionPosition = new Vector2 (m_startPosition.x + fltSolutionOffset, m_startPosition.y);
			m_centerPosition = new Vector2 ((m_solutionPosition.x + m_startPosition.x)/2, m_startPosition.y);
			if(m_solutionPosition.x - m_startPosition.x > 0)
				m_positive = true;
			else
				m_positive = false;
		}
	}
	private void displayPath ()
	{
		GameObject motionLine;
		Instantiate(goPositionDot, m_startPosition, Quaternion.identity);
		Instantiate(goPositionDot, m_solutionPosition, Quaternion.identity);
		if(vertical)
			motionLine = (GameObject)Instantiate(goMotionLine, m_centerPosition, Quaternion.identity);
		else
			motionLine = (GameObject)Instantiate(goMotionLine, m_centerPosition, Quaternion.Euler(0, 0, 90));
		motionLine.transform.GetChild(0).transform.localScale = new Vector3(Mathf.Abs(fltSolutionOffset), 5, 0);
	}

	private Vector2 snapPlatform()
	{
		Vector2 snapPosition;

		if(m_positive)
		{
			if(vertical)
			{
				if(transform.position.y > m_centerPosition.y)//above
					snapPosition = m_solutionPosition;
				else
					snapPosition = m_startPosition;
			}
			else
			{
				if(transform.position.x > m_centerPosition.x)//above
					snapPosition = m_solutionPosition;
				else
					snapPosition = m_startPosition;
			}
		}
		else
		{
			if(vertical)
			{
				if(transform.position.y > m_centerPosition.y)//above
					snapPosition = m_startPosition;
				else
					snapPosition = m_solutionPosition;
			}
			else
			{
				if(transform.position.x > m_centerPosition.x)//above
					snapPosition = m_startPosition;
				else
					snapPosition = m_solutionPosition;
			}
		}
		return snapPosition;
	}

	private Vector2 moveVertical(Vector3 touchPoint)
	{
		float lockPosition = m_startPosition.x;
		if(m_positive)
		{
			if(touchPoint.y > m_solutionPosition.y)
				touchPoint.y = m_solutionPosition.y;
			if(touchPoint.y < m_startPosition.y)
				touchPoint.y = m_startPosition.y;
		}
		else
		{
			if(touchPoint.y > m_startPosition.y)
				touchPoint.y = m_startPosition.y;
			if(touchPoint.y < m_solutionPosition.y)
				touchPoint.y = m_solutionPosition.y;
		}
		return new Vector2 (lockPosition, touchPoint.y);
	}

	private Vector2 moveHorizontal(Vector3 touchPoint)
	{
		float lockPosition = m_startPosition.y;
		if(m_positive)
		{
			if(touchPoint.x > m_solutionPosition.x)
				touchPoint.x = m_solutionPosition.x;
			if(touchPoint.x < m_startPosition.x)
				touchPoint.x = m_startPosition.x;
		}
		else
		{
			if(touchPoint.x > m_startPosition.x)
				touchPoint.x = m_startPosition.x;
			if(touchPoint.x < m_solutionPosition.x)
				touchPoint.x = m_solutionPosition.x;
		}
		return new Vector2 (touchPoint.x, lockPosition);
	}
}
