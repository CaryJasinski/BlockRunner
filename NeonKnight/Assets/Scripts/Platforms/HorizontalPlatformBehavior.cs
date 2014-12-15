using UnityEngine;
using System.Collections;

public class HorizontalPlatformBehavior : MonoBehaviour {
	public GameObject goPositionDot;
	public GameObject goMotionLine;
	
	[HideInInspector] public Vector2 startPosition;
	[HideInInspector] public Vector2 centerPosition;
	[HideInInspector] public Vector2 solutionPosition;
	private bool m_positive;
	
	Vector2 currentPosition;
	
	public float fltSolutionOffset = 5.0f;
	public float fltSnappingSpeed = 1.0f;

	public Vector2 GetStartPosition(){ return startPosition; }
	public Vector2 GetSolutionPosition(){ return solutionPosition; }

	private Vector3 velocity = Vector3.zero;

#if UNITY_EDITOR
	void OnDrawGizmos()
	{
		startPosition = transform.position;
		solutionPosition = new Vector2 (startPosition.x + fltSolutionOffset, startPosition.y);
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(solutionPosition, new Vector3(5.75f,0.25f,0));
	}
#endif

	void Start () 
	{
		startPosition = transform.position;
		solutionPosition = new Vector2 (startPosition.x + fltSolutionOffset, startPosition.y);
		centerPosition = new Vector2 ((solutionPosition.x + startPosition.x)/2, startPosition.y);
		if(solutionPosition.x - startPosition.x > 0)
			m_positive = true;
		else
			m_positive = false;
		
		displayPath();
	}

	void LateUpdate () 
	{
		
		transform.position = new Vector2(transform.position.x, startPosition.y);
		if(m_positive) 
		{
			if(transform.position.x < centerPosition.x - fltSolutionOffset/8)
				transform.position = Vector3.SmoothDamp(transform.position, startPosition, ref velocity, fltSnappingSpeed);
			else
				transform.position = Vector3.SmoothDamp(transform.position, solutionPosition, ref velocity, fltSnappingSpeed);

			if(this.transform.position.x >= solutionPosition.x)
			{
				this.transform.position = new Vector2(solutionPosition.x, transform.position.y);
			}
			if(this.transform.position.x <= startPosition.x)
			{
				this.transform.position = new Vector2(startPosition.x, transform.position.y);
			}
		}
		else
		{
			if(transform.position.x < centerPosition.x - fltSolutionOffset/8)
				transform.position = Vector3.SmoothDamp(transform.position, solutionPosition, ref velocity, fltSnappingSpeed);
			else
				transform.position = Vector3.SmoothDamp(transform.position, startPosition, ref velocity, fltSnappingSpeed);

			if(this.transform.position.x >= startPosition.x)
			{
				this.transform.position = new Vector2(startPosition.x, transform.position.y);
			}
			if(this.transform.position.x <= solutionPosition.x)
			{
				this.transform.position = new Vector2(solutionPosition.x, transform.position.y);
			}
		}
	}
	private void displayPath ()
	{
		GameObject motionLine;
		Vector2 startDotPos = new Vector2(startPosition.x + 0.0775f, startPosition.y - 0.35f);
		Vector2 solutionDotPos = new Vector2(solutionPosition.x + 0.0775f, solutionPosition.y - 0.35f);
		Vector2 centerLinePos = new Vector2 ((startDotPos.x + solutionDotPos.x)/2, startDotPos.y - 0.025f);

		Instantiate(goPositionDot, startDotPos, Quaternion.identity);
		Instantiate(goPositionDot, solutionDotPos, Quaternion.identity);
		motionLine = (GameObject)Instantiate(goMotionLine, centerLinePos, Quaternion.Euler(0, 0, 90));
		motionLine.transform.GetChild(0).transform.localScale = new Vector3(Mathf.Abs(fltSolutionOffset), 5, 0);
	}
}
