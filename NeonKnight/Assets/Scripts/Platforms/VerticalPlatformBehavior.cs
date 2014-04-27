using UnityEngine;
using System.Collections;

public class VerticalPlatformBehavior : MonoBehaviour {
	public GameObject goPositionDot;
	public GameObject goMotionLine;
	
	private Vector2 m_startPosition;
	private Vector2 m_centerPosition;
	private Vector2 m_solutionPosition;
	private bool m_positive;
	
	Vector2 currentPosition;
	
	public float fltSolutionOffset = 5.0f;
	public float fltSnappingSpeed = 0.5f;

	public Vector2 GetStartPosition(){ return m_startPosition; }
	public Vector2 GetSolutionPosition(){ return m_solutionPosition; }

	private Vector3 velocity = Vector3.zero;

	void Start () 
	{
		m_startPosition = transform.position;
		m_solutionPosition = new Vector2 (m_startPosition.x, m_startPosition.y + fltSolutionOffset);
		m_centerPosition = new Vector2 (m_startPosition.x, (m_solutionPosition.y + m_startPosition.y)/2);
		if(m_solutionPosition.y - m_startPosition.y > 0)
			m_positive = true;
		else
			m_positive = false;
		
		displayPath();
	}

	void LateUpdate () 
	{
		transform.position = new Vector2(m_startPosition.x, transform.position.y);
		if(m_positive) 
		{
			if(transform.position.y < m_centerPosition.y - fltSolutionOffset/8)
				transform.position = Vector3.SmoothDamp(transform.position, m_startPosition, ref velocity, fltSnappingSpeed);
			else
				transform.position = Vector3.SmoothDamp(transform.position, m_solutionPosition, ref velocity, fltSnappingSpeed);

			if(this.transform.position.y >= m_solutionPosition.y)
				this.transform.position = new Vector2(transform.position.x, m_solutionPosition.y);

			if(this.transform.position.y <= m_startPosition.y)
				this.transform.position = new Vector2(transform.position.x, m_startPosition.y);
		}
		else
		{
			if(transform.position.y < m_centerPosition.y - fltSolutionOffset/8)
				transform.position = Vector3.SmoothDamp(transform.position, m_solutionPosition, ref velocity, fltSnappingSpeed);
			else
				transform.position = Vector3.SmoothDamp(transform.position, m_startPosition, ref velocity, fltSnappingSpeed);

			if(this.transform.position.y >= m_startPosition.y)
				this.transform.position = new Vector2(transform.position.x, m_startPosition.y);

			if(this.transform.position.y <= m_solutionPosition.y)
				this.transform.position = new Vector2(transform.position.x, m_solutionPosition.y);
		}
	}

	private void displayPath ()
	{
		GameObject motionLine;
		Vector2 startDotPos = new Vector2(m_startPosition.x + 0.075f, m_startPosition.y - 0.35f);
		Vector2 solutionDotPos = new Vector2(m_solutionPosition.x + 0.075f, m_solutionPosition.y - 0.35f);
		Vector2 centerLinePos = new Vector2 (startDotPos.x - 0.025f, (solutionDotPos.y + startDotPos.y)/2);

		Instantiate(goPositionDot, startDotPos, Quaternion.identity);
		Instantiate(goPositionDot, solutionDotPos, Quaternion.identity);
		motionLine = (GameObject)Instantiate(goMotionLine, centerLinePos, Quaternion.identity);
		motionLine.transform.GetChild(0).transform.localScale = new Vector3(Mathf.Abs(fltSolutionOffset), 5, 0);
	}
}

