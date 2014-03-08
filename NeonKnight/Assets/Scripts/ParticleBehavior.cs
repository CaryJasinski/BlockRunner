using UnityEngine;
using System.Collections;

public class ParticleBehavior : MonoBehaviour {


	public float timer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.rigidbody2D.AddForce(Random.insideUnitCircle * 100);
		timer -= Time.deltaTime;

		if(timer <= 0)
		{
			Destroy (gameObject);
			//this.rigidbody2D.AddForce();
		}
	}
}
