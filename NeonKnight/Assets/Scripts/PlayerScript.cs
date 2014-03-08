using UnityEngine;
using System.Collections;

public class PlayerScript: MonoBehaviour {

	public float maxPower;
	public float power;
	public float setJumpVelocity;
	public Texture btnTexture;
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



	}
	void OnGUI()
	{
		if (GUI.Button(new Rect(10,10,50,50),btnTexture))
		{
			//Add Pause/slowtime function
		}
		GUI.Label(new Rect(800,10,100,20),score.ToString());
	}
}
