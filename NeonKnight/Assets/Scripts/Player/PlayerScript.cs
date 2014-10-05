using UnityEngine;
using System.Collections;

public class PlayerScript: MonoBehaviour 
{
	public float fltMoveSpeed = 4;
	public float fltJumpHeight = 10;
	public Vector3 StartingPosition;
	public bool blnPlayerActive = true;
	
	//private GameManager m_gameManager;
	
	[HideInInspector]
	public Animator playerAnimator;
	private bool jumping = false;
	private bool superJump = false;
	private float m_JumpHeight;
	
	void Start () 
	{	
		m_JumpHeight = fltJumpHeight;
		StartingPosition = transform.position;
		//m_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		playerAnimator = transform.GetChild(0).GetComponent<Animator>();
		playerAnimator.SetInteger("Movement", 1);
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space))
			Jump ();

		if(!jumping)
			playerAnimator.SetInteger("Movement", 1);
	}

	void FixedUpdate () 
	{
		MovePlayer();

	}

	void Jump()
	{
		if (superJump) 
		{
			m_JumpHeight = fltJumpHeight * 1.5f;
			Debug.Log (m_JumpHeight);
		} else {
			m_JumpHeight = fltJumpHeight;
		}
		this.rigidbody2D.velocity = new Vector2 (fltMoveSpeed, m_JumpHeight);
		StartCoroutine(JumpAnimation());
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

	IEnumerator JumpAnimation()
	{
		playerAnimator.SetInteger("Movement", 0);
		jumping = true;
		yield return new WaitForSeconds(0.5f);
		playerAnimator.SetInteger("Movement", 1);
	}

	void MovePlayer()
	{
		if(blnPlayerActive)
		{
			this.rigidbody2D.isKinematic = false;
			this.rigidbody2D.velocity = new Vector2(fltMoveSpeed, this.rigidbody2D.velocity.y);
		}
		else
		{
			this.rigidbody2D.isKinematic = true;
			this.rigidbody2D.velocity = Vector2.zero;
		}
	}
}
