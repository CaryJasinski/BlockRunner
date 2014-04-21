using UnityEngine;
using System.Collections;

public class ParticleBehavior : MonoBehaviour {


	public float timer;
	public GameObject target;
	bool canAttract = false;
	Vector2 dir;
	// Use this for initialization
	void Start () {

		this.rigidbody2D.AddForce(Random.insideUnitCircle * 100);
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		timer -= Time.deltaTime;


		if(timer <= 0)
		{

			canAttract = true;

			transform.position = Vector2.Lerp(transform.position,-target.transform.position,Time.deltaTime);
			//rigidbody2D.AddForce((-target.transform.position) * force * Time.smoothDeltaTime);
			//Destroy (gameObject);

		}

	}
	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.gameObject.tag == "Player")
		{
			if(canAttract == true)
			{
			Destroy (gameObject);
			}
		}
	}
}
