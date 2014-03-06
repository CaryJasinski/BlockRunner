using UnityEngine;
using System.Collections;

public class PlatMovement : MonoBehaviour {
	private Vector3 offset;
	public Vector2 FirstPosition;
	public Vector2 SecondPosition;
	public GameObject positionDot;
	public int secondPositionOffset = 6;
	public bool Vertical = false;
	public bool Moveable = false;
	
	void Start () 
	{
		if(Moveable)
		{
			FirstPosition = transform.position;
			Debug.Log(FirstPosition);
			if(Vertical)
			{
				SecondPosition = new Vector2(FirstPosition.x, FirstPosition.y + secondPositionOffset);
			}
			else
			{
				SecondPosition = new Vector2(FirstPosition.x + secondPositionOffset, FirstPosition.y);
			}
			Instantiate(positionDot, FirstPosition, Quaternion.identity);
			Instantiate(positionDot, SecondPosition, Quaternion.identity);
		}
	}
	void Update () 
	{
		foreach (Touch touch in Input.touches) 
		{
			if (touch.phase == TouchPhase.Began)
			{
				Ray ray = Camera.main.ScreenPointToRay (touch.position);
				if (Physics.Raycast (ray)) {
					Instantiate (positionDot, transform.position, transform.rotation);
				}
			}
		}
	}
	void OnMouseDown() 
	{
		if(Moveable)
		{
			offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
		}
	}
	
	void OnMouseDrag () 
	{
		if(Moveable)
		{
			if(Vertical) 
			{

			} 
			else 
			{

			}
		}
	}
}
