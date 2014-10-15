using UnityEngine;
using System.Collections;

public class PlayerScript: MonoBehaviour 
{
	public float moveSpeed = 4;
	public float jumpHeight = 10;
	public float superJumpHeight = 20;
	public Vector3 startingPosition;
	public bool playerActive = true;
	
	//private GameManager m_gameManager;
	
	[HideInInspector]
	public Animator playerAnimator;
	private bool jumping = false;
	private bool superJump = false;
	private float m_JumpHeight;
	
	void Start () 
	{	
		m_JumpHeight = jumpHeight;
		startingPosition = transform.position;;
		playerAnimator = transform.GetChild(0).GetComponent<Animator>();
		playerAnimator.SetInteger("Movement", 1);
	}

	void Update ()
	{
		HandleInput ();
		//if(!jumping)
			//playerAnimator.SetInteger("Movement", 1);
	}

	void FixedUpdate () 
	{
		MovePlayer();
	}

	void HandleInput ()
	{
		if (Input.GetKeyDown (KeyCode.Space))
			Jump ();
	}

	void Jump()
	{
		if (superJump) 
			m_JumpHeight = jumpHeight * 1.5f;
		else
			m_JumpHeight = jumpHeight;

		this.rigidbody2D.velocity = new Vector2 (moveSpeed, m_JumpHeight);
		StartCoroutine(JumpAnimation());
	}

	IEnumerator JumpAnimation()
	{
		playerAnimator.SetInteger("Movement", 0);
		jumping = true;
		yield return new WaitForSeconds(0.5f);
		playerAnimator.SetInteger("Movement", 1);
	}

	void MovePlayer()
	{
		if(playerActive)
		{
			this.rigidbody2D.isKinematic = false;
			this.rigidbody2D.velocity = new Vector2(moveSpeed, this.rigidbody2D.velocity.y);
		}
		else
		{
			this.rigidbody2D.isKinematic = true;
			this.rigidbody2D.velocity = Vector2.zero;
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.CompareTag("JumpPad"))
			superJump = true;
	}
	
	void OnTriggerExit2D (Collider2D other)
	{
		if(other.CompareTag("JumpPad"))
			superJump = false;
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "MovablePlatform")
			this.transform.parent = collision.gameObject.transform;
	}
	
	void OnCollisionExit2D(Collision2D collision)
	{
		this.transform.parent = null;
	}
}
