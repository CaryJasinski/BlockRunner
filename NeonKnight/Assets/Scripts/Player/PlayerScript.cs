using UnityEngine;
using System.Collections;

public class PlayerScript: MonoBehaviour 
{
	public float fltMoveSpeed = 4;
	public float fltJumpHeight = 10;
	public Vector3 StartingPosition;
	public bool triggerCollectionSmall = false;
	public bool triggerCollectionLarge = false;
	
	private GameManager m_gameManager;

	[HideInInspector]
	public Animator playerAnimator;
	private bool jumping = false;
	
	void Start () 
	{	
		StartingPosition = transform.position;
		m_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		playerAnimator = transform.GetChild(0).GetComponent<Animator>();
	}

	void Update () 
	{
		this.rigidbody2D.velocity = new Vector2(fltMoveSpeed, this.rigidbody2D.velocity.y);
		if(!jumping)
		{
			playerAnimator.SetInteger("Movement", 1);
		}
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.CompareTag ("JumpPad"))
		{
			this.rigidbody2D.velocity = new Vector2 (fltMoveSpeed, fltJumpHeight);
			StartCoroutine(JumpAnimation());
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
	IEnumerator JumpAnimation()
	{
		playerAnimator.SetInteger("Movement", 0);
		jumping = true;
		yield return new WaitForSeconds(0.5f);
		playerAnimator.SetInteger("Movement", 1);
	}
}
