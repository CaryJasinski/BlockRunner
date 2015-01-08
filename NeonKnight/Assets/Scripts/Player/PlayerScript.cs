using UnityEngine;
using System.Collections;

public class PlayerScript: MonoBehaviour 
{
	public float moveSpeed = 4;
	public float acceleration = 20;
	public float jumpHeight = 4;
	public float canSuperJumpHeight = 20;
	public Vector3 startingPosition;
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
		if (Input.GetKeyDown (KeyCode.Space))
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
