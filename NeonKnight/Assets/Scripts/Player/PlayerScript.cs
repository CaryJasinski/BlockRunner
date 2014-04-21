using UnityEngine;
using System.Collections;

public class PlayerScript: MonoBehaviour 
{
	public float fltMoveSpeed = 4;
	public float fltJumpHeight = 10;
	public Vector3 StartingPosition;
	public bool triggerCollectionSmall = false;
	public bool triggerCollectionLarge = false;

	public GameObject GameManager;
	private GameManager m_gameManager;
	
	void Start () 
	{	
		StartingPosition = transform.position;
		GameManager = GameObject.Find("GameManager"); 
		m_gameManager = GameManager.GetComponent<GameManager>();
	}

	void Update () 
	{
		this.rigidbody2D.velocity = new Vector2(fltMoveSpeed, this.rigidbody2D.velocity.y);
	}
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag ("JumpPad"))
			this.rigidbody2D.velocity = new Vector2 (fltMoveSpeed, fltJumpHeight);

		switch (collider.tag) 
		{
			case "SmallCollect":
				triggerCollectionSmall = true;
				m_gameManager.IncreaseScore();
				break;

			case "LargeCollect":
				triggerCollectionLarge = true;
			    m_gameManager.IncreaseScore();
				break;
		}
		
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "MovablePlat")
			this.transform.parent = collision.gameObject.transform;
	}
	void OnCollisionExit2D(Collision2D collision)
	{
		this.transform.parent = null;
	}
}
