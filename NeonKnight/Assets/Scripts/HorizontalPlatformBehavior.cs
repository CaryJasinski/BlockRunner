using UnityEngine;
using System.Collections;

public class HorizontalPlatformBehavior : MonoBehaviour {
	public GameObject goPositionDot;
	public GameObject goMotionLine;
	
	private Vector2 m_startPosition;
	private Vector2 m_centerPosition;
	private Vector2 m_solutionPosition;
	private bool m_positive;
	
	Vector2 currentPosition;
	
	public float fltSolutionOffset = 5.0f;
	
	void Start () 
	{
		m_startPosition = transform.position;
		m_solutionPosition = new Vector2 (m_startPosition.x + fltSolutionOffset, m_startPosition.y);
		m_centerPosition = new Vector2 ((m_solutionPosition.x + m_startPosition.x)/2, m_startPosition.y);
		if(m_solutionPosition.x - m_startPosition.x > 0)
			m_positive = true;
		else
			m_positive = false;
		
		displayPath();
	}
	
	void LateUpdate () 
	{
		
		transform.position = new Vector2(transform.position.x, m_startPosition.y);
		if(m_positive) 
		{
			if(this.transform.position.x >= m_solutionPosition.x)
			{
				this.transform.position = new Vector2(m_solutionPosition.x, transform.position.y);
			}
			if(this.transform.position.x <= m_startPosition.x)
			{
				this.transform.position = new Vector2(m_startPosition.x, transform.position.y);
			}
		}
		else
		{
			if(this.transform.position.x >= m_startPosition.x)
			{
				this.transform.position = new Vector2(m_startPosition.x, transform.position.y);
			}
			if(this.transform.position.x <= m_solutionPosition.x)
			{
				this.transform.position = new Vector2(m_solutionPosition.x, transform.position.y);
			}
		}
	}
	private void displayPath ()
	{
		GameObject motionLine;
		Instantiate(goPositionDot, m_startPosition, Quaternion.identity);
		Instantiate(goPositionDot, m_solutionPosition, Quaternion.identity);
		motionLine = (GameObject)Instantiate(goMotionLine, m_centerPosition, Quaternion.Euler(0, 0, 90));
		motionLine.transform.GetChild(0).transform.localScale = new Vector3(Mathf.Abs(fltSolutionOffset), 5, 0);
	}
}
