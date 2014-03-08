using UnityEngine;
using System.Collections;

public class PlayerScript: MonoBehaviour {

	public float maxPower;
	public float power;
	public float setJumpVelocity;
	public Texture btnTexture;
	public Transform playerTransform;
	int score;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(this.rigidbody2D.velocity.magnitude <= maxPower)
		{
		this.rigidbody2D.AddForce(gameObject.transform.right*power);
		}


	}
	void OnTriggerEnter2D(Collider2D collider)
	{
		float jumpVelocity = setJumpVelocity;
		Vector2 currentVelocity = this.rigidbody2D.velocity;

		if(collider.gameObject.tag == "JumpPad")
		{

			this.rigidbody2D.velocity = new Vector2(currentVelocity.x,jumpVelocity);
		}


		if(collider.gameObject.tag == "SmallCollect")
		{
			score += 100;
		}
		if(collider.gameObject.tag == "LargeCollect")
		{
			score += 300;
		}

		if(collider.gameObject.tag == "EndPortal"){
			Application.LoadLevel("WinScreen");
		}

		if(collider.gameObject.tag == "KillTrigger"){
			Application.LoadLevel("LoseScreen");
		}



	}
	void OnCollisionEnter2D(Collision2D collision)
	{


		if(collision.gameObject.tag == "MovablePlat")
		{
			playerTransform.parent = collision.gameObject.transform;
		}



	}
	void OnCollisionExit2D(Collision2D collision)
	{
		this.transform.parent = null;

	}
	void OnGUI()
	{
		//if (GUI.Button(new Rect(10,10,50,50),btnTexture))
		//{
			//Add Pause/slowtime function
		//}
		//GUI.Label(new Rect(800,10,100,20),score.ToString());
	}

	
}
