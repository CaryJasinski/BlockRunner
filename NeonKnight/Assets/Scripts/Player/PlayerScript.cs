using UnityEngine;
using System.Collections;

public class PlayerScript: MonoBehaviour 
{
	public float moveSpeed = 7;
	public float acceleration = 20;
	public float jumpHeight = 11;
	public float canSuperJumpHeight = 17.5f;
	public Vector3 startingPosition;
	public bool canJump = true;
	public bool playerActive = true;
	
	[HideInInspector]
	public Animator playerAnimator;
	private bool isGrounded = false;
	public bool canSuperJump = false;
	private float m_JumpHeight;

	void Start () 
	{	
		m_JumpHeight = jumpHeight;
		startingPosition = transform.position;
		playerAnimator = transform.GetChild(0).GetComponent<Animator>();
		playerAnimator.SetInteger("Movement", 1);

		if (Application.loadedLevelName == "Level 1") 
		{
			moveSpeed = 5;
			jumpHeight = 10;
			canSuperJumpHeight = 15;
		} 
		else 
		{
			moveSpeed = 7;
			jumpHeight = 11;
			canSuperJumpHeight = 17.5f;
		}
	}

	void Update ()
	{
		HandleInput ();
	}

	void FixedUpdate () 
	{
		MovePlayer();
	}

	void HandleInput ()
	{
		if (Input.GetKeyDown (KeyCode.Space) && canJump)
			Jump ();
	}

	void Jump()
	{
		if(isGrounded)
		{
			if (canSuperJump) 
				m_JumpHeight = canSuperJumpHeight;
			else
				m_JumpHeight = jumpHeight;

			this.rigidbody2D.velocity = new Vector2 (moveSpeed, m_JumpHeight);
			StartCoroutine(JumpAnimation());
		}
	}

	IEnumerator JumpAnimation()
	{
		playerAnimator.SetInteger("Movement", 0);
		yield return new WaitForSeconds(0.5f);
		playerAnimator.SetInteger("Movement", 1);
	}

	void MovePlayer()
	{
		if(playerActive)
		{
			canJump = true;
			this.rigidbody2D.isKinematic = false;
			this.rigidbody2D.velocity = new Vector2(moveSpeed, this.rigidbody2D.velocity.y);
		}
		else
		{
			canJump = false;
			Debug.Log("player cant move");
			this.rigidbody2D.isKinematic = true;
			this.rigidbody2D.velocity = Vector2.zero;
		}
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.CompareTag ("platform"))
			rigidbody2D.gravityScale = 20.0f;
		if(other.CompareTag("JumpPad"))
			canSuperJump = true;
		if(other.tag == "collectibleIcon")
			Destroy (other.gameObject);
	}
	
	void OnTriggerExit2D (Collider2D other)
	{
		if(other.CompareTag ("platform"))
			rigidbody2D.gravityScale = 3.0f;
		if(other.CompareTag("JumpPad"))
			canSuperJump = false;
	}
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		isGrounded = true;
		if(collision.gameObject.tag == "MasterPlatform")
			this.transform.parent = collision.gameObject.transform;
	}
	
	void OnCollisionExit2D(Collision2D collision)
	{
		isGrounded = false;
		this.transform.parent = null;
	}
}
