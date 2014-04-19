using UnityEngine;
using System.Collections;

public class PlayerScript: MonoBehaviour {

	public float maxPower;
	public float power;
	public float setJumpVelocity;
	public Texture btnTexture;
	public Transform playerTransform;
	private Vector2 m_startingPosition;
	public GUISkin NeonKnightGUI;
	int score;

	private PlayerManager m_playerManager;
	private PlatformManager m_platformManager;

	// Use this for initialization
	void Start () 
	{
		m_startingPosition = transform.position;
		m_playerManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlayerManager>();
		m_platformManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlatformManager>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(this.rigidbody2D.velocity.magnitude <= maxPower)
			this.rigidbody2D.AddForce(gameObject.transform.right*power);
	}
	void OnTriggerEnter2D(Collider2D collider)
	{
				float jumpVelocity = setJumpVelocity;
				Vector2 currentVelocity = this.rigidbody2D.velocity;

				if (collider.gameObject.tag == "JumpPad")
						this.rigidbody2D.velocity = new Vector2 (currentVelocity.x, jumpVelocity);

				if (collider.gameObject.tag == "SmallCollect")
						score += 100;
				if (collider.gameObject.tag == "LargeCollect")
						score += 300;
	
				if (collider.gameObject.tag == "KillTrigger") {
						transform.position = m_startingPosition;
						m_playerManager.SendMessage ("deductLife");
						m_platformManager.SendMessage("ResetPlatformPositions");
				}

				if (collider.gameObject.tag == "EndPortalTutorial") {
						Application.LoadLevel ("Level 1-1");
				}
		
				if (collider.gameObject.tag == "EndPortalLevelOne") {
						Application.LoadLevel ("Level 1-2");
				}
		
				if (collider.gameObject.tag == "EndPortalLevelTwo") {
						Application.LoadLevel ("Level 1-3");
				} 

				if (collider.gameObject.tag == "EndPortalLevelThree") {
						Application.LoadLevel ("Level 1-4");
				}

				if (collider.gameObject.tag == "EndPortalLevelFour") {
						Application.LoadLevel ("Level 1-5");
				}

				if (collider.gameObject.tag == "EndPortalLevelFive") {
					Application.LoadLevel ("WinScreen");
				}

		}
	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "MovablePlat")
			playerTransform.parent = collision.gameObject.transform;
	}
	void OnCollisionExit2D(Collision2D collision)
	{
		this.transform.parent = null;
	}
	void OnGUI()
	{
		GUI.skin = NeonKnightGUI;
		//if (GUI.Button(new Rect(10,10,50,50),btnTexture))
		//{
			//Add Pause/slowtime function
		//}
		GUI.Label(new Rect (Screen.width / 2 - 100, 10, 200, 50), "Score: "+score+"");
	}
}
