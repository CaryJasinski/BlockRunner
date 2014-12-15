using UnityEngine;
using System.Collections;

public class VerticalPlatformBehavior : MonoBehaviour {
	public GameObject goPositionDot;
	public GameObject goMotionLine;
	
	[HideInInspector] public Vector2 startPosition;
	[HideInInspector] public Vector2 centerPosition;
	[HideInInspector] public Vector2 solutionPosition;
	private bool m_positive;
	
	Vector2 currentPosition;
	
	public float fltSolutionOffset = 5.0f;
	public float fltSnappingSpeed = 0.5f;

	public Vector2 GetStartPosition(){ return startPosition; }
	public Vector2 GetSolutionPosition(){ return solutionPosition; }

	private Vector3 velocity = Vector3.zero;

	#if UNITY_EDITOR
	void OnDrawGizmos()
	{
		startPosition = transform.position;
		solutionPosition = new Vector2 (startPosition.x, startPosition.y + fltSolutionOffset);
		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(solutionPosition, new Vector3(5.75f,0.25f,0));
	}
	#endif

	void Start () 
	{
		startPosition = transform.position;
		solutionPosition = new Vector2 (startPosition.x, startPosition.y + fltSolutionOffset);
		centerPosition = new Vector2 (startPosition.x, (solutionPosition.y + startPosition.y)/2);
		if(solutionPosition.y - startPosition.y > 0)
			m_positive = true;
		else
			m_positive = false;
		
		displayPath();
	}

	void LateUpdate () 
	{
		transform.position = new Vector2(startPosition.x, transform.position.y);
		if(m_positive) 
		{
			if(transform.position.y < centerPosition.y - fltSolutionOffset/8)
				transform.position = Vector3.SmoothDamp(transform.position, startPosition, ref velocity, fltSnappingSpeed);
			else
				transform.position = Vector3.SmoothDamp(transform.position, solutionPosition, ref velocity, fltSnappingSpeed);

			if(this.transform.position.y >= solutionPosition.y)
				this.transform.position = new Vector2(transform.position.x, solutionPosition.y);

			if(this.transform.position.y <= startPosition.y)
				this.transform.position = new Vector2(transform.position.x, startPosition.y);
		}
		else
		{
			if(transform.position.y < centerPosition.y - fltSolutionOffset/8)
				transform.position = Vector3.SmoothDamp(transform.position, solutionPosition, ref velocity, fltSnappingSpeed);
			else
				transform.position = Vector3.SmoothDamp(transform.position, startPosition, ref velocity, fltSnappingSpeed);

			if(this.transform.position.y >= startPosition.y)
				this.transform.position = new Vector2(transform.position.x, startPosition.y);

			if(this.transform.position.y <= solutionPosition.y)
				this.transform.position = new Vector2(transform.position.x, solutionPosition.y);
		}
	}

	private void displayPath ()
	{
		GameObject motionLine;
		Vector2 startDotPos = new Vector2(startPosition.x + 0.075f, startPosition.y - 0.35f);
		Vector2 solutionDotPos = new Vector2(solutionPosition.x + 0.075f, solutionPosition.y - 0.35f);
		Vector2 centerLinePos = new Vector2 (startDotPos.x - 0.025f, (solutionDotPos.y + startDotPos.y)/2);

		Instantiate(goPositionDot, startDotPos, Quaternion.identity);
		Instantiate(goPositionDot, solutionDotPos, Quaternion.identity);
		motionLine = (GameObject)Instantiate(goMotionLine, centerLinePos, Quaternion.identity);
		motionLine.transform.GetChild(0).transform.localScale = new Vector3(Mathf.Abs(fltSolutionOffset), 5, 0);
	}
}

