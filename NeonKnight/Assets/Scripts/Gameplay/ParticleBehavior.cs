using UnityEngine;
using System.Collections;

public class ParticleBehavior : MonoBehaviour {

	
	public GameObject target;
	Vector2 dir;
	
	void Start ()
	{
		this.rigidbody2D.AddForce(Random.insideUnitCircle * 100);
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = Vector2.Lerp(transform.position, target.transform.position, 0.25f*Time.deltaTime);
		//if(transform.position == new Vector2(target.x)
		//rigidbody2D.AddForce((-target.transform.position) * force * Time.smoothDeltaTime);
		//Destroy (gameObject);
	}
}
